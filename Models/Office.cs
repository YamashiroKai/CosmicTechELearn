using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class Office
    {
        [Key]
        public int OfficeID { get; set; }

        [DisplayName("Building Name")]
        public string BuildingName { get; set; }

        [DisplayName("Location/Campus")]
        public string Location { get; set; }
    }
}
