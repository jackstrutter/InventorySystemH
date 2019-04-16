using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemInventory.Models
{
    public class modelos
    {
        public int id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public string model { get; set; }

        public virtual Brands Brands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devices> Devices { get; set; }
    }
}