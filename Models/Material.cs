using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Should be visible to HOD,SC, and lecturers/students approved for module.
//Lecturer can edit

namespace ELearn.Models
{
    public class Material
    {
        [Key]
        public int MatID { get; set; }

        //One module can have many material
        [Required(ErrorMessage = "Module Code cannot be empty.")]
        [ForeignKey("Module")]
        [DisplayName("Module Code")]
        public string ModCode { get; set; }

        public int Week { get; set; }

        [Required(ErrorMessage = "File link cannot be empty.")]
        [DisplayName("File Link")]
        public string FileLink { get; set; }
        public string Description { get; set; }

        //Lecturer can hide material instead of deleting it
        [DisplayName("Visible")]
        public bool Active { get; set; }

    }
}
