using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Application.Models
{
    public class LocationModel
    {
        public int LocNo { get; set; }

        [Display(Name = "Location Name")]
        public string LocName { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        public int CompNo { get; set; }

        [Display(Name = "Compony")]
        public string CompName { get; set; }
    }
}