using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOPORTEE.Models
{
    public class LocationClase
    {
        public int id { get; set; }

        [Required]   //lo agregue yo
        [Display(Name = "Name of the location ")]
        public string location { get; set; }
    }
}