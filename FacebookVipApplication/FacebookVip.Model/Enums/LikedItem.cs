using System.ComponentModel.DataAnnotations;

namespace FacebookVip.Model.Enums
{
    public enum eLikedItem
    {
        [Display(Name = "Photos", Order = 1)]
        PhotosTaggedIn,

        [Display(Name = "Posts", Order = 2)]
        Posts,

        [Display(Name = "Albums", Order = 3)]
        Albums
    }
}
