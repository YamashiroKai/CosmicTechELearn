using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Module")]
        public int ModID { get; set; }

        public int Week { get; set; }

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
        public string Description { get; set; }

        [DisplayName("Approved")]
        public bool Active { get; set; }
    }
}
