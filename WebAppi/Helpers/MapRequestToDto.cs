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

        public static OrdersDto MapToOrderDto(this OrdersRequest order)
        {
            OrdersDto orderDto = new OrdersDto();
            orderDto.id = order.id;
            orderDto.idMenu = order.idMenu;
            orderDto.idUser = order.idUser;
            orderDto.state = order.state;
            orderDto.deliveryAddress = order.deliveryAddress;
            orderDto.amount = order.amount;

            return orderDto;
        }


    }
}


