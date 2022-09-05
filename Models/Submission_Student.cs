using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

//Viewable by students and lecturers of a particular module

namespace ELearn.Models
{
    public class Submission_Student
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Submission")]
        public int SubID { get; set; }

        [NotMapped]
        public List<SelectListItem> Submissions { set; get; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [NotMapped]
        public List<SelectListItem> Students { set; get; }

        [Required(ErrorMessage = "Link to file cannot be empty.")]
        [DisplayName("File Link")]
        public string FileLink { get; set; }

        public int Grade { get; set; }
    }


}
