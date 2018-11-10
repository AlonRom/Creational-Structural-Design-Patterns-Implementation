using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookVip.Logic.Services
{
    public class LikesStatisticsService
    {
        public static Task<Dictionary<string, int>> getLikesHistogram(ObservableCollection<PostedItem> items)
        {
            return Task.Run(() =>
            {
                var users_likes_histogram = new Dictionary<string, int>();

                foreach (var item in items)
                {
                    var likes = item.LikedBy;
                    foreach (var like in likes)
                    {
                        string friend_name = like.Name;
                        if (friend_name == null) continue;
                        if (!users_likes_histogram.ContainsKey(friend_name))
                        {
                            users_likes_histogram[friend_name] = 0;
                        }
                        users_likes_histogram[friend_name] += 1;
                    }
                }
                return users_likes_histogram;
            });
        }

    }
}
