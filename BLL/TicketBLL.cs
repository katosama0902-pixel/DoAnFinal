using DAL; // Namespace chứa CinemaModel
using DoAnFinal.DAL; // Namespace chứa TicketDAL
using System.Collections.Generic;
using System.Data; // [MỚI] Cần cái này để dùng DataTable
using System.Linq; // [MỚI] Cần cái này để dùng LINQ (from... select)

namespace DoAnFinal.BLL
{
    public class TicketBLL
    {
        private TicketDAL ticketDAL = new TicketDAL();

        public List<int> GetBookedSeats(string movieId)
        {
            return ticketDAL.GetBookedSeats(movieId);
        }

        public void BuyTicket(ticket t)
        {
            ticketDAL.AddTicket(t);
        }

        public DataTable GetTicketHistory(string keyword)
        {
            // [SỬA LỖI]: Bỏ chữ "DAL." đi, chỉ cần new CinemaModel() là được
            // Vì mình đã "using DAL;" ở trên đầu rồi
            using (var db = new CinemaModel())
            {
                // Join các bảng để lấy thông tin chi tiết
                var query = from t in db.tickets
                            join m in db.movies on t.movie_id equals m.movie_id
                            join c in db.customers on t.customer_id equals c.id into tc
                            from subC in tc.DefaultIfEmpty() // Left Join (vì có thể khách vãng lai)
                            where m.movie_name.Contains(keyword) ||
                                  (subC != null && subC.phone_number.Contains(keyword)) ||
                                  t.id.ToString() == keyword
                            select new
                            {
                                Mã_Vé = t.id,
                                Phim = m.movie_name,
                                Ghế = t.seat_number,
                                Giá = t.price,
                                Ngày_Mua = t.created_at,
                                Khách_Hàng = (subC == null) ? "Vãng lai" : subC.full_name,
                                SĐT = (subC == null) ? "" : subC.phone_number
                            };

                // Chuyển sang DataTable để đổ vào DataGridView dễ hơn
                var result = query.OrderByDescending(x => x.Ngày_Mua).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Vé");
                dt.Columns.Add("Phim");
                dt.Columns.Add("Ghế");
                dt.Columns.Add("Giá");
                dt.Columns.Add("Ngày Mua");
                dt.Columns.Add("Khách Hàng");
                dt.Columns.Add("SĐT");

                foreach (var item in result)
                {
                    dt.Rows.Add(item.Mã_Vé, item.Phim, item.Ghế,
                                string.Format("{0:N0}", item.Giá),
                                string.Format("{0:dd/MM/yyyy HH:mm}", item.Ngày_Mua),
                                item.Khách_Hàng, item.SĐT);
                }
                return dt;
            }
        }

        public bool RefundTicket(int ticketId)
        {
            using (var db = new CinemaModel())
            {
                // 1. Tìm vé theo ID
                var t = db.tickets.Find(ticketId);

                // 2. Nếu tìm thấy thì xóa
                if (t != null)
                {
                    db.tickets.Remove(t); // Xóa khỏi DB
                    db.SaveChanges();     // Lưu thay đổi
                    return true; // Xóa thành công
                }

                return false; // Không tìm thấy vé (hoặc lỗi)
            }
        }

        public bool ResellTicket(int ticketId, int customerId)
        {
            using (var db = new CinemaModel())
            {
                // 1. Tìm vé
                var ticket = db.tickets.Find(ticketId);
                if (ticket == null) return false;

                // 2. Kiểm tra quy tắc: Không được bán lại vé của quá khứ
                // (Cần join bảng Lịch chiếu/Phim để lấy giờ chiếu, ở đây mình giả định check ngày tạo cho đơn giản
                // hoặc bạn có thể mở rộng check show_time nếu DB có liên kết)
                // Tạm thời cho phép bán mọi vé chưa dùng.

                // 3. Tính toán tiền hoàn lại (90% giá gốc)
                decimal originalPrice = (decimal)ticket.price;
                decimal refundAmount = originalPrice * 0.9m; // Giữ lại 90%

                // 4. Cộng tiền này vào ĐIỂM (Points) của khách hàng
                // (Giả sử 1 điểm = 1 VND để đơn giản, hoặc quy đổi tùy bạn)
                var customer = db.customers.Find(customerId);
                if (customer != null)
                {
                    customer.points = (customer.points ?? 0) + (int)refundAmount;
                }

                // 5. Xóa vé (Để ghế trống cho người khác mua)
                db.tickets.Remove(ticket);

                db.SaveChanges();
                return true;
            }
        }
    }
}