using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MealsController : ApiController
    {
        public MealsLogic mealsLogic = new MealsLogic();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<MealsDto> mealsDtoList;
                mealsDtoList = mealsLogic.GetAll();
                return Ok(mealsDtoList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insert([FromBody] MealsRequest mealRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mealsLogic.Insert(mealRequest.MapToMealsDto());
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

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] MealsRequest meals)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mealsLogic.Update(id, meals.MapToMealsDto());
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.BadRequest, e.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Hubo un problema con el modelo de datos");
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
          try
          {
              mealsLogic.Delete(id);
              return Content(HttpStatusCode.OK, "Accion exitosa");
          }
          catch (Exception e)
          {
              return Content(HttpStatusCode.BadRequest, e.Message);
          }
        }

    }
}