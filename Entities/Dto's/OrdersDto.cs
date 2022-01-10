
namespace Domain
{
    public  class OrdersDto
    {

        public int id { get; set; }

        public int idUser { get; set; }

        public int idMenu { get; set; }

        public string state { get; set; }

        public string deliveryAddress { get; set; }

        public int amount { get; set; }

        public virtual MenusDto MenusDto { get; set; }

        public virtual ClientDto ClientDto { get; set; }

    }
}
