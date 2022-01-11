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
        IHttpActionResult Get(int id);

        [HttpGet]
        IHttpActionResult Get();

        [HttpPost]
        IHttpActionResult Insert([FromBody] T enity);


        [HttpDelete]
        IHttpActionResult Delete(int id);

        [HttpPut]
        IHttpActionResult UpdateState([FromUri] int id, string state);
    }
}
