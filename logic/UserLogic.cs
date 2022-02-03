using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class UsersLogic : BaseLogic, IABM<UsersDto>
    {
       
        public List<UsersDto> GetAll()
        {
            try
            {
                var userList = context.Users.ToList();
                List<UsersDto> list = new List<UsersDto>();
                foreach (Users u in userList)
                {
                    list.Add(u.MapToUsersDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UsersDto GetById(int id)
        {
            try
            {
                var user = context.Users.Single(x => x.id == id );
                return user.MapToUsersDto();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Insert(UsersDto userDto)
        {
            try
            {
                context.Users.Add(userDto.MapToUsers());
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UsersDto Login(string email, string pass)
        {
            try
            {
                var user = (context.Users.Where(x => 
                x.email == email && x.pass==pass ).Single()).MapToUsersDto();
                
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, UsersDto usersDto)
        {
           
            try
            {
                Users userEntity = context.Users.Single(x => x.id == id);
                userEntity = usersDto.MapToUsersUpdate(userEntity);
                context.Entry(userEntity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
