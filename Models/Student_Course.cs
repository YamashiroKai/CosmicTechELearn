using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Student_Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Course ID cannot be empty.")]
        [DisplayName("Course ID")]
        [ForeignKey("Courses")]
        public int CourseID { get; set; }

        [NotMapped]
        public List<SelectListItem> Courses { set; get; }

        [Required(ErrorMessage = "Student ID cannot be empty. You can find this in the details section of your dashboard.")]
        [DisplayName("Student ID")]
        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [NotMapped]
        public List<SelectListItem> Students { set; get; }

        public bool Completed { get; set; }

        public bool Active { get; set; }
    }
}
