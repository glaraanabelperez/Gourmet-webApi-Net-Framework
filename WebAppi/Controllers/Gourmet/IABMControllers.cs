using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAppi.Controllers.Gourmet
{
    interface IABMControllers<T>
    {
      
        [HttpGet]
        IHttpActionResult GetById(int id);

        [HttpGet]
        IHttpActionResult GetAll();

        [HttpGet]
        //IHttpActionResult GetByStateAndDate([FromUri] string date, string state);

        [HttpPost]
        IHttpActionResult Insert([FromBody] T enity);

        [HttpPut]
        IHttpActionResult Update([FromUri] int id, string state);
    }
}
