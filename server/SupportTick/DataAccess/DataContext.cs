using SupportTick.Models;
using System.Text.Json;

using System;

namespace SupportTick.DataAccess
{
  
    public class DataContext : IDataContext
    {
        public List<User> Users { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Ticket> Tickets { get; set; }

        public TicketDTO LoadData()
        {
      
            string jsonString = File.ReadAllText("data.json");
            var data = JsonSerializer.Deserialize<TicketDTO>(jsonString);
           
            return data;
        }


        public bool SaveData()
        {

            return true;
        }
    }
}
