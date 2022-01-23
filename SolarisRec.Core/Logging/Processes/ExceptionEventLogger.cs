using SolarisRec.Core.Logging.Processes.PrimaryPorts;
using SolarisRec.Core.Logging.Processes.SecondaryPorts;
using System;
using System.Threading.Tasks;

namespace SolarisRec.Core.Logging.Processes
{
    internal class ExceptionEventLogger : IExceptionEventLogger
    {
        private readonly IExceptionEventRepository exceptionEventRepository;

        public ExceptionEventLogger(
            IExceptionEventRepository exceptionEventRepository)
        {
            this.exceptionEventRepository = exceptionEventRepository ?? throw new ArgumentNullException(nameof(exceptionEventRepository));
        }

        public async Task Log(Exception ex)
        {
            await exceptionEventRepository.Log(ex);
        }
    }
}