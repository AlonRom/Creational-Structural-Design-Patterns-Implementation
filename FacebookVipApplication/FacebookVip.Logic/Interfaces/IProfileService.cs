using System.Threading.Tasks;
using FacebookVip.Model;

namespace FacebookVip.Logic.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileModel> GetUserProfileAsync();
    }
}
