using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model;

namespace FacebookVip.Logic.Services
{
    public class FriendService : IFriendService
    {
        private readonly ILoginService r_LoginService;

        public FriendService(ILoginService i_LoginService)
        {
            r_LoginService = i_LoginService;
        }

        public Task<List<FriendModel>> GetUserFriendsAsync()
        {
            return Task.Run(() =>
                  {
                      return r_LoginService.LoggedInUser.Friends.Select(i_Friend =>
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
