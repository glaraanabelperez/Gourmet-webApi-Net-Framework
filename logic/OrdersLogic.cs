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
    public class OrdersLogic : IABM<OrdersDto>
    {
        private readonly OrdersQuerie OrderQuerie;

        public OrdersLogic()
        {
            this.OrderQuerie = new OrdersQuerie();
        }

        public void Delete(int id)
        {
            //accion solo para clientes    
            try
            {
                this.OrderQuerie.DeleteQuerie(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrdersDto> GetAll()
        {
            try
            {
                return this.OrderQuerie.GetAllQuerie();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public OrdersDto GetById(int id)
        {
            try
            {
                return this.OrderQuerie.GetByIdQuerie(id);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(OrdersDto OrdersDto)
        {
            try
            {
                this.OrderQuerie.InsertQuerie(OrdersDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(OrdersDto OrdersDto)
        {
            try
            {
                this.OrderQuerie.UpdateQuerie(OrdersDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateState(OrdersDto OrdersDto)
        {
            try
            {
                this.OrderQuerie.UpdateStateQuerie(OrdersDto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
