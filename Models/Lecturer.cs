﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [ForeignKey("Office")]
        public int OfficeID { get; set; }
        public Office Office { get; set; }

        [Required(ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Home address cannot be empty.")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime JoinDate { get; set; }

        public bool Active { get; set; }
    }
}
