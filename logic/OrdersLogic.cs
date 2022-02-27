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
    public class OrdersLogic : BaseLogic, IABM<OrdersDto>
    {
        public void Delete(int id)
        {
            try
            {
                var validarFecha = new OrdersGreaterThanValidator();
                Orders Order = context.Orders.Single(x => x.id == id);
                validarFecha.ValidateAndThrow(Order.Menus.date);

                Order.state = States.cancel;
                context.Entry(Order).State = EntityState.Modified;
                context.SaveChanges();
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
                var orderList = context.Orders.ToList();
                List<OrdersDto> list = new List<OrdersDto>();

                foreach (Orders o in orderList)
                {
                    list.Add(o.MapToOrdersDto());
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrdersDto> GetBy(string date)
        {
            try
            {
                var orderList = context.Orders.Where(x => x.Menus.date.ToString() == date).ToList();

                List<OrdersDto> list = new List<OrdersDto>();

                foreach (Orders o in orderList)
                {
                    list.Add(o.MapToOrdersDto());
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrdersDto> GetAllByUser(int idUser, String date)
        {
            try
            {
                var orderList = context.Orders.Where(x =>
                               x.Menus.date.ToString() == date && x.idUser == idUser).ToList();

                List<OrdersDto> list = new List<OrdersDto>();

                foreach (Orders o in orderList)
                {
                    list.Add(o.MapToOrdersDto());
                }

                return list;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(List<OrdersDto> OrderList)
        {

            foreach (OrdersDto o in OrderList)
            {
                try
                {
                    var menu = context.Menus.Single(x => x.id == o.idMenu);
                    var validateMenuDate = new OrdersGreaterThanValidator();
                    validateMenuDate.ValidateAndThrow(menu.date);

                    context.Orders.Add(o.MapToOrder());
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
           
        }

        public void Insert(OrdersDto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateState(int id, string state, int id_user)
        {
            try
            {
                Orders OrderToUpdate = context.Orders.Single(x => x.id == id);

                if (id_user == 1)
                {

                    var validarFecha = new OrdersDateLessThanValidator();
                    validarFecha.ValidateAndThrow(OrderToUpdate.Menus.date);
                    OrderToUpdate.state = state;
                }
                else
                {
                    var validarFecha = new OrdersGreaterThanValidator();
                    validarFecha.ValidateAndThrow(OrderToUpdate.Menus.date);
                    OrderToUpdate.state = state;
                }

                context.Entry(OrderToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateCount(int id, int amount)
        {
            try
            {
                Orders OrderToUpdate = context.Orders.Single(x => x.id == id);

               
                 var validarFecha = new OrdersGreaterThanValidator();
                 validarFecha.ValidateAndThrow(OrderToUpdate.Menus.date);
                OrderToUpdate.amount = amount;

                context.Entry(OrderToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
 
    }

}
