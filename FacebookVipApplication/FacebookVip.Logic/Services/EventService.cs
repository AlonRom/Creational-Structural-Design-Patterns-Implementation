using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class EventService : IEventService
    {
        public Task<List<Event>> GetUserEventsAsync(User i_User)
        {
            return Task.Run(() => i_User.Events.ToList());
        }
    }
}
