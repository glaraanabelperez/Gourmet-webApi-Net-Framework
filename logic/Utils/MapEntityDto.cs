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
                    m.idMeal = menu.idMeals;
                    m.date = menu.date;
                    m.state = menu.state;

                return m;
            }

        public static MenusDto MapToMenuDto(this Menus menu)
        {
            MenusDto menuDto = new MenusDto();
                menuDto.id = menu.id;
                menuDto.idMeals = menu.idMeal;
                menuDto.date = menu.date;
                menuDto.state = menu.state;

            return menuDto;
        }
    }
}


