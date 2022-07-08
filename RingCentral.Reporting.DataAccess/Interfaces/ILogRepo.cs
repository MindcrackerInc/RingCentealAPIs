using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingCentral.Reporting.Data.Repository.Interfaces
{
    public interface ILogRepo
    {
        Task Log(long logMessage);
        Task Log(string logType, string logMessage);
        Task Log(string logType, string logMessage, string logModule);
        Task Log(string logType, string logMessage, string logModule, long loggedBy);

    }
}
