using DAL;
using DoAnFinal.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.BLL
{
    public class CustomerBLL
    {
        private CustomerDAL cusDAL = new CustomerDAL();

        public List<customer> GetListCustomer()
        {
            return cusDAL.GetAllCustomers();
        }

        public string AddCustomer(customer c)
        {
            // Kiểm tra trùng số điện thoại (Logic quan trọng)
            var all = cusDAL.GetAllCustomers();
            if (all.Any(x => x.phone_number == c.phone_number))
            {
                return "Số điện thoại này đã tồn tại!";
            }

            cusDAL.AddCustomer(c);
            return "Success";
        }

        public string UpdateCustomer(customer c)
        {
            // Khi sửa, nếu đổi SĐT thì phải check xem có trùng với người KHÁC không
            var all = cusDAL.GetAllCustomers();
            // Tìm người có cùng SĐT nhưng ID khác người đang sửa
            if (all.Any(x => x.phone_number == c.phone_number && x.id != c.id))
            {
                return "Số điện thoại này đã thuộc về người khác!";
            }

            cusDAL.UpdateCustomer(c);
            return "Success";
        }

        public void DeleteCustomer(int id)
        {
            cusDAL.DeleteCustomer(id);
        }

        public customer GetCustomerById(int id)
        {
            return cusDAL.GetCustomerById(id);
        }
    }
}