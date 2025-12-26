using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.DAL
{
    public class CustomerDAL
    {
        private CinemaModel db = new CinemaModel();

        // 1. Lấy tất cả khách hàng
        public List<customer> GetAllCustomers()
        {
            return db.customers.ToList();
        }

        // 2. Thêm khách hàng
        public void AddCustomer(customer c)
        {
            db.customers.Add(c);
            db.SaveChanges();
        }

        // 3. Sửa khách hàng
        public void UpdateCustomer(customer c)
        {
            var exist = db.customers.Find(c.id);
            if (exist != null)
            {
                exist.full_name = c.full_name;
                exist.phone_number = c.phone_number;
                // Admin có quyền sửa điểm tích lũy nếu cần
                exist.points = c.points;

                db.SaveChanges();
            }
        }

        // 4. Xóa khách hàng
        public void DeleteCustomer(int id)
        {
            var c = db.customers.Find(id);
            if (c != null)
            {
                db.customers.Remove(c);
                db.SaveChanges();
            }
        }

        // 5. Lấy theo ID
        public customer GetCustomerById(int id)
        {
            return db.customers.Find(id);
        }
    }
}