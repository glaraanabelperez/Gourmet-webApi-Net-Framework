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
    public class CompaniesController : ApiController, IABMControllers<CompaniesRequest>
    {
        public CompaniesLogic companyLogic = new CompaniesLogic();


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                CompaniesDto cd = companyLogic.GetById(id);
                return Ok(cd);
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
                List<CompaniesDto> cList;
                cList = companyLogic.GetAll();
                return Ok(cList);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Insert([FromBody] CompaniesRequest companyRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    companyLogic.Insert(companyRequest.MapToCompaniesDto());
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

        public IHttpActionResult Update([FromUri] int id, string state)
        {
            throw new NotImplementedException();
        }
    
    }
}