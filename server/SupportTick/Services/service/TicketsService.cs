using Microsoft.AspNetCore.Authentication.Cookies;
using SupportTick.DataAccess;
using SupportTick.Models;
using static System.Object;

namespace SupportTick.Services.service
{
    public class TicketsService : ITicketsService
    {
        private readonly DataContext _context;

        public TicketsService(DataContext context)
        {
            _context = context;
        }

        public List<Ticket> GetTickets() => _context.Tickets.ToList();
        public Ticket GetTicketById(int id)
        {
            return _context.Tickets.SingleOrDefault(t => t.TicketId == id);
        }

        public Ticket AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveData();
            return ticket;
        }

        
    }
}
