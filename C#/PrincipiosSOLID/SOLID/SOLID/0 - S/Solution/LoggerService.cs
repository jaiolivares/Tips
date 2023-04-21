using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._0___S.Solution
{
    public interface ILoggerService

    {
        public void Info(string info);

        public void Debug(string info);

        public void Error(string message, Exception ex);
    }

    public class LoggerService : ILoggerService
    {
        public LoggerService()
        {
            //here we need to write the code for initialization
            //that is creating the log file with necessary details
        }

        public void Info(string info)
        {
            //here we need to write the code for Info information into the errorlog text file
        }

        public void Debug(string info)
        {
            //here we need to write the code for Debug information into the errorlog text file
        }

        public void Error(string message, Exception ex)
        {
            //here we need to write the code for Error information into the errorlog text file
        }
    }
}