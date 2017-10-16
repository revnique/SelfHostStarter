using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SelfHostStarter
{
    public class GlobalErrorLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var requestScope = context.Request.GetDependencyScope();

            //var service = new Logger();
            var exception = context.Exception;
            // Write your custom logging code here
            if (exception == null) return;
            var logname = string.Format("c:\\logs\\selfhosterrors{0}.log", DateTime.Now.ToString("yyyy-M-dd dddd"));
            Trace.Listeners.Add(new TextWriterTraceListener(logname));
            Trace.AutoFlush = true;
            Trace.TraceError(exception.Message + ":::" + exception.StackTrace);
        }
    }
}
