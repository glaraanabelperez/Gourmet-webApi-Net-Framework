using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using FluentValidation;
using logic.validations;

namespace logic
{
    class MenusLogic : BaseLogic, IABM<Menus>
    {
        public void Delete(int id)
        {
            Menus menu = context.Menus.Find(id);
            context.Menus.Remove(menu);

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Menus> GetAll()
        {
            try
            {
                return context.Menus.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Menus GetById(int id)
        {
            try
            {
                Menus menu = context.Menus.Find(id);
                return menu;
            }
            catch(Exception e) 
            {
                throw e;
            }
            
            
        }

        public void Insert(Menus menu)
        {
            try
            {
                ValidarMenu(menu);
                context.Menus.Add(menu);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(Menus menu)
        {
            
            try
            {
                ValidarMenu(menu);
                context.Entry(menu).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private static void ValidarMenu(Menus menu)
        {
            var validar = new MenusValidator();
            validar.ValidateAndThrow(menu);
        }
    }
}
