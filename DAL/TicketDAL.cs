using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.DAL
{
    public class TicketDAL
    {
        private CinemaModel db = new CinemaModel();

        // 1. Lấy danh sách số ghế ĐÃ BÁN của một phim cụ thể
        public List<int> GetBookedSeats(string movieId)
        {
            // Lấy cột seat_number từ bảng tickets theo movie_id
            return db.tickets
                     .Where(t => t.movie_id == movieId)
                     .Select(t => t.seat_number)
                     .ToList();
        }

        // 2. Lưu vé xuống Database
        public void AddTicket(ticket t)
        {
            db.tickets.Add(t);
            db.SaveChanges();
        }
    }
}