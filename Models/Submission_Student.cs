using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

//Viewable by students and lecturers of a particular module

namespace ELearn.Models
{
    public class Submission_Student
    {
        [Key]
        public int SubStuID { get; set; }

        [Required(ErrorMessage = "Submission cannot be empty.")]
        [DisplayName("Submission ID")]
        [ForeignKey("Submissions")]
        public int SubID { get; set; }

        [NotMapped]
        public List<SelectListItem> Submissions { set; get; }

        [ForeignKey("Students")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Link to file cannot be empty.")]
        [Url]
        [DisplayName("File Link")]
        public string FileLink { get; set; }

        public double Grade { get; set; }
    }



}
