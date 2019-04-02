using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOPORTEE.Models
{
    public class DegreesClase
    {
        public int id { get; set; }

        [Required]   //lo agregue yo
        [Display(Name = "Name of the degrees ")]   //tambien puedo poner las longitudes
        public string degrees1 { get; set; }
    }

    [MetadataType(typeof(DegreesClase))]
    public partial class degrees
    {

    }
    
}