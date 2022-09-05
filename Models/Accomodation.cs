using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Accomodation
    {
        [Key]
        public int AccomID { get; set; }

        [Required(ErrorMessage = "Building cannot be empty.")]
        [DisplayName("Building/Room Name")]
        public string BuildingName { get; set; }

        [Required(ErrorMessage = "Address cannot be empty.")]
        public string Address { get; set; }
    }
}
