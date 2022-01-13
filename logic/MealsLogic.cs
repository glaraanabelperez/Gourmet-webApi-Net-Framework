using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class MealsLogic : BaseLogic, IABM<MealsDto>
    {
        public MealsDto GetById(int id)
        {
            try
            {
                var menu = context.Meals.Single(x => x.id == id);
                return menu.MapToMealsDto();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<MealsDto> GetAll()
        {
            try
            {
                var mealsList = context.Meals.ToList();
                List<MealsDto> list = new List<MealsDto>();
                foreach (Meals m in mealsList)
                {
                    list.Add(m.MapToMealsDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<MealsDto> GetBy( string state)
        {
            try
            {
                var mealsList = context.Meals.Where(x=> x.state==state).ToList();
                List<MealsDto> list = new List<MealsDto>();
                foreach (Meals m in mealsList)
                {
                    list.Add(m.MapToMealsDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(MealsDto mealDto)
        {
            try
            {
                var validar = new MealsValidator();
                validar.ValidateAndThrow(mealDto);
                Meals meal = mealDto.MapToMeals();

                context.Meals.Add(meal);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, MealsDto mealDto)
        {
            try
            {
                var validar = new MealsValidator();
                validar.ValidateAndThrow(mealDto);
                Meals Meal = context.Meals.Single(x => x.id == id);
                Meal.type = mealDto.type;
                Meal.title = mealDto.title;
                Meal.description = mealDto.description;

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }  

        public void Update(int id, string state)
        {
            try
            {
                var itemToUpdate = context.Meals.Single(x => x.id == id);
                itemToUpdate.state = state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
