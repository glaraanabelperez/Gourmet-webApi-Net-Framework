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
    public class MealsController : ApiController, IABMControllers<MealsRequest>
    {
        public MealsLogic mealsLogic = new MealsLogic();


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                MealsDto menuDto=mealsLogic.GetById(id);
                return Ok(menuDto);
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
                List<MealsDto> mealsDtoList;
                mealsDtoList = mealsLogic.GetAll();
                return Ok(mealsDtoList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBy([FromUri]  string state)
        {
            try
            {
                List<MealsDto> MealsDtoList;
                MealsDtoList = mealsLogic.GetBy(state);
                return Ok(MealsDtoList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
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
        public IHttpActionResult Update([FromUri] int id, string state)
        {
            if (States.statesMenusMeals.Contains(state))
            {
                try
                {
                    mealsLogic.Update(id, state);
                    return Content(HttpStatusCode.OK, "Accion exitosa");
                }
                catch (Exception e )
                {
                    return Content(HttpStatusCode.BadRequest, e.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "El estado a asignar no existe");
            }

        }
    }
}