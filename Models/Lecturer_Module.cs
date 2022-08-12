using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Subject Co/HoD will approve a lecturer to teach a module. Multiple lecturers can teach
//many modules

namespace ELearn.Models
{
    public class Lecturer_Module
    {
        [ForeignKey("Lecturer")]
        public int LecturerID { get; set; }

        [ForeignKey("Module")]
        public int ModID { get; set; }

        [Key]
        public int ID { get; set; }
        
        public bool Approved { get; set; }
    }
}
