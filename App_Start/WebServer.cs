using System;
using Microsoft.Owin.Hosting;
using Serilog;
using System.Configuration;

namespace SelfHostStarter
{
    public class WebServer
    {
        private IDisposable _webapp;
        private string baseUrl = ConfigurationManager.AppSettings["MyUrl"];
        public void Start()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.LiterateConsole()
            .CreateLogger();

            _webapp = WebApp.Start<Startup>(url: baseUrl);
            Console.WriteLine($"Server is running on {baseUrl}");
            Console.WriteLine("Press <enter> to stop server");
            Console.ReadLine();
        }

        public void Stop()
        {
            _webapp?.Dispose();
        }
    }
}
