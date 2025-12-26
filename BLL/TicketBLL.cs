using DAL;
using DoAnFinal.DAL;
using System.Collections.Generic;

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
    }
}