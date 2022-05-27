using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;// Refers to our displayName
using System.Linq;
using System.Threading.Tasks;

namespace Example_Routing.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Borrower { get; set; }

        [Required]
        public string Lender { get; set; }

        [DisplayName("Item Name")]// This refers to chaning column names when the it gets displayed in the browser
        [Required]                          
        public string ItemName { get; set; }

        //public string Description { get; set; }


    }
}
