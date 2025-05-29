using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snacks_MVCWithoutEntityFramework.Models
{
    public class billing
    {
        public int id { get; set; }
        [StringLength(100)]

        public string name { get; set; }    

        public int? cost  { get; set; } 


        public string company { get; set; }


    }


}