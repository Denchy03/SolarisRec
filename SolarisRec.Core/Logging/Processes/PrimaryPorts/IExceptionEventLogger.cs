using System;
using System.Threading.Tasks;

namespace SolarisRec.Core.Logging.Processes.PrimaryPorts
{
    public interface IExceptionEventLogger
    {
        Task Log(Exception ex);
    }
}