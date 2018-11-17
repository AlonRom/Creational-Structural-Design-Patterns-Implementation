using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class FriendService : IFriendService
    {
        public FriendService()
        {
        }

        public Task<List<FriendModel>> GetUserFriendsAsync(User i_User)
        {
            return Task.Run(() =>
                  {
                      return i_User.Friends.Select(i_Friend =>
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
