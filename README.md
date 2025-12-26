# 🎬 Cinema Management System (Đồ án Quản lý Rạp Chiếu Phim)

Phần mềm quản lý rạp chiếu phim được xây dựng bằng **C# WinForms** theo mô hình **3 lớp (3-Layer Architecture)**, sử dụng **Entity Framework** và cơ sở dữ liệu **SQL Server**.

![Banner](https://img.shields.io/badge/Language-C%23-blue) ![Banner](https://img.shields.io/badge/Framework-.NET_4.7.2-purple) ![Banner](https://img.shields.io/badge/Database-SQL_Server-red)

## 🚀 Tính Năng Chính

### 1. Phân hệ Admin (Quản trị viên)
* **Đăng nhập bảo mật:** Phân quyền hệ thống, mã hóa mật khẩu MD5.
* **Dashboard (Thống kê):**
    * Xem tổng quan doanh thu, số vé bán ra, tổng nhân viên.
    * Biểu đồ cột (Chart) hiển thị Top 5 phim doanh thu cao nhất.
* **Quản lý Phim:**
    * Xem danh sách, tìm kiếm phim.
    * Thêm/Sửa/Xóa phim.
    * Upload Poster phim từ máy tính.
* **Quản lý Nhân sự:** Thêm, sửa, xóa, khóa tài khoản nhân viên.
* **Quản lý Khách hàng:** Xem danh sách thành viên và điểm tích lũy.

### 2. Phân hệ Staff (Nhân viên bán vé)
* **Giao diện POS (Point of Sale):** Giao diện bán hàng hiện đại, tối ưu thao tác.
* **Bán vé Real-time:**
    * Chọn phim, xem sơ đồ ghế trực quan.
    * Trạng thái ghế (Trống/Đã đặt) cập nhật theo thời gian thực.
    * Tích hợp chọn Khách hàng thành viên để tích điểm.
* **In Hóa Đơn:** Tự động tạo và xem trước hóa đơn thanh toán (Print Preview).
* **Cá nhân:** Đổi mật khẩu nhân viên.

---

## 🛠 Công Nghệ Sử Dụng
* **Ngôn ngữ:** C# (Windows Forms Application).
* **Database:** SQL Server.
* **ORM:** Entity Framework (Database First approach).
* **Architecture:** Mô hình 3 lớp (GUI - BLL - DAL).
* **Công cụ khác:**
    * `System.Drawing.Printing`: Xử lý in ấn hóa đơn.
    * `System.Windows.Forms.DataVisualization`: Vẽ biểu đồ thống kê.
    * MD5 Hashing: Bảo mật mật khẩu.

---

## ⚙️ Hướng Dẫn Cài Đặt (Installation)

### Bước 1: Clone dự án
Clone dự án về máy của bạn:
```bash
git clone [https://github.com/username-cua-ban/Ten-Project.git](https://github.com/username-cua-ban/Ten-Project.git)

Bước 2: Cài đặt Cơ sở dữ liệu
Mở SQL Server Management Studio (SSMS).

Tạo một database mới tên là: movie_db_v2 (Hoặc tên tùy ý).

Mở file database_script.sql (nằm trong thư mục gốc của project) và chạy (Execute) để tạo bảng và dữ liệu mẫu.

Bước 3: Cấu hình kết nối (Quan trọng)
Mở Project bằng Visual Studio (Khuyên dùng VS 2019 hoặc 2022).

Tìm file App.config ở thư mục gốc (hoặc trong project GUI và DAL).

Tìm thẻ <connectionStrings>.

Sửa lại phần data source thành tên Server của bạn.
Lưu ý: Thay TEN_MAY_CUA_BAN\SQLEXPRESS bằng Server Name trong SQL của bạn.

Bước 4: Chạy dự án
Nhấn F5 hoặc nút Start trong Visual Studio để chạy chương trình.

Project sẽ tự động Build và mở Form Đăng nhập.

👤 Tài Khoản Mặc Định (Default Accounts)
Bạn có thể sử dụng các tài khoản có sẵn trong DB script để đăng nhập:

Vai Trò,Username,Password
Admin,admin,admin123
Staff,staff,staff123
Staff,staff2,123

📂 Cấu Trúc Dự Án (Project Structure)
GUI (Graphical User Interface): Chứa các Form giao diện và logic hiển thị.

BLL (Business Logic Layer): Xử lý nghiệp vụ, tính toán, kiểm tra dữ liệu trước khi đẩy xuống DAL.

DAL (Data Access Layer): Chứa Entity Framework Model, tương tác trực tiếp với SQL Server.

DTO/Helper: Các lớp hỗ trợ (Mã hóa, Biến toàn cục Session...).

📸 Hình Ảnh Demo (Screenshots)
(Bạn có thể thêm ảnh chụp màn hình Dashboard hoặc Giao diện bán vé vào đây sau)

🤝 Đóng Góp
Mọi đóng góp đều được hoan nghênh. Vui lòng mở Pull Request hoặc tạo Issue nếu bạn tìm thấy lỗi.