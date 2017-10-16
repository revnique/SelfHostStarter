using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostStarter.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/demo/stuff")]
        public dynamic GetStuff()
        {
            dynamic rtn = new ExpandoObject();
            var d = new List<string>();
            d.Add("stuff 1");
            d.Add("double stuff");
            rtn.demoStuff = d;
            return rtn;
        }
    }
}
