using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.DAL
{
    public class DashboardDAL
    {
        private CinemaModel db = new CinemaModel();

        // 1. Tính tổng doanh thu toàn rạp (Cộng cột price trong bảng tickets)
        public decimal GetTotalRevenue()
        {
            // Nếu chưa bán vé nào thì trả về 0
            var sum = db.tickets.Sum(t => (decimal?)t.price);
            return sum ?? 0;
        }

        // 2. Đếm tổng số vé đã bán
        public int GetTotalTickets()
        {
            return db.tickets.Count();
        }

        // 3. Đếm tổng số nhân viên
        public int GetTotalStaff()
        {
            return db.users.Count(u => u.role == "Staff");
        }

        // 4. Lấy Top 5 phim có doanh thu cao nhất (Dùng cho Biểu đồ)
        public List<TopMovieDTO> GetTopMoviesRevenue()
        {
            // Join bảng Tickets với Movies để lấy tên phim
            var query = from t in db.tickets
                        join m in db.movies on t.movie_id equals m.movie_id
                        group t by m.movie_name into g
                        select new TopMovieDTO
                        {
                            MovieName = g.Key,
                            TotalRevenue = g.Sum(x => x.price)
                        };

            // Sắp xếp giảm dần và lấy 5 phim đầu
            return query.OrderByDescending(x => x.TotalRevenue).Take(5).ToList();
        }
    }
}