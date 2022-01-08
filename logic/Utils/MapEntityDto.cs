using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Utils
{
    public static class MapEntityDto
    {
      
            public static Menus MapToMenus(this MenusDto menu)
            {
                Menus m = new Menus();
                    m.id = menu.id;
                    m.idMeal = menu.idMeal;
                    m.date = menu.date;
                    m.state = menu.state;

                return m;
            }

            public static MenusDto MapToMenuDto(this Menus menu)
            {
                MenusDto menuDto = new MenusDto();
               
                    menuDto.id = menu.id;
                    menuDto.idMeal = menu.idMeal;
                    menuDto.Meals = menu.MapToMealsDto();
                    menuDto.date = menu.date;
                    menuDto.state = menu.state;
                
                return menuDto;
            }

            public static MealsDto MapToMealsDto(this Menus menu)
            {
                MealsDto meal = new MealsDto();
                meal.id = menu.Meals.id;
                meal.title = menu.Meals.title;
                meal.type = menu.Meals.type;
                meal.description = menu.Meals.description;
                meal.state = menu.Meals.state;

                return meal;
            }
    }
}


