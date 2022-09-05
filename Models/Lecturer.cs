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

        [NotMapped]
        public List<SelectListItem> Offices { set; get; }

        public bool Active { get; set; }
    }
}

//[Required(ErrorMessage = "Name cannot be empty.")]
//public string Name { get; set; }

//[Required(ErrorMessage = "Surname cannot be empty.")]
//public string Surname { get; set; }

//[Required(ErrorMessage = "Home address cannot be empty.")]
//public string Address { get; set; }

//[DataType(DataType.Date)]
//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
//public DateTime JoinDate { get; set; }