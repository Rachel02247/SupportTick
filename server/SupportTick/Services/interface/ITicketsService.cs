using SupportTick.Models;

namespace SupportTick.Services
{
    public interface ITicketsService
    {
        List<Ticket> GetTickets();
        Ticket GetTicketById(int id);

        Ticket AddTicket(Ticket ticket);
    }
}
