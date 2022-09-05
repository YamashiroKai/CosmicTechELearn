using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Viewable by students and lecturers of a particular module

namespace ELearn.Models
{
    public class Submission_Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Submission cannot be empty.")]
        [DisplayName("Submission ID")]
        [ForeignKey("Submissions")]
        public int SubID { get; set; }

        [NotMapped]
        public List<SelectListItem> Submissions { set; get; }

        [Required(ErrorMessage = "Student ID cannot be empty")]
        [DisplayName("Student ID")]
        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [NotMapped]
        public List<SelectListItem> Students { set; get; }

        [Required(ErrorMessage = "Link to file cannot be empty.")]
        [DisplayName("File Link")]
        public string FileLink { get; set; }

        public double Grade { get; set; }
    }


}
