using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.States;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class MealsLogic : BaseLogic, IABM<MealsDto>
    {
        public void Delete(int id)
        {
            try
            {
                Meals mealToUpdate = context.Meals.Single(x => x.id == id);
                mealToUpdate.state = States.deleted;
                context.Entry(mealToUpdate).State = EntityState.Modified;
                context.SaveChanges();
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

        public List<MealsDto> GetBy(string date)
        {
            throw new NotImplementedException();
        }

        public void Insert(MealsDto meal)
        {
            try
            {

                meal.state = States.available;
                context.Meals.Add(meal.MapToMeals());
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, MealsDto meal)
        {
            Meals Meal = context.Meals.Single(x => x.id == id);
            Meal.type = meal.type;
            Meal.title = meal.title;
            Meal.description = meal.description;
            Meal.state = States.available;
            context.Entry(Meal).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
