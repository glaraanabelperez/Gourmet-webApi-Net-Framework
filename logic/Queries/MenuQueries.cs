using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic.Queries
{
    public class MenuQueries :BaseLogic, IQuerie<MenusDto>
    {

        public void DeleteQuerie(int id)
        {
            try
            {
                var menu = (from m in context.Menus
                            where m.id == id
                            select m).Single();

                this.ValidateMenuInOrder(menu);
                menu.state = "borrado";
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<MenusDto> GetAllQuerie()
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

        public List<MenusDto> GetAllFilterDateQuerie(string date)
        {
            try
            {
                var menuList = context.Menus.Where(x => 
                x.date.ToString()== date && (x.state=="suspendido" || x.state == "activo")).ToList();

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

        public MenusDto GetByIdQuerie(int id)
        {
            try
            {
                
                var menu = context.Menus.Single(x => x.id == id && x.state=="activo" || x.state=="suspendido");
                return menu.MapToMenuDto();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertQuerie(MenusDto menuDto)
        {
            var validar = new MenusInsertValidator();
            validar.ValidateAndThrow(menuDto);

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

        public void UpdateQuerie(MenusDto menuDto)
        {
            var validar = new MenusUpdateValidator();
            validar.ValidateAndThrow(menuDto);

            try
            {
                var itemToUpdate = context.Menus.Single(x => x.id == menuDto.id);
                itemToUpdate.state = menuDto.state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
               
            
        }

        public void ValidateMenuInOrder(Menus menu)
        {         
            foreach(Orders o in menu.Orders)
            {
                if (o.state == "pendiente")
                {
                    return ;
                }
            }
        }
    }
}
