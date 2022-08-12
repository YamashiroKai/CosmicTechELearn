using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Viewable by students and lecturers of a particular module

namespace ELearn.Models
{
    public class Submission_Student
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Submission")]
        public int SubID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Link to file cannot be empty.")]
        [DisplayName("File Link")]
        public string FileLink { get; set; }
    }
}
