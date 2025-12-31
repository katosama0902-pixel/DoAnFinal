
CREATE DATABASE movie_db_v2;
GO

USE movie_db_v2;
GO

-- =============================================
-- 1. BẢNG USERS (Người dùng hệ thống)
-- =============================================
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL UNIQUE, -- Tên đăng nhập
    password VARCHAR(255) NOT NULL,       -- Mật khẩu (Lưu mã hóa MD5/SHA)
    email VARCHAR(100) NULL,              -- Email (Dùng để khôi phục mật khẩu)
    role VARCHAR(20) NOT NULL,            -- 'Admin' hoặc 'Staff'
    status VARCHAR(20) DEFAULT 'Active',  -- 'Active', 'Locked'
    date_reg DATETIME DEFAULT GETDATE()   -- Ngày tạo tài khoản
);

-- =============================================
-- 2. BẢNG CUSTOMERS (Khách hàng thành viên) -> Phục vụ Form CustomerManager
-- =============================================
CREATE TABLE customers (
    id INT PRIMARY KEY IDENTITY(1,1),
    full_name NVARCHAR(100) NOT NULL,     -- Tên có dấu tiếng Việt
    phone_number VARCHAR(15) NOT NULL UNIQUE, -- Số điện thoại (dùng để tìm kiếm khi bán vé)
    points INT DEFAULT 0,                 -- Điểm tích lũy
    created_at DATETIME DEFAULT GETDATE()
);

-- =============================================
-- 3. BẢNG MOVIES (Phim)
-- =============================================
CREATE TABLE movies (
    id INT PRIMARY KEY IDENTITY(1,1),
    movie_id VARCHAR(20) NOT NULL UNIQUE, -- Mã phim thủ công (VD: MV-001) để dễ nhớ
    movie_name NVARCHAR(200) NOT NULL,    -- Tên phim
    genre NVARCHAR(50),                   -- Thể loại
    price DECIMAL(18, 2) NOT NULL,        -- Giá vé (Dùng DECIMAL cho tiền tệ)
    capacity INT NOT NULL,                -- Tổng số ghế
    movie_image VARCHAR(500) NULL,        -- Chỉ lưu tên file (VD: mv001.jpg)
    status NVARCHAR(50) DEFAULT 'Available', -- 'Available', 'Stopped'
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME NULL
);

-- =============================================
-- 4. BẢNG TICKETS (Vé / Lịch sử giao dịch) -> Phục vụ Form TransactionHistory
-- =============================================
CREATE TABLE tickets (
    id INT PRIMARY KEY IDENTITY(1,1),
    movie_id VARCHAR(20) NOT NULL,        -- Liên kết với bảng Movies
    customer_id INT NULL,                 -- Liên kết với bảng Customers (NULL nếu là khách vãng lai)
    staff_id INT NOT NULL,                -- Ai là người bán vé này?
    
    seat_number INT NOT NULL,             -- Số ghế
    price DECIMAL(18, 2) NOT NULL,        -- Giá tại thời điểm bán
    created_at DATETIME DEFAULT GETDATE(),-- Thời gian bán (Ngày/Giờ)
    
    -- KHÓA NGOẠI (Ràng buộc dữ liệu)
    FOREIGN KEY (movie_id) REFERENCES movies(movie_id),
    FOREIGN KEY (customer_id) REFERENCES customers(id),
    FOREIGN KEY (staff_id) REFERENCES users(id),

    -- RÀNG BUỘC: Một phim không được bán trùng ghế
    CONSTRAINT UQ_Movie_Seat UNIQUE (movie_id, seat_number)
);

-- =============================================
-- 5. THÊM DỮ LIỆU MẪU (SEED DATA)
-- =============================================

-- Thêm Admin và Nhân viên (Pass: 123456 - Đây là mã Hash MD5 của 123456)
-- Lưu ý: Khi code C#, bạn nhớ dùng hàm HashHelper để mã hóa trước khi so sánh
INSERT INTO users (username, password, email, role, status) VALUES 
('admin', 'E10ADC3949BA59ABBE56E057F20F883E', 'admin@cinema.com', 'Admin', 'Active'),
('staff', 'E10ADC3949BA59ABBE56E057F20F883E', 'staff@cinema.com', 'Staff', 'Active');

-- Thêm Khách hàng mẫu
INSERT INTO customers (full_name, phone_number, points) VALUES 
(N'Nguyễn Văn A', '0909123456', 10),
(N'Trần Thị B', '0912345678', 50);

-- Thêm Phim mẫu
INSERT INTO movies (movie_id, movie_name, genre, price, capacity, movie_image, status) VALUES 
('MV-001', N'Đào, Phở và Piano', N'Lịch sử', 45000, 50, 'dao-pho.jpg', 'Available'),
('MV-002', N'Mai', N'Tâm lý', 60000, 100, 'mai.jpg', 'Available'),
('MV-003', N'Dune: Part Two', N'Viễn tưởng', 80000, 150, 'dune2.jpg', 'Available');

-- Thêm vài vé đã bán (Lịch sử giao dịch)
-- Bán vé phim MV-001 cho khách có ID = 1, do nhân viên ID = 2 bán
INSERT INTO tickets (movie_id, customer_id, staff_id, seat_number, price, created_at) VALUES 
('MV-001', 1, 2, 5, 45000, GETDATE()),
('MV-001', 1, 2, 6, 45000, GETDATE());

GO

ALTER TABLE movies
ADD price_vip INT NULL;

-- 2. Cập nhật dữ liệu mẫu (Giá VIP = Giá thường + 20.000đ)
UPDATE movies
SET price_vip = price + 20000;

-- 1. Tạo bảng Sản phẩm (Bắp, Nước...)
CREATE TABLE products (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    price INT NOT NULL
);

-- 2. Tạo bảng Hóa đơn đồ ăn (Lưu riêng với vé cho đơn giản)
CREATE TABLE food_bills (
    id INT IDENTITY(1,1) PRIMARY KEY,
    staff_id INT,
    total_money INT,
    items_detail NVARCHAR(MAX), -- Lưu chuỗi text (VD: "2 Bắp, 1 Coca") cho nhanh
    created_at DATETIME
);

-- 3. Thêm dữ liệu mẫu (Có dùng Emoji cho đẹp 🍿🥤)
INSERT INTO products (name, price) VALUES (N'🍿 Bắp Rang Bơ (M)', 45000);
INSERT INTO products (name, price) VALUES (N'🍿 Bắp Phô Mai (L)', 55000);
INSERT INTO products (name, price) VALUES (N'🥤 Coca Cola (Tươi)', 25000);
INSERT INTO products (name, price) VALUES (N'🥤 Pepsi (Tươi)', 25000);
INSERT INTO products (name, price) VALUES (N'🍱 Combo Solo (1 Bắp + 1 Nước)', 60000);
INSERT INTO products (name, price) VALUES (N'🍱 Combo Couple (1 Bắp L + 2 Nước)', 90000);