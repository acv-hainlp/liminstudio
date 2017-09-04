using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace limingallery.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Comment của bạn")]
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }

    }
}