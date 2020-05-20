using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.Common
{
    public class Logger
    {
        private static log4net.ILog log;
        public static void InitLogger()
        {
            log4net.Config.XmlConfigurator.Configure();

            log= log4net.LogManager.GetLogger("Instrument.Logging");//获取一个日志记录器          
        }

        /// <summary>
        /// 打印Info
        /// </summary>
        /// <param name="InfoMessage"></param>
        public static void Logger_Info(string InfoMessage)
        {
            log.Info(DateTime.Now.ToString() + ": " + InfoMessage);
        }

        /// <summary>
        /// 打印Warn
        /// </summary>
        /// <param name="WarnMessage"></param>
        public static void Logger_Warn(string WarnMessage)
        {
            log.Warn(DateTime.Now.ToString() + ": " + WarnMessage);
        }

        /// <summary>
        /// 打印Error
        /// </summary>
        /// <param name="ErrorMessage"></param>
        public static void Logger_Error(string ErrorMessage)
        {
            log.Error(DateTime.Now.ToString() + ": " + ErrorMessage);
        }
    }
}
