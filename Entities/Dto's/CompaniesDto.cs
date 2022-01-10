using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Domain
{

    public partial class CompaniesDto
    {
   
        public int id { get; set; }

        public string name { get; set; }

        public string direction { get; set; }

        public string phone { get; set; }

    }
}
