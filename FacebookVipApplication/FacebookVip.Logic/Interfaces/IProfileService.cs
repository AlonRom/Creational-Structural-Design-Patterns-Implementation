using System.Threading.Tasks;
using FacebookVip.Model.Models;

namespace FacebookVip.Logic.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileModel> GetUserProfileAsync();
    }
}
