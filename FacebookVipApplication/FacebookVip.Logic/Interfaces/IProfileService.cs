using System.Threading.Tasks;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileModel> GetUserProfileAsync(User i_User);
    }
}
