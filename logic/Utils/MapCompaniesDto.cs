using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Utils
{
    public static class MapComapiesDto
    {

        public static CompaniesDto MapToCompaniesDto(this Companies company)
        {
            CompaniesDto c = new CompaniesDto();
            c.id = company.id;
            c.name = company.name;
            c.phone = company.phone;
            c.direction = company.direction;

            return c;
        }

        public static Companies MapToCompanies(this CompaniesDto company)
        {
            Companies c = new Companies();
            c.id = company.id;
            c.name = company.name;
            c.phone = company.phone;
            c.direction = company.direction;

            return c;
        }

        public static Companies MapToCompanies(this CompaniesDto company, Companies c)
        {
            c.id = company.id;
            c.name = company.name;
            c.phone = company.phone;
            c.direction = company.direction;

            return c;
        }

    }
}


