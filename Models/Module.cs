using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class Module
    {
        [Key]
        public int ModID { get; set; }

        [Required(ErrorMessage = "Module code cannot be empty.")]
        [DisplayName("Module Code")]
        public string ModCode { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [DisplayName("Credit Award")]
        [Required(ErrorMessage = "Credit Award cannot be empty.")]
        public double CreditAward { get; set; }

        [Required(ErrorMessage = "Year of course cannot be empty.")]
        [DisplayName("Year of course")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Fee cannot be empty.")]
        public int Fee { get; set; }

        [Required(ErrorMessage = "Period cannot be empty.")]
        [DisplayName("Period in Months")]
        public int PeriodMonths { get; set; }

        public bool Active { get; set; }
    }
}
