using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain;
using Domain.States;
using logic;
using logic.Utils;

namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        public OrdersLogic orderLogic = new OrdersLogic();

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
        public IHttpActionResult GetBy([FromUri] string date)
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetBy(date);
                return Ok(orderDToList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBy(int id, [FromUri] string date)
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetAllByUser(id, date);
                return Ok(orderDToList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }


        [HttpPost]
        public IHttpActionResult Insert([FromBody] List<OrdersRequest> orderRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    orderLogic.Insert(orderRequest.MapToOrderDtoList());

                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Hubo un problema con el modelo de datos");
            }

        }


        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]  StateRequest state)
        {
            //orderRequest.Equals(States.pending || States.delivered)
            if (States.statesOrders.Contains(state.state))
            {
                try
                {
                    orderLogic.Update(id, state.state, state.idUser);
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "El estado a asignar no existe");
            }

        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                orderLogic.Delete(id);
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

    }
}