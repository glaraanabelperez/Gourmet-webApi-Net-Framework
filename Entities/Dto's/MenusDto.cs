
using System;

namespace Domain
{
    public  class MenusDto 
    {
    
        public int id { get; set; }

        public int idMeals { get; set; }

        public string state { get; set; }

        public DateTime date { get; set; }

        public  MealsDto Meals { get; set; }

    }
}
