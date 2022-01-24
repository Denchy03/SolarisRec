using FluentAssertions;
using SolarisRec.Core.Account;
using SolarisRec.Persistence.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace SolarisRec.Persistence.Tests.UnitTests.AccountRepositoryTests
{
    //public sealed class CreateAccountTest : AccountRepositoryTestBase
    //{
    //    [Fact]
    //    public async Task CreateAccountSucceeds()
    //    {
    //        var accountToCreate = new Account
    //        {
    //            Id = 1,
    //            AccountName = "Unit Test",
    //            Password = "unittest",
    //            Email = "unit@test.com"
    //        };

    //        using (var dbContext = CreateDbContext())
    //        {
    //            sut = new AccountRepository(dbContext, persistenceModelMapper, domainModelMapper);

    //            await sut.CreateAccount(accountToCreate);

    //            var result = await sut.Get("Unit Test");

    //            result.Should().BeEquivalentTo(accountToCreate);
    //        }
    //    }

    //    internal override SolarisRecDbContext CreateDbContext()
    //    {
    //        return new SolarisRecDbContextBuilder().Build();
    //    }
    //}
}