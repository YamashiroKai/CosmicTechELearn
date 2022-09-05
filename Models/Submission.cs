using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

//Should be visible to HOD,SC, and lecturers/students approved for module.
//Lecturer can edit
//Similiar to Material table except Student users can link uploads to a submission entry

namespace ELearn.Models
{
    public class Submission
    {
        [Key]
        public int SubID { get; set; }

        //One module can have many submissions
        [Required(ErrorMessage = "Module Code cannot be empty.")]
        [DisplayName("Module Code")]
        [ForeignKey("Modules")]
        public string ModID { get; set; }

        [NotMapped]
        public List<SelectListItem> Modules { set; get; }

        public int Week { get; set; }

        public int TotalScore { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Starting Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        //Link to material/instructions for assignment, homework, etc
        [DisplayName("File Link")]
        public string FileLink { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        public string Description { get; set; }

        [DisplayName("Approved")]
        public bool Active { get; set; }
    }
}
