using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using WebAppi.Controllers;

namespace logic.Utils
{
    public static class MapRequestToDto
    {
        public static MenusDto MapToMenuDto(this MenusRequest menu)
        {
            MenusDto menuDto = new MenusDto();
                menuDto.id = menu.id;
                menuDto.idMeal = menu.idMeal;
                menuDto.date = menu.date;
                menuDto.state = menu.state;

            return menuDto;
        }


    }
}


