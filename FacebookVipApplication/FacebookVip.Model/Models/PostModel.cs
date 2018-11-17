using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace FacebookVip.Model.Models
{
    public class PostModel
    {
        public string Id { get; set; }

        
        public Image UserImg { get; set; }

        [Display(Name = "", Order = 3)]
        public string UserName { get; set; }

        [Display(Name = "", Order = 2)]
        public DateTime? UpdateTime { get; set; }

        [Display(Name = "", Order = 4)]
        public string Details { get; set; }
        
    }
}
