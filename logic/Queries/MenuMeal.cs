using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Queries
{
    class MenuMeal :BaseLogic
    {
        //public List<MenusDto> GetAllMenuWithMeal()
        //{
        //    try
        //    {

        //        var menuList = (from menu in context.Menus
        //                        join meal in context.Meals
        //                        on menu.idMeal equals meal.id
        //                        select new MenusDto
        //                        {
        //                            id = menu.id,
        //                            date = menu.date,
        //                            Meals = new MealsDto
        //                            {
        //                                id = meal.id,
        //                                type = meal.type,
        //                                title = meal.title,
        //                                description = meal.description,
        //                                state = meal.state
        //                            },
        //                            state = menu.state
        //                        }).ToList();
        //        return menuList;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
