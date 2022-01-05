using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain;
using logic;



namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MenusController : ApiController, IABMControllers<MenusDto>
    {
        public MenusLogic menuLogic = new MenusLogic();

        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<MenusDto> menuDto;
                menuDto = menuLogic.GetAll();
                //menuResponse = menus.Select(menu => new MenusResponse
                //{
                //    id = menu.id,
                //    date = menu.date,
                //    Meals = menu.Meals,
                //    state = menu.state

                //}).ToList();

                return Ok(menuDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Insert([FromBody] MenusDto menuReq)
        {
            try
            {
                menuLogic.Insert(menuReq);
                return Content(HttpStatusCode.Created, menuReq);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] MenusDto enity)
        {
            throw new NotImplementedException();
        }
    }
}