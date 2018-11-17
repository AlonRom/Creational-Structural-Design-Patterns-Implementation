using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class ProfileService : IProfileService
    {
        public ProfileService()
        {
            
        }

        public Task<ProfileModel> GetUserProfileAsync(User i_User)
        {
            return Task.Run(() => new ProfileModel
            {
                Id = i_User.Id,
                FirstName = i_User.FirstName,
                LastName = i_User.LastName,
                BirthDate = i_User.Birthday,
                Email = i_User.Email,
                Location = i_User.Location
            });
        }
    }
}
