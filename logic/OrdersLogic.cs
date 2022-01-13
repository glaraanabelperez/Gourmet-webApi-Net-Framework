using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic
{
    public class OrdersLogic : BaseLogic, IABM<OrdersDto>
    {

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

        public OrdersDto GetById(int id)
        {
            try
            {
                var order = context.Orders.Single(x => x.id == id);
                return order.MapToOrdersDto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<OrdersDto> GetBy(string date, string state)
        {
            try
            {
                var orderList = context.Orders.Where(x =>
                               x.Menus.date.ToString() == date && (x.state == state )).ToList();

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

        public List<OrdersDto> GetAllByUser(int idUser)
        {
            try
            {
                var orderList = context.Orders.Where(x =>
                x.idUser == idUser).ToList();

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
        
        public void Insert(OrdersDto OrdersDto)
        {         
            try
            {
                var validateDto = new OrdersInsertValidator();
                validateDto.ValidateAndThrow(OrdersDto);
                var menu = context.Menus.Single(x => x.id == OrdersDto.idMenu);
                var validateMenuDate = new OrdersGreaterThanValidator();
                validateMenuDate.ValidateAndThrow(menu.date);
                context.Orders.Add(OrdersDto.MapToOrder());
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
                var validarDatos = new OrdersUpdateValidator();
                var validarFecha = new OrdersGreaterThanValidator();
                validarDatos.ValidateAndThrow(OrdersDto);
                Orders Order = context.Orders.Single(x => x.id == id);
                validarFecha.ValidateAndThrow(Order.Menus.date);
                OrdersDto.MapToOrderUpdate(Order);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int id, string state)
        {
            Orders Order = context.Orders.Single(x => x.id == id);
            try
            {
                //accion cliente
                if (state.Equals("cancelado"))
                {
                    var validarFecha = new OrdersGreaterThanValidator();
                    validarFecha.ValidateAndThrow(Order.Menus.date);
                    Order.state = "cancelado";
                }
                else
                {
                //Pendiente - entregado ; accion admin
                    var validarFecha = new OrdersDateLessThanValidator();
                    validarFecha.ValidateAndThrow(Order.Menus.date);
                    Order.state = state;
                }
               
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
          
        }

   
    }

}
