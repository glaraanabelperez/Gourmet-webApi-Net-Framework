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
    public class MenusController : ApiController
    {
        public MenusLogic menuLogic = new MenusLogic();

        [HttpGet]
        public IHttpActionResult GetBy([FromUri] string date)
        {
            try
            {
                List<MenusDto> menuDtoList;
                menuDtoList = menuLogic.GetBy(date);
                return Ok(menuDtoList);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insert([FromBody] List <MenusRequest> menuRequestList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    menuLogic.Insert(menuRequestList.MapToMenuDtoList());
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

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]  int id)
        {
      
           try
           {
               menuLogic.Delete(id);
               return Content(HttpStatusCode.OK, "Accion exitosa");
           }
           catch (Exception e )
           {
               return Content(HttpStatusCode.BadRequest, e.Message);
           }
          

        }

 
    }
}