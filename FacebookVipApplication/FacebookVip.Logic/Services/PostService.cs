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
        //private readonly ILoginService r_LoginService;

        public PostService()
        {
            //r_LoginService = i_LoginService;
        }

        // This function should get a user.
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
