using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain;
using FluentValidation;
using logic;
using logic.Utils;

namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrdersController : ApiController, IABMControllers<OrdersRequest>
    {
        public OrdersLogic orderLogic = new OrdersLogic();
        public MenusLogic menuLogic = new MenusLogic();

        public IHttpActionResult Delete(int id)
        {
            try
            {
                orderLogic.Delete(id);
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                OrdersDto orderDto= orderLogic.GetById(id);
                return Ok(orderDto);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] string date)
        {
            try
            {
                List<OrdersDto> orderDToList;
                orderDToList = orderLogic.GetAllFilterDate(date);
                return Ok(orderDToList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get()
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

        [HttpPost]
        public IHttpActionResult Insert([FromBody] OrdersRequest orderRequest)
        {
           try
           {
                var menu=menuLogic.GetById(orderRequest.idMenu);

                OrdersDto orderDto = orderRequest.MapToOrderDto();
                orderDto.MenusDto = menu;
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
            if (ModelState.IsValid)
            {
                try
                {
                    orderLogic.Update(id, orderRequest.MapToOrderDto());
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception )
                {
                    return Content(HttpStatusCode.BadRequest, "Los datos a ingresar no son correctos");
                }
            }
            else
            {
                return BadRequest();
            }
           
        }


        [Route("api/updateState")]
        [HttpPut]
        public IHttpActionResult UpdateState(int id, [FromBody] OrdersRequest orderRequest)
        {
            if (orderRequest.state!=null || orderRequest.state!="")
            {
                try
                {
                    orderLogic.UpdateState(id, state);
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.BadRequest, "Los datos a ingresar no son correctos");
                }
            }
            else
            {
                return BadRequest();
            }

        }

    }
}