﻿using System;
using System.Collections.Generic;
using Domain;
using logic.Queries;


namespace logic
{
    public class MenusLogic : IABM<MenusDto>
    {
        private readonly MenuQueries MenuQueri;

        public MenusLogic()
        {
            this.MenuQueri = new MenuQueries();
        }
        public void Delete(int id)
        {
            try
            {
                this.MenuQueri.DeleteQuerie(id);
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
                return this.MenuQueri.GetAllQuerie();
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
                return this.MenuQueri.GetAllFilterDateQuerie(date);

            }catch(Exception e)
            {
                throw e;
            }
        }

        public MenusDto GetById(int id)
        {
            try
            {
                return this.MenuQueri.GetByIdQuerie(id);
                
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
                this.MenuQueri.InsertQuerie(menuDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(MenusDto menuDto)
        {
            try
            {
                this.MenuQueri.UpdateQuerie(menuDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
