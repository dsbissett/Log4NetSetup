using System.Configuration;
using log4net.Appender;

namespace Logging
{
    public class SqlServerAppender : AdoNetAppender
    {
        private const string LoggingConnectionString = "LoggingConnectionString";

        public new string ConnectionString
        {
            get
            {
                return base.ConnectionString ?? ConfigurationManager.ConnectionStrings[LoggingConnectionString].ConnectionString;
            }

            set
            {
                base.ConnectionString = ConfigurationManager.ConnectionStrings[LoggingConnectionString].ConnectionString;
            }
        }
    }
}