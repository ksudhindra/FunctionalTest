using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Logger
{
    public static class LogHelper
    {
        private static readonly object padlock = new object();
        //private static LogHelper instance = null;
        public static readonly log4net.ILog FrameworkLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Intialize()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"C:\Personal\MoveOut\QA Role\Assessment_LEAP\Code\FunctionalTest\FunctionalTest\Utils\LoggerConfig.xml"));
        }
        
        }
    }

