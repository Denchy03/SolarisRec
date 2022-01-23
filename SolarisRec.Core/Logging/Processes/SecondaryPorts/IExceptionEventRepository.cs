using System;
using System.Threading.Tasks;

namespace SolarisRec.Core.Logging.Processes.SecondaryPorts
{
    public interface IExceptionEventRepository
    {
        Task Log(Exception ex);
    }
}