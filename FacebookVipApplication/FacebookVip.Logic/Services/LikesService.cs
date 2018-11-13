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
        public Task<Dictionary<string, int>> GetLikesHistogram(ObservableCollection<PostedItem> i_PostedItems)
        {
            return Task.Run(() =>
            {
                Dictionary<string, int> usersLikesHistogram = new Dictionary<string, int>();

                foreach (PostedItem item in i_PostedItems)
                {
                    FacebookObjectCollection<User> likes = item.LikedBy;
                    foreach (var like in likes)
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

                usersLikesHistogram = getMockData();

                return usersLikesHistogram;
            });
        }

        private Dictionary<string, int> getMockData()
        {
            Random rnd = new Random();

            return new Dictionary<string, int>
                       {
                            {"Igor Gumush", rnd.Next(0, 50)},
                            {"Alon Rom", rnd.Next(0, 50)},
                            {"Muhamad Ali", rnd.Next(0, 50)},
                            {"Madona", rnd.Next(0, 50) },
                            {"Shula Mokshim", rnd.Next(0, 50) },
                            {"Bibi", rnd.Next(0, 50) },
                            {"Wolverine", rnd.Next(0, 50) },
                            {"Batman", rnd.Next(0, 50) },
                            {"Spiderman", rnd.Next(0, 50) },
                            {"Venom", rnd.Next(0, 50) },
                            {"The Godfather", rnd.Next(0, 50) },
                            {"Messi", rnd.Next(0, 50) },
                            {"Ronaldo", rnd.Next(0, 50) },
                       };
        }
    }
}
