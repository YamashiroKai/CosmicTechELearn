using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class SubjectCoordinator
    {
        [Key]
        public int SubjectCoID { get; set; }

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
