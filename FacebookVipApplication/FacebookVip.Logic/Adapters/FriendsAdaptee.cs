using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Adapters
{
    public class FriendsAdaptee
    {
        public Task<FacebookObjectCollection<User>> GetFriendsAsync(User i_User)
        {
            return Task.Run(() =>
            {
                FacebookObjectCollection<User> usersList = i_User.Friends;
                return usersList;
            });
        }
    }
}
