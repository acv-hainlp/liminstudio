using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace limingallery.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime CreateOn { get; set; }
    }
}