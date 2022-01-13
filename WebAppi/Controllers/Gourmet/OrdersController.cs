using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain;
using Domain.States;
using FluentValidation;
using logic;
using logic.Utils;

namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrdersController : ApiController, IABMControllers<OrdersRequest>
    {
        public OrdersLogic orderLogic = new OrdersLogic();

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                OrdersDto orderDto = orderLogic.GetById(id);
                return Ok(orderDto);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBy([FromUri] string date, string state)
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetBy(date, state);
                return Ok(orderDToList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetAll();
                return Ok(orderDToList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll([FromUri] int user)
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetAllByUser(user);
                return Ok(orderDToList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }


        [HttpPost]
        public IHttpActionResult Insert([FromBody] OrdersRequest orderRequest)
        {
            try
            {
                OrdersDto orderDto = orderRequest.MapToOrderDto();
                orderLogic.Insert(orderDto);

                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] OrdersRequest orderRequest)
        {
            try
            {
                orderLogic.Update(id, orderRequest.MapToOrderDto());
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
      
        }


        [HttpPut]
        public IHttpActionResult Update([FromUri] int id, string state)
        {
            if (States.statesOrders.Contains(state))
            {
                try
                {
                    orderLogic.Update(id, state);
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }

        }


    }
}