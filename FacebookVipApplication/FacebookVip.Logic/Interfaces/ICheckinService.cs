using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface ICheckinService
    {
        Task<List<Checkin>> GetUserCheckinsAsync(User i_User);
    }
}
