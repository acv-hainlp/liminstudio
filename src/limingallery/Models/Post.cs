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

        public string UserId { get; set; } //convention FK // must User not Users
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của tranh")]
        [Display(Name = "Tiêu đề của tranh")]
        public string Title { get; set; }

        [Display(Name = "Mô tả ngắn của tranh")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn tranh để tải lên")][NotMapped]
        [Display(Name ="Tải tranh")]
        [MaxFileSizeValidation] //custom validation
        public HttpPostedFileBase File { get; set; }

        public string ImageName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreateOn { get; set; }

        public string ImageUrl()
        {
            var path = "/Content/Images/uploads/" + ImageName;
            return path;
        }
    }
}