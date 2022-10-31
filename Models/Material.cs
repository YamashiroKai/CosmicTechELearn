using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Should be visible to HOD,SC, and lecturers/students approved for module.
//Lecturer can edit

namespace ELearn.Models
{
    public class Material
    {
        [Key]
        public int MatID { get; set; }

        //One module can have many material
        [Required(ErrorMessage = "Module ID cannot be empty.")]
        [DisplayName("Module ID")]
        [ForeignKey("Modules")]
        public int ModID { get; set; }

        [NotMapped]
        public List<SelectListItem> Modules { set; get; }

        public int Week { get; set; }

        [Required(ErrorMessage = "File link cannot be empty.")]
        [Url]
        [DisplayName("File Link")]
        public string FileLink { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }

        //Sub Co needs to approve it before it will be visible to students
        [DisplayName("Approved")]
        [Required]
        public bool Active { get; set; }

    }
}
