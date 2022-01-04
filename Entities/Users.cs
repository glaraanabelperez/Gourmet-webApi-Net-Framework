using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Domain
{

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(35)]
        public string email { get; set; }

        [Required]
        [StringLength(30)]
        public string pass { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string lastName { get; set; }

        [Required]
        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        [StringLength(45)]
        public string direction { get; set; }

        [Required]
        [StringLength(20)]
        public string state { get; set; }

        public int idCompany { get; set; }

        public virtual Companies Companies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
