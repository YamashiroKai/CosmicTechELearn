using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearn.Models
{
    public class HeadOfDepartment
    {
        [Key]
        public int HodID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }

        [ForeignKey("Office")]
        public int OfficeID { get; set; }
    }
}
