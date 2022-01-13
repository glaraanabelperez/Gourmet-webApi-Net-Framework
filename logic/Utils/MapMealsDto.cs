using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace logic.Utils
{
    public static class MapMealsDto
    {
      
            public static Meals MapToMeals(this MealsDto meals)
            {
                Meals m = new Meals();
                    m.id = meals.id;
                    m.type = meals.type;
                    m.title = meals.title;
                    m.state = meals.description;

                return m;
            }

            public static MealsDto MapToMealsDto(this Meals meals)
            {
                    MealsDto m = new MealsDto();
                    m.id = meals.id;
                    m.type = meals.type;
                    m.title = meals.title;
                    m.state = meals.description;

                    return m;
               }

          
    }
}


