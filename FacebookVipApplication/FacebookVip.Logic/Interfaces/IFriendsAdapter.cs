using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model.Models;

namespace FacebookVip.Logic.Interfaces
{
    public interface IFriendsAdapter
    {
        Task<List<FriendModel>> GetUserFriendsAsync();

    }
}
