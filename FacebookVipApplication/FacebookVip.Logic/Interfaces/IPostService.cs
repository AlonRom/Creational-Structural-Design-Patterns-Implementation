using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IPostService
    {
        Task<List<PostModel>> GetUserPostsAsync(User i_User);
    }
}
