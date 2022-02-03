using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.States;

namespace logic.Utils
{
    public static class MapOrdersDto
    {
            public static OrdersDto MapToOrdersDto(this Orders order)
            {
                    OrdersDto o = new OrdersDto();
                    o.id = order.id;
                    o.idMenu = order.idMenu;
                    o.idUser = order.idUser;
                    o.MenusDto = order.Menus.MapToMenuDto();
                    o.userDto = order.Users.MapToUsersDto();
                    o.amount = order.amount;
                    o.state = order.state;
                    o.deliveryAddress = order.deliveryAddress;

                return o;
            }

            public static Orders MapToOrder(this OrdersDto order)
            {
                    Orders o = new Orders();
                    o.id = order.id;
                    o.idMenu = order.idMenu;
                    o.idUser = order.idUser;      
                    o.amount = order.amount;
                    o.state = States.pending;
                    o.deliveryAddress = order.deliveryAddress;

                return o;
            }

     

    }
}


