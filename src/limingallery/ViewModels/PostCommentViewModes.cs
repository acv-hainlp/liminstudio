using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using limingallery.Models;

namespace limingallery.ViewModels
{
    public class PostCommentViewModes
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }

    }
}