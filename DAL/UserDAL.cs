using DAL;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.DAL
{
    public class UserDAL
    {
        // Kiểm tra lại tên DbContext, nếu trong máy bạn là CinemaModelEntities thì sửa lại nhé
        private CinemaModel db = new CinemaModel();

        public user GetUserByUsername(string username)
        {
            return db.users.FirstOrDefault(u => u.username == username);
        }

        // --- HÀM CÒN THIẾU CỦA BẠN ĐÂY ---
        public user GetUserByEmail(string email)
        {
            return db.users.FirstOrDefault(u => u.email == email);
        }
        // ----------------------------------

        public List<user> GetAllStaff()
        {
            return db.users.ToList();
        }

        public void AddUser(user u)
        {
            db.users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUser(user u)
        {
            var exist = db.users.Find(u.id);
            if (exist != null)
            {
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

        public void DeleteUser(int id)
        {
            var u = db.users.Find(id);
            if (u != null)
            {
                db.users.Remove(u);
                db.SaveChanges();
            }
        }

        public user GetUserById(int id)
        {
            return db.users.Find(id);
        }
    }
}