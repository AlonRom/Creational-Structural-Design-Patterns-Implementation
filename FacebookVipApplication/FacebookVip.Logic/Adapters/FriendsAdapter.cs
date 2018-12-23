using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Adapters
{
    public class FriendsAdapter : IFriendsAdapter
    {
        private readonly FriendService m_FriendsService;

        public FriendsAdapter()
        {
            m_FriendsService = new FriendService();
        }

        public Task<List<FriendModel>> GetUserFriendsAsync()
        {
            return Task.Run(() =>
            {
                LoginService loginService = LoginService.GetInstance();
                return m_FriendsService.GetUserFriendsAsync(loginService.LoggedInUser);
            });

        }
    }
}
