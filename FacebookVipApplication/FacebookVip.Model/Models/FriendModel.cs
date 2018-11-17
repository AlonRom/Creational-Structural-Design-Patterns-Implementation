using System.ComponentModel.DataAnnotations;

namespace FacebookVip.Model.Models
{
    public class FriendModel 
    {
        public string Id { get; set; }

        [Display(Name = "Profile Image", Order = 1)]
        public string ProfileImageUrl { get; set; }

        [Display(Name = "Name", Order = 2)]
        public string Name { get; set; }
    }
}
