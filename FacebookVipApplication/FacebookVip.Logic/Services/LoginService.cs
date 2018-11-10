using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Model;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Services
{
    public class LoginService : ILoginService
    {
        public User LoggedInUser { get; set; }
    
        public void Logout()
        {
            FacebookService.Logout(null);
        }

        public LoginResult Login()
        {
            // Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            // You can then save the result.AccessToken for future auto-connect to this user:
            #region Login Service

            return FacebookService.Login("1450160541956417",// (desig patter's "Design Patterns Course App 2.4" app)
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
        }

        public Task<UserProfile> GetUserProfile()
        {
            return Task.Run(() => new UserProfile
            {
                Id = LoggedInUser.Id,
                FirstName = LoggedInUser.FirstName,
                LastName = LoggedInUser.LastName,
                BirthDate = LoggedInUser.Birthday,
                Email = LoggedInUser.Email,
                Location = LoggedInUser.Location
            });
        }

        public Task<List<UserFriend>> GetUserFriends()
        {
            return Task.Run(
                () =>
                    {
                        return LoggedInUser.Friends.Select(i_Friend => 
                        new UserFriend
                            {
                                Id = i_Friend.Id,
                                Name = i_Friend.Name,
                                ProfileImageUrl = i_Friend.PictureNormalURL
                            }).ToList();
                    });
        }

        public Task<List<UserPost>> GetUserPosts()
        {
            return Task.Run(() =>
               {
                   return LoggedInUser.Posts.Select(i_Post =>
                    new UserPost
                       {
                         Id = i_Post.Id,
                         Details = getPostDetails(i_Post),
                         UpdateTime = i_Post.UpdateTime
                       }).ToList();
               });
        }

        private string getPostDetails(Post i_Post)
        {
            if (i_Post.Message != null)
            {
                return i_Post.Message;
            }
            if (i_Post.Caption != null)
            {
                return i_Post.Caption;
            }
            if(i_Post.Type != null)
            {
                return $"[{i_Post.Type}]";
            }
 
            return string.Empty; 
        }
    }
}
