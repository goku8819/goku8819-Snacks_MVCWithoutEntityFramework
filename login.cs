using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snacks_MVCWithoutEntityFramework.Models
{
    public class login
    {
        public  int id {  get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Login Person Name")]
        public string name { get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Login Person User Name")]
        public string uname { get; set; }

        [Display(Name = "Login Person Password")]
        [Required]
        [StringLength(100)]
        public string pwd { get; set; }


        [Display(Name = "Login Person Photo")]
        [Required]
        public string Photo { get; set; }

        public HttpPostedFileBase UploadImage { get; set; }



    }
}