using Microsoft.EntityFrameworkCore;
using SolarisRec.Core.Talent;
using SolarisRec.Core.Talent.Processes.SecondaryPorts;
using SolarisRec.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolarisRec.Persistence.Repositories
{
    internal class TalentRepository : ITalentRepository
    {
        private readonly IDbContextFactory<SolarisRecDbContext> contextFactory;
        private readonly IMapToDomainModel<PersistenceModel.Talent, Talent> persistenceModelMapper;

        public TalentRepository(
            IDbContextFactory<SolarisRecDbContext> contextFactory,
            IMapToDomainModel<PersistenceModel.Talent, Talent> persistenceModelMapper)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            this.persistenceModelMapper = persistenceModelMapper ?? throw new ArgumentNullException(nameof(persistenceModelMapper));
        }

        public async Task<List<Talent>> List()
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var result = new List<Talent>();

            var allTalents = await context.Talents.ToListAsync();

            if (allTalents.Count > 0)
            {
                foreach (var talent in allTalents)
                {
                    result.Add(persistenceModelMapper.Map(talent));
                }
            }

            return result;
        }
    }
}