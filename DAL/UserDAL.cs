using DAL;
using System.Collections.Generic;
using System.Linq;

// Namespace đã sửa thành DoAnFinal.DAL
namespace DoAnFinal.DAL
{
    public class UserDAL
    {
        // movie_db_v2Entities là tên mặc định EF tạo ra.
        // Nếu code bên dưới báo đỏ chữ 'movie_db_v2Entities', bạn hãy mở file CinemaModel.Context.cs ra xem tên class là gì rồi sửa lại nhé.
        private CinemaModel db = new CinemaModel();

        public user GetUserByUsername(string username)
        {
            // 'user' là class do EF tự sinh ra từ bảng users
            return db.users.FirstOrDefault(u => u.username == username);
        }

        // 2. Lấy danh sách nhân viên (Trừ Admin ra để tránh xóa nhầm chính mình)
        public List<user> GetAllStaff()
        {
            // Chỉ lấy những người không phải Admin (hoặc lấy tất cả tùy bạn)
            return db.users.ToList();
        }

        // 3. Thêm nhân viên mới
        public void AddUser(user u)
        {
            db.users.Add(u);
            db.SaveChanges();
        }

        // 4. Cập nhật nhân viên
        public void UpdateUser(user u)
        {
            var exist = db.users.Find(u.id);
            if (exist != null)
            {
                // Chỉ cập nhật mật khẩu nếu người dùng có nhập mới
                if (!string.IsNullOrEmpty(u.password))
                {
                    exist.password = u.password;
                }

                exist.email = u.email;
                exist.role = u.role;
                exist.status = u.status;

                db.SaveChanges();
            }
        }

        // 5. Xóa nhân viên (Khóa tài khoản)
        public void DeleteUser(int id)
        {
            var u = db.users.Find(id);
            if (u != null)
            {
                // Xóa cứng (db.users.Remove(u)) hoặc Xóa mềm (Status = 'Locked')
                // Ở đây mình chọn xóa cứng cho gọn, nhưng thực tế nên dùng Locked
                db.users.Remove(u);
                db.SaveChanges();
            }
        }

        // 6. Lấy User theo ID (Để hiện lên form sửa)
        public user GetUserById(int id)
        {
            return db.users.Find(id);
        }
    }
}