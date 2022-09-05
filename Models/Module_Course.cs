using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

// Connection must be made by HoD/Subject Co

namespace ELearn.Models
{
    public class Module_Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Course ID cannot be empty.")]
        [DisplayName("Course ID")]
        [ForeignKey("Courses")]
        public int CourseID { get; set; }

        [NotMapped]
        public List<SelectListItem> Courses { set; get; }

        [Required(ErrorMessage = "Module Code cannot be empty.")]
        [DisplayName("Module Code")]
        [ForeignKey("Modules")]
        public int ModID { get; set; }

        [NotMapped]
        public List<SelectListItem> Modules { set; get; }

        public bool Active { get; set; }
    }
}
