using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Can be edited by HoD. Viewable by all.

namespace ELearn.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }

        [DisplayName("Required Credit")]
        [Required(ErrorMessage = "Required credit cannot be empty.")]
        public int CreditRequired { get; set; }

        public bool Active { get; set; }
    }
}
