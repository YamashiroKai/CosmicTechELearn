using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class Sponsor_Student
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Sponsor")]
        public string SponsorID { get; set; }

        [ForeignKey("Student")]
        public string StudentID { get; set; }
    }
}
