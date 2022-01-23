using SolarisRec.Core.Logging.Processes.SecondaryPorts;
using System;
using System.Threading.Tasks;

namespace SolarisRec.Persistence.Repositories
{
    internal class ExceptionEventRepository : IExceptionEventRepository
    {
        private readonly SolarisRecDbContext context;

        public ExceptionEventRepository(
            SolarisRecDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Log(Exception ex)
        {
            await context.ExceptionEvents.AddAsync(new PersistenceModel.ExceptionEvent { Message = ex.Message, CallStack = ex.StackTrace });
            await context.SaveChangesAsync();
        }
    }
}