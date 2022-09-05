using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Subject Co/HoD will approve a lecturer to teach a module. Multiple lecturers can teach
//many modules

namespace ELearn.Models
{
    public class Lecturer_Module
    {

        [Required(ErrorMessage = "Lecturer ID cannot be empty.")]
        [DisplayName("Lecturer ID")]
        [ForeignKey("Lecturers")]
        public int LecturerID { get; set; }

        [NotMapped]
        public List<SelectListItem> Lecturers { set; get; }

        [Required(ErrorMessage = "Module ID cannot be empty.")]
        [DisplayName("Module ID")]
        [ForeignKey("Module")]
        public int ModID { get; set; }

        [NotMapped]
        public List<SelectListItem> Modules { set; get; }

        [Key]
        public int ID { get; set; }
        
        public bool Approved { get; set; }
    }
}
