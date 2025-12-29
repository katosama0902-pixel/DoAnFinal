using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.BLL
{
    // Class chứa dữ liệu để hiển thị lên Bảng xếp hạng
    public class StaffRevenueDTO
    {
        public int StaffId { get; set; }
        public string Username { get; set; }
        public decimal TicketRevenue { get; set; } // Tiền vé
        public decimal FoodRevenue { get; set; }   // Tiền bắp nước
        public decimal TotalRevenue { get { return TicketRevenue + FoodRevenue; } } // Tổng cộng
    }

    public class ReportBLL
    {
        // Hàm lấy danh sách xếp hạng nhân viên
        public List<StaffRevenueDTO> GetStaffLeaderboard()
        {
            using (var db = new CinemaModel())
            {
                // 1. Lấy danh sách tất cả nhân viên (Role = Staff)
                var staffs = db.users.Where(u => u.role == "Staff").ToList();

                // 2. Tính tiền VÉ cho từng nhân viên
                var ticketSales = db.tickets
                    .GroupBy(t => t.staff_id)
                    .Select(g => new { StaffId = g.Key, Total = g.Sum(t => t.price) })
                    .ToList();

                // 3. Tính tiền BẮP NƯỚC cho từng nhân viên
                var foodSales = db.food_bills
                    .GroupBy(f => f.staff_id)
                    .Select(g => new { StaffId = g.Key, Total = g.Sum(f => (decimal?)f.total_money) ?? 0 })
                    .ToList();

                // 4. Gộp dữ liệu (Join in-memory)
                List<StaffRevenueDTO> leaderboard = new List<StaffRevenueDTO>();

                foreach (var s in staffs)
                {
                    var dto = new StaffRevenueDTO();
                    dto.StaffId = s.id;
                    dto.Username = s.username;

                    // Tìm doanh thu vé của nhân viên này (nếu ko có thì = 0)
                    var tSale = ticketSales.FirstOrDefault(x => x.StaffId == s.id);
                    dto.TicketRevenue = tSale != null ? tSale.Total : 0;

                    // Tìm doanh thu ăn uống
                    var fSale = foodSales.FirstOrDefault(x => x.StaffId == s.id);
                    dto.FoodRevenue = fSale != null ? fSale.Total : 0;

                    leaderboard.Add(dto);
                }

                // 5. Sắp xếp giảm dần theo Tổng doanh thu
                return leaderboard.OrderByDescending(x => x.TotalRevenue).ToList();
            }
        }
    }
}