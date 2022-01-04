using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Domain;

namespace WebAppi.Models.menus
{
    public class MenusResponse
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string state { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual Meals Meals { get; set; }

    }
}