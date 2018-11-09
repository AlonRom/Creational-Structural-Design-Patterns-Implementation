using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface ILoginService
    {
        User LoggedInUser { get; set; }

        Profile Profile { get; set; }

        IEnumerable<Friend> Friends { get; set; }

        LoginResult Login();

        void Logout();

        Task<Profile> GetUserProfile();

        Task<List<Friend>> GetUserFriends();
    }
}