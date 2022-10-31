using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Module
    {
        [Key]
        [DisplayName("Module ID")]
        public int ModID { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [DisplayName("Credit Award")]
        [Required(ErrorMessage = "Credit Award cannot be empty.")]
        public int CreditAward { get; set; }

        [Required(ErrorMessage = "Year of course cannot be empty.")]
        [DisplayName("Year of course")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Fee cannot be empty.")]
        public double Fee { get; set; }

        [Required(ErrorMessage = "Period cannot be empty.")]
        [DisplayName("Period in Months")]
        public int PeriodMonths { get; set; }

        [DisplayName("Lecturer ID")]
        [ForeignKey("Lecturers")]
        public int LecturerID { get; set; }

        [NotMapped]
        public List<SelectListItem> Lecturers { set; get; }

        public bool Active { get; set; }
    }
}
