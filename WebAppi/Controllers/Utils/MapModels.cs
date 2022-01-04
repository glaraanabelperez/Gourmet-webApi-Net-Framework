using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using WebAppi.Models.menus;

namespace WebAppi.Controllers.Utils
{
    public static class MapModels
    {
        public static MenusResponse MapMeuToMenuResponse(this Menus menu)
        {
            MenusResponse m = new MenusResponse();

            m.id = menu.id;
            m.date = menu.date;
            m.Meals = menu.Meals;
            m.state = menu.state;

            return m;
        }
    }
}