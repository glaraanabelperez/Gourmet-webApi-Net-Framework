
namespace Domain
{
    public  class UsrersDto
    {
        public int id { get; set; }

        public string email { get; set; }

        public string pass { get; set; }

        public string name { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string direction { get; set; }

        public string state { get; set; }

        public int idCompany { get; set; }

        public virtual Companies Companies { get; set; }


    }
}
