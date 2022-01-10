using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain;
using logic;
using logic.Utils;

namespace WebAppi.Controllers.Gourmet
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MenusController : ApiController, IABMControllers<MenusRequest>
    {
        public MenusLogic menuLogic = new MenusLogic();

        public IHttpActionResult Delete(int id)
        {
            try
            {
                menuLogic.Delete(id);
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
                MenusDto menuDto=menuLogic.GetById(id);
                return Ok(menuDto);
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
                List<MenusDto> menuDtoList;
                menuDtoList = menuLogic.GetAllFilterDate(date);
                return Ok(menuDtoList);
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
                List<MenusDto> menuDtoList;
                menuDtoList = menuLogic.GetAll();
                return Ok(menuDtoList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insert([FromBody] MenusRequest menuRequest)
        {
            try
            {
                menuLogic.Insert(menuRequest.MapToMenuDto());
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] MenusRequest menuRequest)
        {
            try
            {
                menuLogic.Update(menuRequest.MapToMenuDto());
                return Content(HttpStatusCode.OK, "Accion exitosa");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}