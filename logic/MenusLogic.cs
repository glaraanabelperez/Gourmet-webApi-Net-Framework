using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.States;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class MenusLogic : BaseLogic, IABM<MenusDto>
    {
        public List<MenusDto> GetAll()
        {
            try
            {
                var menuList = context.Menus.ToList();
                List<MenusDto> list = new List<MenusDto>();
                foreach (Menus m in menuList)
                {
                    list.Add(m.MapToMenuDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<MenusDto> GetBy(string date)
        {
            try
            {
                var menuList = context.Menus.Where(x =>
                x.date.ToString() == date && (x.state == States.available)).ToList();
                List<MenusDto> list = new List<MenusDto>();
                foreach (Menus m in menuList)
                {
                    list.Add(m.MapToMenuDto());
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(List<MenusDto> menuList)
        {
            foreach (MenusDto m in menuList)
            {
                try
                {
                    Menus menu = context.Menus.Where(x =>
                    x.date == m.date && (x.idMeal == m.idMeal)).FirstOrDefault();
                    if (menu==null)
                    {
                        m.state = States.available;
                        context.Menus.Add(m.MapToMenus());
                        context.SaveChanges();
                    }
                    else if (menu.state==States.deleted)
                    {
                        var itemToUpdate = context.Menus.Single(x => x.id == menu.id);
                        itemToUpdate.state = States.available;
                        context.Entry(itemToUpdate).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        continue;
                    }
 
                   
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public void Delete(int id)
        {
            try
            {
                var itemToUpdate = context.Menus.Single(x => x.id == id);
                itemToUpdate.state = States.deleted;
                context.Entry(itemToUpdate).State = EntityState.Modified;

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
