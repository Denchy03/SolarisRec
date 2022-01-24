using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolarisRec.Core.Account;
using SolarisRec.Core.Account.Processes.SecondaryPorts;
using SolarisRec.Core.Card;
using SolarisRec.Core.Card.Processes.SecondaryPorts;
using SolarisRec.Core.Deck.Processes.SecondaryPorts;
using SolarisRec.Core.Faction;
using SolarisRec.Core.Faction.Processes.SecondaryPorts;
using SolarisRec.Core.Logging.Processes.SecondaryPorts;
using SolarisRec.Core.Talent.Processes.SecondaryPorts;
using SolarisRec.Persistence.Mappers;
using SolarisRec.Persistence.Repositories;

namespace SolarisRec.Persistence.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection UseSolarisRecPersistenceAdapters(this IServiceCollection serviceCollection, string connectionString)
        {
            return serviceCollection
                .AddDbContextFactory<SolarisRecDbContext>(opt => opt.UseSqlServer(connectionString))
                .AddDbContext<SolarisRecDbContext>(ServiceLifetime.Transient)
                .AddTransient((s) => CreateSolarisDbContext(connectionString))

                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Account, Account>, Mappers.ToDomainModel.AccountMapper>()
                .AddTransient<IMapToPersistenceModel<Account, PersistenceModel.Account>, Mappers.ToPersistenceModel.AccountMapper>()

                .AddTransient<IDeckRepository, DeckRepository>()
                .AddTransient<IDeckItemToPersistenceModelMapper, Mappers.ToPersistenceModel.DeckItemMapper>()

                .AddTransient<ICardRepository, CardRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Card, Card>, Mappers.ToDomainModel.CardMapper>()
                .AddTransient<IMapToPersistenceModel<Card, PersistenceModel.Card>, Mappers.ToPersistenceModel.CardMapper>()

                .AddTransient<IFactionRepository, FactionRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Faction, Faction>, Mappers.ToDomainModel.FactionMapper>()

                .AddTransient<ITalentRepository, TalentRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Talent, Core.Talent.Talent>, Mappers.ToDomainModel.TalentMapper>()

                .AddTransient<IExceptionEventRepository, ExceptionEventRepository>()
                ;
        }

        private static SolarisRecDbContext CreateSolarisDbContext(string connectionstring)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SolarisRecDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            optionsBuilder.EnableSensitiveDataLogging();
            return new SolarisRecDbContext(optionsBuilder.Options);
        }
    }
}