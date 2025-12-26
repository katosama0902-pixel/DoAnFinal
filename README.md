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