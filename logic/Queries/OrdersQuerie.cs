using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using logic.Utils;
using logic.validations;

namespace logic.Queries
{
    public class OrdersQuerie : BaseLogic, IQuerie<OrdersDto>
    {
        public void DeleteQuerie(int id)
        {
            
            try
            {
                var order = (from o in context.Orders
                             where o.id == id
                             select o).Single();

                var validar = new OrdersGreaterThanValidator();
                validar.ValidateAndThrow(order);
                order.state = "borrado";
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<OrdersDto> GetAllQuerie()
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


        public List<OrdersDto> GetAllFilterDateQuerie(string date)
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

        public OrdersDto GetByIdQuerie(int id)
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

        public void InsertQuerie(OrdersDto OrdersDto)
        {
            try
            {
                var Order = context.Orders.Single(x => x.id == OrdersDto.id);
                var validar = new OrdersPropertiesValidator();
                validar.ValidateAndThrow(Order);
                var validarFecha = new OrdersGreaterThanValidator();

                Orders order = OrdersDto.MapToOrder();
                var m = context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateQuerie(OrdersDto OrdersDto)
        {
            try
            {
                var Order = context.Orders.Single(x => x.id == OrdersDto.id);
                var validar = new OrdersPropertiesValidator();
                validar.ValidateAndThrow(Order);
                var validarFecha = new OrdersGreaterThanValidator();
                validarFecha.ValidateAndThrow(Order);

                Order.amount = OrdersDto.amount;
                Order.deliveryAddress = OrdersDto.deliveryAddress;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateStateQuerie(OrdersDto OrdersDto)
        {
            try
            {
                var Order = context.Orders.Single(x => x.id == OrdersDto.id);
                var validar = new OrdersPropertiesValidator();
                validar.ValidateAndThrow(Order);
                var validarFecha = new OrdersDateLessThanValidator();

                Order.state = OrdersDto.state;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
