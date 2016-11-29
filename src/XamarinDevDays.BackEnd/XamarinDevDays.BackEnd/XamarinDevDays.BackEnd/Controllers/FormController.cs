using System.Threading.Tasks;
using System.Web.Http;
using NoRepo;
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
            var formModel = new FormModel();
            var data = await formModel.GetAll().ConfigureAwait(false);

            return Ok(data);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]FormModel form)
        {
            var id = await form.Create().ConfigureAwait(false);
        
            return Ok(id);
        }
    }
}
