using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Student_Module
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Student ID cannot be empty")]
        [DisplayName("Student ID")]
        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [NotMapped]
        public List<SelectListItem> Students { set; get; }

        [Required(ErrorMessage = "Module ID cannot be empty")]
        [DisplayName("Module ID")]
        [ForeignKey("Modules")]
        public int ModID { get; set; }

        [NotMapped]
        public List<SelectListItem> Modules { set; get; }

        public int Grade { get; set; }

        public bool Completed { get; set; }
    }
}
