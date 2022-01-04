using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using logic;
using WebAppi.Models.menus;


namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MenusController : ApiController, IABMControllers<MenusRequest>
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
        public IHttpActionResult GetAll()
        {
            try
            {
                List<MenusResponse> customersResponse;
                var menus = menuLogic.GetAll();
                //customersResponse = menus.Select(c => c.MapMeuToMenuResponse()).ToList();

                customersResponse = menus.Select( menu => new MenusResponse
                {
                    id = menu.id,
                    date = menu.date,
                    Meals = menu.Meals,
                    state = menu.state

                }).ToList();

                return Ok(customersResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Insert([FromBody] MenusRequest enity)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put([FromBody] MenusRequest enity)
        {
            throw new NotImplementedException();
        }
    }
}