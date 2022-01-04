using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Domain
{

    public partial class Meals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meals()
        {
            Menus = new HashSet<Menus>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        [Required]
        [StringLength(75)]
        public string title { get; set; }

        [Required]
        [StringLength(200)]
        public string description { get; set; }

        [StringLength(10)]
        public string state { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menus> Menus { get; set; }
    }
}
