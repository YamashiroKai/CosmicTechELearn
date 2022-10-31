using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Office ID cannot be empty.")]
        [DisplayName("Office ID")]
        [ForeignKey("Offices")]
        public int OfficeID { get; set; }

        [Required(ErrorMessage = "Title cannot be empty.")]
        [DisplayName("Title and name, eg: Prof. Swanepoel.")]
        public string Title { get; set; }

        [NotMapped]
        public List<SelectListItem> Offices { set; get; }

        [NotMapped]
        public List<SelectListItem> Lecturer_Modules { set; get; }

        public bool Active { get; set; }
    }
}