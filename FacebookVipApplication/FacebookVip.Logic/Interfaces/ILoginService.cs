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

        LoginResult Login();

        void Logout();

        Task<ProfileModel> GetUserProfile();

        Task<List<FriendModel>> GetUserFriends();

        Task<List<PostModel>> GetUserPosts();
    }
}