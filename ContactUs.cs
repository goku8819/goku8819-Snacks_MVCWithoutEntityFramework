using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snacks_MVCWithoutEntityFramework.Models
{
    public class ContactUs
    {

        public int id { get; set; }
        [Required]
        [StringLength(100)]

        public string name { get; set; }
        [Required]
        [StringLength(100)]


        public string emailid { get; set; }
        [Required]
        [StringLength(100)]

        public string phone { get; set; } 
     


    }
}