using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Queries;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class MenusLogic : BaseLogic, IABM<MenusDto>
    {
        private readonly MenuQueries menuQueri;

        public MenusLogic()
        {
            this.menuQueri = new MenuQueries();
        }
        public void Delete(int id)
        {
            try
            {
                this.menuQueri.ChangeStateMenuQuerie(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<MenusDto> GetAll()
        {
            try
            {
                return this.menuQueri.MenuListQuerie();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public MenusDto GetById(int id)
        {
            try
            {
                return this.menuQueri.GetMenuDToQuerie(id);
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Insert(MenusDto menuDto)
        {
            try
            {
                Menus menu = menuDto.MapToMenus();
                ValidarMenu(menu);
                var m=context.Menus.Add(menu);
                context.SaveChanges();
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
