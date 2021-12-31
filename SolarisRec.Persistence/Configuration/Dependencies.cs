﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolarisRec.Core.Account;
using SolarisRec.Core.Account.Processes.SecondaryPorts;
using SolarisRec.Core.Card;
using SolarisRec.Core.Card.Processes.SecondaryPorts;
using SolarisRec.Core.Deck.Processes.SecondaryPorts;
using SolarisRec.Persistence.Mappers;
using SolarisRec.Persistence.Repositories;

namespace SolarisRec.Persistence.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection UseSolarisRecPersistenceAdapters(this IServiceCollection serviceCollection, string connectionstring)
        {
            return serviceCollection
                .AddDbContext<SolarisRecDbContext>()
                .AddTransient((s) => CreateSolarisDbContext(connectionstring))
                
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Account, Account>, Mappers.ToDomainModel.AccountMapper>()
                .AddTransient<IMapToPersistenceModel<Account, PersistenceModel.Account>, Mappers.ToPersistenceModel.AccountMapper>()
                
                .AddTransient<IDeckRepository, DeckRepository>()
                
                .AddTransient<ICardRepository, CardRepository>()
                .AddTransient<IMapToDomainModel<PersistenceModel.Card, Card>, Mappers.ToDomainModel.CardMapper>()
                .AddTransient<IMapToPersistenceModel<Card, PersistenceModel.Card>, Mappers.ToPersistenceModel.CardMapper>();
        }

        private static SolarisRecDbContext CreateSolarisDbContext(string connectionstring)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SolarisRecDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            return new SolarisRecDbContext(optionsBuilder.Options);
        }
    }
}