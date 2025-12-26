using DAL;
using DoAnFinal.DAL;
using System.Collections.Generic;

namespace DoAnFinal.BLL
{
    public class DashboardBLL
    {
        private DashboardDAL dashDAL = new DashboardDAL();

        public decimal GetTotalRevenue() => dashDAL.GetTotalRevenue();
        public int GetTotalTickets() => dashDAL.GetTotalTickets();
        public int GetTotalStaff() => dashDAL.GetTotalStaff();

        public List<TopMovieDTO> GetTopMovies() => dashDAL.GetTopMoviesRevenue();
    }
}