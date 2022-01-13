using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class MenusLogic : BaseLogic, IABM<MenusDto>
    {

        public List<MenusDto> GetAll()
        {
            try
            {
                var menuList = context.Menus.ToList();
                List<MenusDto> list = new List<MenusDto>();
                foreach (Menus m in menuList)
                {
                    list.Add(m.MapToMenuDto());
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MenusDto GetById(int id)
        {
            try
            {
                var menu = context.Menus.Single(x => x.id == id);
                return menu.MapToMenuDto();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<MenusDto> GetBy(string date, string state)
        {
            try
            {
                var menuList = context.Menus.Where(x =>
                x.date.ToString() == date && (x.state == state)).ToList();
                List<MenusDto> list = new List<MenusDto>();
                foreach (Menus m in menuList)
                {
                    list.Add(m.MapToMenuDto());
                }

                return list;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Insert(MenusDto menuDto)
        {
            try
            {
                Menus menu = menuDto.MapToMenus();
                var validateData = new MenusInsertValidator();
                validateData.ValidateAndThrow(menuDto);
                context.Menus.Add(menu);
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
                var itemToUpdate = context.Menus.Single(x => x.id == id);
                itemToUpdate.state = state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, MenusDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
