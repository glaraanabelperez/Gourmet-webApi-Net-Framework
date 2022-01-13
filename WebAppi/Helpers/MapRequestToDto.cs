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

        public static MealsDto MapToMealsDto(this MealsRequest meal)
        {
            MealsDto mealDto = new MealsDto();
            mealDto.id = meal.id;
            mealDto.type = meal.type;
            mealDto.title = meal.title;
            mealDto.description = meal.description;

            return mealDto;
        }

        public static UsersDto MapToUserDto(this UserRequest user)
        {
            UsersDto usersDto = new UsersDto();
            usersDto.id = user.id;
            usersDto.email = user.email;
            usersDto.pass = user.pass;
            usersDto.name = user.name;
            usersDto.lastName = user.lastName;
            usersDto.direction = user.direction;
            usersDto.phone = user.phone;
            usersDto.idCompany = user.idCompany;

            return usersDto;
        }

        public static CompaniesDto MapToCompaniesDto(this CompaniesRequest comapny)
        {
            CompaniesDto companyDto = new CompaniesDto();
            companyDto.id = comapny.id;
            companyDto.name = comapny.name;
            companyDto.phone = comapny.phone;
            companyDto.direction = comapny.direction;

            return companyDto;
        }


    }
}


