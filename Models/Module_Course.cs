using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Connection must be made by HoD/Subject Co

namespace ELearn.Models
{
    public class Module_Course
    {
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Module")]
        public int ModID { get; set; }

        [Key]
        public int ID { get; set; }

       
        public bool Approved { get; set; }
    }
}
