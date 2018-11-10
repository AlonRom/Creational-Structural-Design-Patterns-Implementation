using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model;

namespace FacebookVip.Logic.Interfaces
{
    public interface IPostService
    {
        Task<List<PostModel>> GetUserPostsAsync();
    }
}
