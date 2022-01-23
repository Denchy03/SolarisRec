using SolarisRec.Core.Logging.Processes.PrimaryPorts;
using System;
using System.Threading.Tasks;

namespace SolarisRec.UI.Services
{
    internal class ExceptionEventLogger : ILogExceptionEvent
    {
        private readonly IExceptionEventLogger exceptionEventLogger;

        public ExceptionEventLogger(
            IExceptionEventLogger exceptionEventLogger)
        {
            this.exceptionEventLogger = exceptionEventLogger ?? throw new ArgumentNullException(nameof(exceptionEventLogger));
        }

        public async Task Log(Exception ex)
        {
            await exceptionEventLogger.Log(ex);
        }
    }
}