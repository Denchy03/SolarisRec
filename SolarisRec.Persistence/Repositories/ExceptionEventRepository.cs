using Microsoft.EntityFrameworkCore;
using SolarisRec.Core.Logging.Processes.SecondaryPorts;
using System;
using System.Threading.Tasks;

namespace SolarisRec.Persistence.Repositories
{
    internal class ExceptionEventRepository : IExceptionEventRepository
    {
        private readonly IDbContextFactory<SolarisRecDbContext> contextFactory;

        public ExceptionEventRepository(
            IDbContextFactory<SolarisRecDbContext> contextFactory)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task Log(Exception ex)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            await context.ExceptionEvents.AddAsync(new PersistenceModel.ExceptionEvent { Message = ex.Message, CallStack = ex.StackTrace });
            await context.SaveChangesAsync();
        }
    }
}