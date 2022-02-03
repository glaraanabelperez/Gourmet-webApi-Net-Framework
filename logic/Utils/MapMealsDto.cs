using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.States;

namespace logic.Utils
{
    public static class MapMealsDto
    {
            public static MealsDto MapToMealsDto(this Meals meals)
            {
                    MealsDto m = new MealsDto();
                    m.id = meals.id;
                    m.type = meals.type;
                    m.title = meals.title;
                    m.description = meals.description;
                    m.state = meals.state;

                    return m;
               }

            public static Meals MapToMeals(this MealsDto meals)
            {
                Meals m = new Meals();
                m.type = meals.type;
                m.title = meals.title;
                m.description = meals.description;
                m.state = States.available;

                return m;
            }


    }
}


