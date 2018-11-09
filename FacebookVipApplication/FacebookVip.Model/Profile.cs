using System.ComponentModel.DataAnnotations;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Model
{
    public class UserProfile
    {
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "BirthDate")]
        public string BirthDate { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Location")]
        public City Location { get; set; }
    }
}
