using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Utils
{
    public static class MapClientDto
    {
      
            public static ClientDto MapToClient(this Users user)
            {
                    ClientDto c = new ClientDto();
                    c.id = user.id;
                    c.name = user.name;
                    c.name = user.lastName;
                    c.phone = user.phone;
                    c.Companies = user.Companies.MapToCompaniesDto();
                
                return c;
            }

            

    }
}


