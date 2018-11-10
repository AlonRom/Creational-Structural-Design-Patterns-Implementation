using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Post = FacebookVip.Model.Post;

namespace FacebookVip.Logic.Interfaces
{
    public interface ILoginService
    {
        User LoggedInUser { get; set; }

        LoginResult Login();

        void Logout();

        Task<Profile> GetUserProfile();

        Task<List<Friend>> GetUserFriends();

        Task<List<Post>> GetUserPosts();
    }
}