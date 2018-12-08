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
        public Task<List<FriendModel>> GetUserFriendsAsync()
        {
            return Task.Run(() =>
            {
                LoginService loginService = LoginService.GetInstance();
                FriendsAdaptee friendsAdaptee = new FriendsAdaptee();
                Task<FacebookObjectCollection<User>> userFriends = friendsAdaptee.GetFriendsAsync(loginService.LoggedInUser);

                return userFriends.Result.Select(i_Friend =>
                  new FriendModel
                  {
                      Id = i_Friend.Id,
                      Name = i_Friend.Name,
                      ProfileImageUrl = i_Friend.PictureNormalURL
                  }).ToList();
            });

        }
    }
}
