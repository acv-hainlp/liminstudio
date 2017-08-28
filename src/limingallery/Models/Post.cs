using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace limingallery.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsActive { get; set; }

        //Add Postype Belongs-To
        public int PostTypeId { get; set; }
        public PostType PostType { get; set; }
    }
}