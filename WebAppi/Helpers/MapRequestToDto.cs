using System.Collections.Generic;

using Domain;
using WebAppi.Controllers;

namespace logic.Utils
{
    public static class MapRequestToDto
    {

        public static List<MenusDto> MapToMenuDtoList(this List <MenusRequest> menuListRequest)
        {
            List<MenusDto> menuList = new List<MenusDto>();

            foreach (MenusRequest m in menuListRequest)
            {
                MenusDto menuDto = new MenusDto();
                menuDto.idMeal = m.idMeal;
                menuDto.date = m.date;

                menuList.Add(menuDto);
            }

            return menuList;
        }

        public static List<OrdersDto> MapToOrderDtoList(this List<OrdersRequest> orders)
        {
            List<OrdersDto> orderList = new List<OrdersDto>();

            foreach (OrdersRequest order in orders)
            {
                OrdersDto or = new OrdersDto();
                or.idMenu = order.idMenu;
                or.idUser = order.idUser;
                or.deliveryAddress = order.deliveryAddress;
                or.amount = order.amount;

                orderList.Add(or);
            }

            return orderList;
        }

        public static MealsDto MapToMealsDto(this MealsRequest mealRequest)
        {
            MealsDto meal = new MealsDto();
            meal.type = mealRequest.type;
            meal.title = mealRequest.title;
            meal.description = mealRequest.description;

            return meal;
        }

        public static UsersDto MapToUserDto(this UserRequest user)
        {
            UsersDto usersDto = new UsersDto();

            usersDto.email = user.email;
            usersDto.pass = user.pass;
            usersDto.name = user.name;
            usersDto.lastName = user.lastName;
            usersDto.direction = user.direction;
            usersDto.phone = user.phone;

            return usersDto;
        }


    }
}


