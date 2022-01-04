using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Domain
{
    

    public partial class Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menus()
        {
            Orders = new HashSet<Orders>();
        }

        public int id { get; set; }

        public int idMeal { get; set; }

        [Required]
        [StringLength(10)]
        public string state { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual Meals Meals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
