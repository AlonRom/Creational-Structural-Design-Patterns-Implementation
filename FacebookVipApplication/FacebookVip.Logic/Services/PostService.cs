using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class PostService : IPostService
    {
        public Task<List<PostModel>> GetUserPostsAsync(User i_User)
        {
            return Task.Run(() =>
            {
                return i_User.Posts.Select(i_Post =>
                 new PostModel
                 {
                     Id = i_Post.Id,
                     UserName = i_User.Name,
                     UserImg = i_User.ImageSmall,
                     Details = getPostDetails(i_Post),
                     UpdateTime = i_Post.UpdateTime
                 }).ToList();
            });
        }

        private static int PostId { get; set; }
        public List<PostModel> GetUserPostsMockData(User i_User)
        {
            var postsList = new List<PostModel>();
            var rnd = new Random();

            for (int i = 0; i < rnd.Next(1,5); i++)
            {
                postsList.Add(new PostModel
                {
                    Id = "" + PostId++,
                    UserName = i_User.Name,
                    UserImg = i_User.ImageSmall,
                    Details = "Mock Post " + PostId, //getPostDetails(i_Post),
                    UpdateTime = DateTime.Now
                });
            }
            return postsList;
        }

        private string getPostDetails(Post i_Post)
        {
            if (i_Post.Message != null)
            {
                return i_Post.Message;
            }
            if (i_Post.Caption != null)
            {
                return i_Post.Caption;
            }
            if (i_Post.Type != null)
            {
                return $"[{i_Post.Type}]";
            }

            return string.Empty;
        }

    }
}
