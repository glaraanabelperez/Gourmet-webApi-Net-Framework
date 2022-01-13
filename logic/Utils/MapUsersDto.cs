﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Utils
{
    public static class MapUsersDto
    {
      
        public static UsersDto MapToUsersDto(this Users user)
        {
            UsersDto c = new UsersDto();
                c.id = user.id;
                c.email = user.email;
                c.pass = user.pass;
                c.name = user.name;
                c.lastName = user.lastName;
                c.phone = user.phone;
                c.direction = user.direction;
                c.state = user.state;
                c.idCompany = user.idCompany;
                c.Companies = user.Companies.MapToCompaniesDto();
            
            return c;
        }

        public static Users MapToUsers(this UsersDto user)
        {
            Users u = new Users();
            u.id = user.id;
            u.email = user.email;
            u.pass = user.pass;
            u.name = user.name;
            u.lastName = user.lastName;
            u.phone = user.phone;
            u.direction = user.direction;
            u.state = user.state;
            u.idCompany = user.idCompany;

            return u;
        }

        public static Users MapToUsers(this UsersDto user, Users u)
        {
            u.id = user.id;
            u.email = user.email;
            u.pass = user.pass;
            u.name = user.name;
            u.lastName = user.lastName;
            u.phone = user.phone;
            u.direction = user.direction;
            u.state = user.state;
            u.idCompany = user.idCompany;

            return u;
        }


    }
}


