using System;
using System.Collections.Generic;
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

        public List<UsersDto> GetBy(string state)
        {
            try
            {
                var userList = context.Users.ToList().Where(x => x.state=="activo");
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

        public void Insert(UsersDto userDto)
        {
            try
            {
                var validar = new UsersValidator();
                validar.ValidateAndThrow(userDto);
                Users user = userDto.MapToUsers();
                context.Users.Add(user);
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
                var validar = new UsersValidator();
                validar.ValidateAndThrow(usersDto);
                Users user = context.Users.Single(x => x.id == id);
                user=usersDto.MapToUsers(user);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, string state)
        {
            try
            {
                var itemToUpdate = context.Users.Single(x => x.id == id);
                itemToUpdate.state = state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
