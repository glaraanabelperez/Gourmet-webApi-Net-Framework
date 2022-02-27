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

                //var menuList = context.Menus.Join(context.Meals,
                //                                 menu => menu.idMeal,
                //                                 meal => meal.id, 
                //                                 (menu, meal) => new { Menu = menu, Meal = meal })
                //                            .Where(menuMeal =>
                //menuMeal.Menu.date.ToString() == date
                //&& (menuMeal.Menu.state == States.available)
                //&& (menuMeal.Meal.state == States.available))
                //                            .Select(ob => new Menus()
                //                            {
                //                                id = ob.Menu.id,
                //                                idMeal = ob.Menu.idMeal,
                //                                date=ob.Menu.date,
                //                                state=ob.Menu.state
                //                            })
                //                            .ToList();

                var meals = context.Meals.Where(x => x.state == States.available).ToList();

                var menuList = context.Menus.Where(x =>
                x.date.ToString() == date && (x.state == States.available)).ToList();



                List<MenusDto> list = new List<MenusDto>();
                foreach (Menus m in menuList)
                {
                    foreach (Meals meal in meals)
                    {
                        if (meal.id == m.idMeal)
                        {
                            list.Add(m.MapToMenuDto());
                        }
                            
                    }
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

        public void Insert(MenusDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MenusDto entity)
        {
            throw new NotImplementedException();
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
