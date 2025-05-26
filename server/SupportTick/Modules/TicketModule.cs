using Carter;
using SupportTick.Models;
using SupportTick.Services;

namespace SupportTick.Modules
{
    public class TicketModule : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/tickets", (ITicketsService ticketService) =>
            {
                var tickets = ticketService.GetTickets();
                
                return Results.Ok(tickets);
            });

            routes.MapGet("/tickets/{id}", (ITicketsService ticketService, int id) =>
            {
                var tickets = ticketService.GetTicketById(id);

                return Results.Ok(tickets);
            });

            routes.MapPost("/tickets", (ITicketsService ticketService, Ticket ticket) =>
            {
                var newTicket = ticketService.AddTicket(ticket);

                if(newTicket == null)
                {
                    return Results.Problem("FAILED to add ticket");
                }

                return Results.Ok(ticket);
            }).RequireAuthorization();

        }

    }
}