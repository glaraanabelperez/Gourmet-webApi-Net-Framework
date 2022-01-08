using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Queries
{
    public class MenuQueries :BaseLogic
    {

        public List<MenusDto> MenuListQuerie()
        {
            try
            {
                var menuList = (from menu in context.Menus
                                join meal in context.Meals
                                on menu.idMeal equals meal.id
                                select  new MenusDto
                                {
                                    id = menu.id,
                                    idMeal = meal.id,
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

            }catch(Exception e)
            {
                throw e;
            }
           
        }

        public MenusDto GetMenuDToQuerie(int id)
        {
            try
            {
                var menuDto = (from menu in context.Menus
                               join meal in context.Meals
                               on menu.idMeal equals meal.id
                               where menu.id == id
                               select new MenusDto
                               {
                                   id = menu.id,
                                   idMeal = meal.id,
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

                               }).Single();

                return menuDto;

            }
            catch(Exception e)
            {
                throw e;
            }
           
        }


        public void ChangeStateMenuQuerie(int id)
        {

            try
            {
                var menu = (from m in context.Menus
                            where m.id == id
                            select m).Single();
                menu.state = "inactivo";
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
