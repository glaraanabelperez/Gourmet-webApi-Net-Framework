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
    public class MenusLogic : BaseLogic, IABM<MenusDto>
    {
        public void Delete(int id)
        {
            Menus menu = context.Menus.Find(id);
            context.Menus.Remove(menu);

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<MenusDto> GetAll()
        {
            try
            {

                var menuList = (from menu in context.Menus
                             join meal in context.Meals
                             on menu.idMeal equals meal.id
                             select new MenusDto
                             {
                                 id = menu.id,
                                 date = menu.date,
                                 Meals = new MealsDto
                                 {
                                     id = meal.id,
                                     type = meal.type,
                                     title = meal.title,
                                     description = meal.description,
                                     state = meal.state
                                 },
                                 state = menu.state
                             }).ToList();
                return menuList;
                //return  context.Menus.ToList(); 
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public MenusDto GetById(int id)
        {
            //try
            //{
            //    Menus menu = context.Menus.Find(id);
            //    return menu;
            //}
            //catch(Exception e) 
            //{
            //    throw e;
            //}
            return null;
            
        }

        public void Insert(MenusDto menud)
        {
            try
            {
                //ValidarMenu(menud);
                //menud.id = NULL;
                context.Menus.Add(menud.MapToMenus());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(MenusDto menu)
        {
            
            //try
            //{
            //    ValidarMenu(menu);
            //    context.Entry(menu).State = EntityState.Modified;

            //    try
            //    {
            //        context.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        throw e;
            //    }
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
        }

        private static void ValidarMenu(MenusDto menu)
        {
            //var validar = new MenusValidator();
            //validar.ValidateAndThrow(menu);
        }
    }
}
