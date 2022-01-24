using Microsoft.EntityFrameworkCore;
using SolarisRec.Core.Card;
using SolarisRec.Core.Faction;
using SolarisRec.Core.Faction.Processes.SecondaryPorts;
using SolarisRec.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarisRec.Persistence.Repositories
{
    internal class FactionRepository : IFactionRepository
    {
        private readonly IDbContextFactory<SolarisRecDbContext> contextFactory;
        private readonly IMapToDomainModel<PersistenceModel.Faction, Faction> persistenceModelMapper;

        public FactionRepository(
            IDbContextFactory<SolarisRecDbContext> contextFactory,
            IMapToDomainModel<PersistenceModel.Faction, Faction> persistenceModelMapper)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            this.persistenceModelMapper = persistenceModelMapper ?? throw new ArgumentNullException(nameof(persistenceModelMapper));
        }

        public async Task<List<Faction>> List()
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var result = new List<Faction>();

            var allFactions = await context.Factions.OrderBy(f => f.Id).ToListAsync();

            if (allFactions.Count > 0)
            {
                for (int i = 0; i < allFactions.Count; i++)
                {
                    result.Add(persistenceModelMapper.Map(allFactions[i]));
                }
            }

            return result;
        }

        public async Task<int> GetFactionId(string factionName)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var faction = await context.Factions.FirstAsync(f => f.Name == factionName);

            return faction.Id;
        }
    }
}