using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface ILoginService
    {
        User LoggedInUser { get; set; }

        LoginResult Login();

        void Logout();
    }
}