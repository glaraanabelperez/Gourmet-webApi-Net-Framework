//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using Domain;
//using logic;

//namespace WebAppi.Controllers.Gourmet
//{
//    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
//    public class CompaniesController :ApiController
//    {
//        public CompaniesLogic companyLogic = new CompaniesLogic();

//        [HttpGet]
//        public IHttpActionResult GetAll()
//        {
//            try
//            {
//                List<CompaniesDto> cList;
//                cList = companyLogic.GetAll();
//                return Ok(cList);
//            }
//            catch (Exception ex)
//            {
//                return Content(HttpStatusCode.BadRequest, ex.Message) ;
//            }
//        }

//    }
//}