using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WepDevices.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required!")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Category Name should be less than 50 and more than 5 letters")]
        public string Name { get; set; }

    }
}