using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Assignment of ID to AspNetUsers should be automatic on registration

namespace ELearn.Models
{
    public class HeadOfDepartment
    {
        [Key]
        public int HodID { get; set; }

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

        public bool Active { get; set; }
    }
}
