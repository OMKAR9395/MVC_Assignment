using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Compony
    {
        public int Id { get; set; }
        [Display (Name = "Name")]
        public string ComponyName { get; set; }

        [Display (Name ="Address")]
        public string Address { get; set; }

        [Display(Name ="Remark")]
        public string Remark { get; set; }

         
    }
}