using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IFriendService
    {
        Task<List<FriendModel>> GetUserFriendsAsync(User i_User);
        Task<FacebookObjectCollection<User>> GetFriendsAsync(User i_User);
    }
}
