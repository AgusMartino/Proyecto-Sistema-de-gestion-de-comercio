using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Services
{
    public class LoggerManager
    {
        private string ErrorfilePath = String.Empty;
        private string InformationalfilePath = String.Empty;
        private string TraduccionfilePath = String.Empty;
        private LoggerManager()
        {
            ErrorfilePath = ConfigurationManager.AppSettings["ErrorfilePath"];
            InformationalfilePath = ConfigurationManager.AppSettings["InformationalfilePath"];
            TraduccionfilePath = ConfigurationManager.AppSettings["TraduccionfilePath"];

        }
        private static LoggerManager logger;
        private static object Locker = new object();
        public static LoggerManager GetInstance()
        {
            if(logger == null)
            {
                lock (Locker)
                {
                    if(logger == null)
                    {
                        logger = new LoggerManager();
                    }
                }
            }
            return logger;
        }

        public void Write(string message, EventLevel eventLevel)
        {
            switch (eventLevel)
            {
                case EventLevel.Error:
                    using(StreamWriter streamWriter = new StreamWriter(ErrorfilePath, true))
                    {
                        streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}[Severity{eventLevel.ToString() }] : {message}");
                    }
                    break;
                case EventLevel.Verbose:
                    using (StreamWriter streamWriter = new StreamWriter(TraduccionfilePath, true))
                    {
                        streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}[Severity{eventLevel.ToString() }] : {message}");
                    }
                    break;
                case EventLevel.Informational:
                    using (StreamWriter streamWriter = new StreamWriter(InformationalfilePath, true))
                    {
                        streamWriter.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}[Severity{eventLevel.ToString() }] : {message}");
                    }
                    break;
            }
        }
    }
}
