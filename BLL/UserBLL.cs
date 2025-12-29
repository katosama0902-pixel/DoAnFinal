using DAL;
using DoAnFinal.DAL;
using DoAnFinal.Helper;
using System;
using System.Collections.Generic;

namespace DoAnFinal.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        // Giữ nguyên hàm Login cũ...
        public user Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;
            var user = userDAL.GetUserByUsername(username);
            if (user == null) return null;
            string passHash = HashHelper.HashPassword(password);
            if (user.password == passHash && user.status == "Active") return user;
            return null;
        }

        // --- CÁC HÀM MỚI ---

        public List<user> GetListStaff()
        {
            return userDAL.GetAllStaff();
        }

        public string AddUser(user u, string rawPassword)
        {
            // 1. Kiểm tra username đã tồn tại chưa
            if (userDAL.GetUserByUsername(u.username) != null)
            {
                return "Tên đăng nhập đã tồn tại!";
            }

            // 2. Mã hóa mật khẩu
            u.password = HashHelper.HashPassword(rawPassword);
            u.date_reg = DateTime.Now;

            userDAL.AddUser(u);
            return "Success";
        }

        public string UpdateUser(user u, string newPassword)
        {
            // Nếu có nhập pass mới thì mã hóa, không thì để null (DAL sẽ giữ pass cũ)
            if (!string.IsNullOrEmpty(newPassword))
            {
                u.password = HashHelper.HashPassword(newPassword);
            }
            else
            {
                u.password = null; // Báo hiệu cho DAL biết là không đổi pass
            }

            userDAL.UpdateUser(u);
            return "Success";
        }

        public void DeleteUser(int id)
        {
            userDAL.DeleteUser(id);
        }

        public user GetUserById(int id)
        {
            return userDAL.GetUserById(id);
        }

        public user GetUserByEmail(string email)
        {
            return userDAL.GetUserByEmail(email);
        }

        // Hàm cập nhật mật khẩu (dùng lại hàm UpdateUser cũ hoặc viết mới cho gọn)
        public void ResetPassword(int userId, string newPass)
        {
            var u = userDAL.GetUserById(userId);
            if (u != null)
            {
                u.password = DoAnFinal.HashHelper.HashPassword(newPass);
                userDAL.UpdateUser(u);
            }
        }
    }
}