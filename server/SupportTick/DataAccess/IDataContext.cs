using SupportTick.Models;

namespace SupportTick.DataAccess
{
    public interface IDataContext
    {
         TicketDTO LoadData();
         bool SaveData();
    }
}
