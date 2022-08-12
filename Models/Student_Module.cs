using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class Student_Module
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Student")]
        public string StudentID { get; set; }

        [ForeignKey("Module")]
        public string ModID { get; set; }

        public int Grade { get; set; }
    }
}
