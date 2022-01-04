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
        IHttpActionResult Get(string id);

        [HttpPost]
        IHttpActionResult Insert([FromBody] T enity);

        [HttpPut]
        IHttpActionResult Put([FromBody] T enity);

        [HttpDelete]
        IHttpActionResult Delete(int id);
    }
}
