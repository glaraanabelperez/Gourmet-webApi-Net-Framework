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
    public class UserControllers : ApiController, IABMControllers<UserRequest>
    {
        public UsersLogic userLogic = new UsersLogic();

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                UsersDto user =userLogic.GetById(id);
                return Ok(user);
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
                List<UsersDto> useresList;
                useresList = userLogic.GetAll();
                return Ok(useresList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBy([FromUri] string state)
        {
            try
            {
                List<UsersDto> usersDtoList;
                usersDtoList = userLogic.GetBy(state);
                return Ok(usersDtoList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBy([FromUri] string email, string pass)
        {
            try
            {
                UsersDto user = this.userLogic.Login(email, pass);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }


        [HttpPost]
        public IHttpActionResult Insert([FromBody] UserRequest UserRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userLogic.Insert(UserRequest.MapToUserDto());
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
                    userLogic.Update(id, state);
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