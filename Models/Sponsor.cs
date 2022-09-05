using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Assignment of ID to AspNetUsers should be automatic on registration

namespace ELearn.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
    }
}
