using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;


namespace limingallery.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        //Add Postype Belongs-To
        //public int PostTypeId { get; set; }
        //public PostType PostType { get; set; }

        public string UserId { get; set; } //convention FK // must User not Users
        public ApplicationUser User { get; set; }

        [Required][NotMapped]
        public HttpPostedFileBase File { get; set; }

        public string ImageUrl()
        {
            var fileName = Title.ToLower() + ".png";
            fileName = fileName.Replace(" ", "");
            var path = "/Content/Images/uploads/" + fileName;
            return path;
        }
    }
}