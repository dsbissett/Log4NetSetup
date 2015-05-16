using System;
using Logging;

namespace LoggingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Logger();

            log.EnterMethod("Main");

            try
            {
               log.LogInfoMessage("About to call hello world..."); 

                var fail = "Hello, world!";

                var result = Convert.ToInt64(fail);
            }
            catch (FormatException fex)
            {
                log.LogException(fex);
            }

            log.LeaveMethod("Main");
        }
    }
}
