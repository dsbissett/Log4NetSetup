using System;
using System.Globalization;
using log4net;

namespace Logging
{
    public class Logger : ILogger
    {
        #region ///  Private Fields  ///

        private static ILog log;

        #endregion

        #region ///  Constructor  ///

        public Logger()
        {
            log = LogManager.GetLogger(typeof(Logger));

            GlobalContext.Properties["host"] = Environment.MachineName;

            GlobalContext.Properties["xmlStackTrace"] = DBNull.Value;
        }

        #endregion

        #region ///  Methods  ///

        private void LoadXmlStackTrace(Exception ex)
        {
            var xml = new ExceptionXElement(ex);

            GlobalContext.Properties["xmlStackTrace"] = xml;
        }

        private void ClearXmlStackTrace()
        {
            GlobalContext.Properties["xmlStackTrace"] = DBNull.Value;
        }

        public void EnterMethod(string methodName)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(string.Format(CultureInfo.InvariantCulture, "Entering Method {0}", methodName));
            }
        }

        public void LeaveMethod(string methodName)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(string.Format(CultureInfo.InvariantCulture, "Leaving Method {0}", methodName));
            }
        }

        public void LogException(Exception exception)
        {
            if (log.IsErrorEnabled)
            {
                LoadXmlStackTrace(exception);

                log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", exception.Message), exception);

                ClearXmlStackTrace();
            }
        }

        public void LogError(string message)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(string.Format(CultureInfo.InvariantCulture, "{0}", message));
            }
        }

        public void LogWarningMessage(string message)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(string.Format(CultureInfo.InvariantCulture, "{0}", message));
            }
        }

        public void LogInfoMessage(string message)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(string.Format(CultureInfo.InvariantCulture, "{0}", message));
            }
        }

        #endregion 
    }
}