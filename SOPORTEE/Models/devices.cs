//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOPORTEE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class devices
    {
        public int id { get; set; }
        public int deviceType_id { get; set; }
        public int brand_id { get; set; }
        public int model_id { get; set; }
        public int location_id { get; set; }
        public int state_id { get; set; }
        public string serialNumber { get; set; }
        public string stockNumber { get; set; }
        public Nullable<int> assignment_id { get; set; }
        public int proyect_id { get; set; }
        public System.DateTime date { get; set; }
        public string comments { get; set; }
        public int responsible_id { get; set; }
    
        public virtual appUsers appUsers { get; set; }
        public virtual assignments assignments { get; set; }
        public virtual brands brands { get; set; }
        public virtual locations locations { get; set; }
        public virtual models models { get; set; }
        public virtual proyects proyects { get; set; }
        public virtual states states { get; set; }
    }
}
