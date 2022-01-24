using Microsoft.EntityFrameworkCore;
using SolarisRec.Core.Account;
using SolarisRec.Core.Account.Processes.SecondaryPorts;
using SolarisRec.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarisRec.Persistence.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly IDbContextFactory<SolarisRecDbContext> contextFactory;
        private readonly IMapToDomainModel<PersistenceModel.Account, Account> persistenceModelMapper;
        private readonly IMapToPersistenceModel<Account, PersistenceModel.Account> domainModelMapper;

        public AccountRepository(
            IDbContextFactory<SolarisRecDbContext> contextFactory,
            IMapToDomainModel<PersistenceModel.Account, Account> persistenceModelMapper,
            IMapToPersistenceModel<Account, PersistenceModel.Account> domainModelMapper)
        {
            this.contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            this.persistenceModelMapper = persistenceModelMapper ?? throw new ArgumentNullException(nameof(persistenceModelMapper));
            this.domainModelMapper = domainModelMapper ?? throw new ArgumentNullException(nameof(domainModelMapper));
        }
       
        public async Task<bool> AccountExists(string accountName)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Accounts.AnyAsync(a => a.AccountName == accountName);
        }

        public async Task<bool> EmailExists(string email)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return await context.Accounts.AnyAsync(a => a.Email == email);
        }

        public async Task<Account> Get(string accountName)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var account = await context.Accounts
            .Where(a => a.AccountName == accountName)
            .FirstOrDefaultAsync();

            if (account == null)
            {
                throw new KeyNotFoundException($"Account with Account Name {accountName} does not exist.");
            }

            return persistenceModelMapper.Map(account);
        }

        public async Task CreateAccount(Account account)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var accountToCreate = new PersistenceModel.Account();

            domainModelMapper.Apply(account, accountToCreate);

            await context.Accounts.AddAsync(accountToCreate);
            await context.SaveChangesAsync();
        }
    }
}