using System;
using System.IO;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;

namespace SelfHostStarter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            //added static file hosting to the 
            string root = AppDomain.CurrentDomain.BaseDirectory;
            root = root.Replace("\\bin\\Debug", "").Replace("\\bin\\Release", "");
            root = root.Replace("\\obj\\Debug", "").Replace("\\obj\\Release", "");
            var physicalFileSystem = new PhysicalFileSystem(Path.Combine(root, "wwwroot"));
            var options = new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(options);




            app.UseCors(CorsOptions.AllowAll);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
