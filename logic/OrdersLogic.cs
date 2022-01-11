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
    public class OrdersLogic : BaseLogic, IABM<OrdersDto>
    {

        public void Delete(int id)
        {
            try
            {

                var order = (from o in context.Orders
                             where o.id == id
                             select o).Single();
                var validarFecha = new OrdersGreaterThanValidator();
                validarFecha.ValidateAndThrow(order.Menus.date);
                order.state = "borrado";
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Cancel(int id)
        {
            try
            {

                var order = (from o in context.Orders
                             where o.id == id
                             select o).Single();
                var validarFecha = new OrdersDateLessThanValidator();
                validarFecha.ValidateAndThrow(order.Menus.date);
                order.state = "Cancelado";
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
                var orderList = context.Orders.Where(x => x.state == "pendiente" || x.state == "entregado").ToList();
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

        public List<OrdersDto> GetAllFilterDate(string date)
        {
            try
            {
                var orderList = context.Orders.Where(x =>
                               x.Menus.date.ToString() == date && (x.state == "pendiente" || x.state == "entregado")).ToList();

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

        public List<OrdersDto> GetAllFilterUserQuerie(int idUser)
        {
            try
            {
                var orderList = context.Orders.Where(x =>
                x.idUser == idUser && (x.state == "pendiente" || x.state == "entregado")).ToList();

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

        public OrdersDto GetById(int id)
        {
            try
            {
               var order = context.Orders.Single(x => x.id == id && x.state == "pendiente" || x.state == "entregado");
               return order.MapToOrdersDto();
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
               var validateDto = new OrdersInsertValidator();
                validateDto.ValidateAndThrow(OrdersDto);

               var menuDate = context.Menus.Single(x => x.id == OrdersDto.idMenu);
               var validateMenuDate = new OrdersGreaterThanValidator();
                validateMenuDate.ValidateAndThrow(menuDate.date);

               Orders order = OrdersDto.MapToOrder();
               var m = context.Orders.Add(order);
               context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, OrdersDto OrdersDto)
        {
            try
            {
                var validar = new OrdersUpdateValidator();
                validar.ValidateAndThrow(OrdersDto);

                Orders Order = context.Orders.Single(x => x.id == id);
                var validarFecha = new OrdersGreaterThanValidator();
                validarFecha.ValidateAndThrow(Order.Menus.date);

                Order.amount = OrdersDto.amount;
                Order.deliveryAddress = OrdersDto.deliveryAddress;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateState(int id, string state)
        {
            //Pendiente vs entregado; accion admin
            try
            {
                Orders Order = context.Orders.Single(x => x.id == id);
                var validarFecha = new OrdersDateLessThanValidator();
                validarFecha.ValidateAndThrow(Order.Menus.date);
                Order.state = state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
          
        }

       
    }

}
