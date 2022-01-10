
namespace Domain
{
    public  class ClientDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string state { get; set; }

        public virtual CompaniesDto Companies { get; set; }



    }
}
