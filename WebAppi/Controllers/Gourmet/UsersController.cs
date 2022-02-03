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
    public class UserController : ApiController, IABMControllers<UserRequest>
    {
        public UsersLogic userLogic = new UsersLogic();

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

        [Route("api/user/login")]
        public IHttpActionResult Login([FromBody] LoginRequest loginReq)
        {
            try
            {
                UsersDto user = this.userLogic.Login(loginReq.email, loginReq.pass);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [Route("api/user/insert")]
        [HttpPost]
        public IHttpActionResult Insert([FromBody] UserRequest UserRequest)
        {

            try
            {
                userLogic.Insert(UserRequest.MapToUserDto());
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
           
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] UserRequest UserRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userLogic.Update(id, UserRequest.MapToUserDto());
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