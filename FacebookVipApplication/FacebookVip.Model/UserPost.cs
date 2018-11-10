using System;
using System.ComponentModel.DataAnnotations;

namespace FacebookVip.Model
{
    public class UserPost
    {
        public string Id { get; set; }

        [Display(Name = "", Order = 1)]
        public DateTime? UpdateTime { get; set; }

        [Display(Name = "", Order = 2)]
        public string Details { get; set; }
    }
}
