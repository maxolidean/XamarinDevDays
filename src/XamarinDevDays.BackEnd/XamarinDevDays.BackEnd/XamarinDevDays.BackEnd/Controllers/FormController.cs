using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using XamarinDevDays.BackEnd.Models;

namespace XamarinDevDays.BackEnd.Controllers
{
    [RoutePrefix("api/form")]
    public class FormController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var form = new FormModel
            {
                Email = "ivanc@lagash.com",
                Name = "Ivan",
                LastName = "Caro"
            };

            await form.Create().ConfigureAwait(false);

            var data = form.GetAll2();
            return Ok(data);
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody]FormModel form)
        {
           
        }
    }
}
