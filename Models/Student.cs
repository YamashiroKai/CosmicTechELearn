using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

//Assignment of ID to AspNetUsers should be automatic on registration

namespace ELearn.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [DisplayName("User ID")]
        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [DisplayName("Fees Due")]
        public float AmountDue { get; set; }

        [DisplayName("Sponsor ID")]
        [ForeignKey("Sponsors")]
        public int SponsorID { get; set; }

        [NotMapped]
        public List<SelectListItem> Sponsors { set; get; }

        [DisplayName("Accomodation ID")]
        [ForeignKey("Accomodations")]
        public int AccomID { get; set; }

        [Required(ErrorMessage = "Title cannot be empty.")]
        [DisplayName("Title and surname, eg: Mr De Burg.")]
        public string Title { get; set; }

        [NotMapped]
        public List<SelectListItem> Accomodations { set; get; }

        public bool Active { get; set; }
    }
}
