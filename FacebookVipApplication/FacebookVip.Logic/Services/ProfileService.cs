using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model.Models;

namespace FacebookVip.Logic.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILoginService r_LoginService;

        public ProfileService(ILoginService i_LoginService)
        {
            r_LoginService = i_LoginService;
        }

        public Task<ProfileModel> GetUserProfileAsync()
        {
            return Task.Run(() => new ProfileModel
            {
                Id = r_LoginService.LoggedInUser.Id,
                FirstName = r_LoginService.LoggedInUser.FirstName,
                LastName = r_LoginService.LoggedInUser.LastName,
                BirthDate = r_LoginService.LoggedInUser.Birthday,
                Email = r_LoginService.LoggedInUser.Email,
                Location = r_LoginService.LoggedInUser.Location
            });
        }
    }
}
