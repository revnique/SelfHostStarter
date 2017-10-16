using System.Web.Http;
using Owin;
using Microsoft.Owin.Cors;

namespace SelfHostStarter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
