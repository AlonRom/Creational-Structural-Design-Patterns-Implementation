using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface ILikeService
    {
        Task<Dictionary<string, int>> GetLikesHistogram(ObservableCollection<PostedItem> i_PostedItems);
    }
}
