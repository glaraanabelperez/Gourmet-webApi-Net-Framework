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
        public void Delete(int id)
        {
            try
            {
                var menu = (from m in context.Menus
                            where m.id == id
                            select m).Single();

                menu.state = "borrado";
                context.SaveChanges();
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
                var menuList = context.Menus.Where(x => x.state == "activo" || x.state == "suspendido").ToList();
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

        public List<MenusDto> GetAllFilterDate(string date)
        {
            try
            {

                var menuList = context.Menus.Where(x =>
                x.date.ToString() == date && (x.state == "suspendido" || x.state == "activo")).ToList();

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

        public void Insert(MenusDto menuDto)
        {
            try
            {
                Menus menu = menuDto.MapToMenus();
                var m = context.Menus.Add(menu);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateState(int id, string state)
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


    }
}
