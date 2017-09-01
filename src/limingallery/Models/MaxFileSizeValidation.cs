using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace limingallery.Models
{
    public class MaxFileSizeValidation : ValidationAttribute
    {
        private readonly int _maxFileSize = (int)4e+6;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var post = (Post)validationContext.ObjectInstance;
            if (post.File.ContentLength > _maxFileSize)
            {
                return new ValidationResult("Tranh bạn tải phải nhỏ hơn 2mb");
            }

            return ValidationResult.Success;
        }
    }
}