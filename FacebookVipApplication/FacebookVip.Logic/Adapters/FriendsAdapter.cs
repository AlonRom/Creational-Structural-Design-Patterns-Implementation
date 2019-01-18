using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;

namespace FacebookVip.Logic.Adapters
{
    public class FriendsAdapter : IFriendsAdapter
    {
        private readonly FriendService r_FriendsService;

        public FriendsAdapter()
        {
            r_FriendsService = new FriendService();
        }

        public Task<List<FriendModel>> GetUserFriendsAsync()
        {
            return Task.Run(() =>
            {
                LoginService loginService = LoginService.GetInstance();
                return r_FriendsService.GetUserFriendsAsync(loginService.LoggedInUser);
            });

        }
    }
}
