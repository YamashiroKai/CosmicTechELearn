using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

//Assignment of ID to AspNetUsers should be automatic on registration

namespace ELearn.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty.")]
        [DisplayName("Title and name, eg: Ms Swanepoel.")]
        public string Title { get; set; }

        //public string FirstName { get; set; }

        //public string Surname { get; set; }
    }
}
