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

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Home address cannot be empty.")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime JoinDate { get; set; }

        [DisplayName("Fees Due")]
        public int AmountDue { get; set; }

        [Required(ErrorMessage = "Sponsor ID cannot be empty.")]
        [DisplayName("Sponsor ID")]
        [ForeignKey("Sponsors")]
        public int SponsorID { get; set; }

        [NotMapped]
        public List<SelectListItem> Sponsors { set; get; }

        [DisplayName("Accomodation ID")]
        [ForeignKey("Accomodations")]
        public int AccomID { get; set; }

        [NotMapped]
        public List<SelectListItem> Accomodations { set; get; }

        public bool Active { get; set; }
    }
}
