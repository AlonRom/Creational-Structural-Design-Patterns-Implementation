using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class CheckinService : ICheckinService
    {
        public Task<List<Checkin>> GetUserCheckinsAsync(User i_User)
        {
            return Task.Run(() => i_User.Checkins.ToList());
        }
    }
}
