using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Domain
{
    

    public partial class Orders
    {
        public int id { get; set; }

        public int idUser { get; set; }

        public int idMenu { get; set; }

        [Required]
        [StringLength(9)]
        public string state { get; set; }

        [Required]
        [StringLength(75)]
        public string deliveryAddress { get; set; }

        public int amount { get; set; }

        public virtual Menus Menus { get; set; }

        public virtual Users Users { get; set; }
    }
}
