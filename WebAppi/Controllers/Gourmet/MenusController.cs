﻿using System;
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
    public class MenusController : ApiController, IABMControllers<MenusRequest>
    {
        public MenusLogic menuLogic = new MenusLogic();


        [HttpGet]
        public IHttpActionResult GetById(int id)
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
        public IHttpActionResult GetBy([FromUri] string date, string state)
        {
            try
            {
                List<MenusDto> menuDtoList;
                menuDtoList = menuLogic.GetBy(date, state);
                return Ok(menuDtoList);
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
            if (ModelState.IsValid)
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
                    menuLogic.Update(id, state);
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