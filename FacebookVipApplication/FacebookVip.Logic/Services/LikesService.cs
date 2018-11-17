using System;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;

namespace FacebookVip.Logic.Services
{
    public class LikesService :ILikeService
    {
        private readonly ILoginService r_LoginService;

        public LikesService(ILoginService i_LoginService)
        {
            r_LoginService = i_LoginService;
        }

        public Task<Dictionary<string, int>> GetLikesHistogram(ObservableCollection<PostedItem> i_PostedItems)
        {
            return Task.Run(() =>
            {
                Dictionary<string, int> usersLikesHistogram = new Dictionary<string, int>();

                foreach (PostedItem item in i_PostedItems)
                {
                    FacebookObjectCollection<User> likes = item.LikedBy;
                    foreach (User like in likes)
                    {
                        string friendName = like.Name;
                        if (friendName == null) continue;
                        if (!usersLikesHistogram.ContainsKey(friendName))
                        {
                            usersLikesHistogram[friendName] = 0;
                        }
                        usersLikesHistogram[friendName] += 1;
                    }
                }

                setMockData(usersLikesHistogram);

                return usersLikesHistogram;
            });
        }

        private void setMockData(Dictionary<string, int> i_UsersLikesHistogram)
        {
            Random rnd = new Random();

            foreach(User friend in r_LoginService.LoggedInUser.Friends)
            {
                i_UsersLikesHistogram[friend.Name] = rnd.Next(0, 50);
            }
        }
    }
}
