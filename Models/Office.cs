﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearn.Models
{
    public class Office
    {
        [Key]
        public int OfficeID { get; set; }

        [Required(ErrorMessage = "Building cannot be empty.")]
        [DisplayName("Building Name")]
        public string BuildingName { get; set; }

        [Required(ErrorMessage = "Location cannot be empty.")]
        [DisplayName("Location/Campus")]
        public string Location { get; set; }
    }
}
