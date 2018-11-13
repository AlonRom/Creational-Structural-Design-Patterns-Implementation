using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IPostService
    {
        Task<List<PostModel>> GetUserPostsAsync(User i_user);
    }
}
