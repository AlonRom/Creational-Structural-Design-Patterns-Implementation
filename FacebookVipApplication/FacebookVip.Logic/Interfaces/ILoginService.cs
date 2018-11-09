using System.Threading.Tasks;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface ILoginService
    {
        User LoggedInUser { get; set; }

        UserProfile UserProfile { get; set; }

        LoginResult Login();

        Task LogOut();

        Task SetUserData();
    }
}