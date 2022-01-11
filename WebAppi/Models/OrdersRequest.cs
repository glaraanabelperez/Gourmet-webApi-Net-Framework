
using System;
using Domain;

namespace WebAppi.Controllers
{
    public  class OrdersRequest
    {

        public int id { get; set; }

        public int idUser { get; set; }

        public int idMenu { get; set; }

        public string state { get; set; }

        public string deliveryAddress { get; set; }

        public int amount { get; set; }



    }
}

