using System.ComponentModel.DataAnnotations;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Model
{
    public class UserProfile
    {
        public string Id { get; set; }

        [Display(Name = "First Name", Order = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name", Order = 2)]
        public string LastName { get; set; }

        [Display(Name = "BirthDate", Order = 3)]
        public string BirthDate { get; set; }

        [Display(Name = "Email", Order = 4)]
        public string Email { get; set; }

        [Display(Name = "Location", Order = 5)]
        public City Location { get; set; }
    }
}
