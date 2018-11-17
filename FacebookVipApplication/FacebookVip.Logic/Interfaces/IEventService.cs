using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetUserEventsAsync(User i_User);
    }
}
