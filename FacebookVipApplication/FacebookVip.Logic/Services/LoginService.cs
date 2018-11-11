using FacebookVip.Logic.Interfaces;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class LoginService : ILoginService
    {
        private static readonly object sr_InstanceLock = new object();
        private static LoginService s_LoginService;

        public User LoggedInUser { get; set; }

        private LoginService() { }

        public static LoginService GetInstance()
        {
            if (s_LoginService == null)
            {
                lock (sr_InstanceLock)
                {
                    if (s_LoginService == null)
                    {
                        s_LoginService = new LoginService();
                    }
                }
            }

            return s_LoginService;
        }

        public void Logout()
        {
            FacebookService.Logout(null);
        }

        public LoginResult Login()
        {
            if (LoggedInUser != null)
            {
                // user already logged in
                return null;
            }

            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();

            #region Login Service

            LoginResult loginParams = FacebookService.Login("1450160541956417",// (desig patter's "Design Patterns Course App 2.4" app)
                    "public_profile",
                    //"user_education_history",
                    "user_birthday",
                    //"user_actions.video",
                    //"user_actions.news",
                    //"user_actions.music",
                    //"user_actions.fitness",
                    //"user_actions.books",
                    //"user_about_me",
                    "user_friends",
                    //"publish_actions",
                    //"user_events",
                    //"user_games_activity",
                    //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
                    "user_hometown",
                    "user_likes",
                    //"user_location",
                    //"user_managed_groups",
                    "user_photos",
                    "user_posts",
                    //"user_relationships",
                    //"user_relationship_details",
                    //"user_religion_politics",

                    //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
                    "user_tagged_places"
                //"user_videos",
                //"user_website",
                //"user_work_history",
                //"read_custom_friendlists",

                // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                //"read_page_mailboxes",
                // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
                // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
                //"manage_pages",
                //"publish_pages",
                //"publish_actions"

                //"rsvp_event"
                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference

            #endregion

            if (appAppConfig.StayLogedIn == true)
            {
                appAppConfig.LastAccessTocken = loginParams.AccessToken;
            }

            return loginParams;
        }
    }
}
