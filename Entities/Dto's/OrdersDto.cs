
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

        public string observation { get; set; }

        public virtual MenusDto MenusDto { get; set; }

        public virtual UsersDto userDto { get; set; }

    }
}
