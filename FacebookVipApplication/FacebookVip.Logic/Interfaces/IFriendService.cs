using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model;

namespace FacebookVip.Logic.Interfaces
{
    public interface IFriendService
    {
        Task<List<FriendModel>> GetUserFriendsAsync();
    }
}
