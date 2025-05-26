namespace SupportTick.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int StatuId { get; set; }
        public string Description { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set;}
        public string? Solution { get; set;}

    }
}
