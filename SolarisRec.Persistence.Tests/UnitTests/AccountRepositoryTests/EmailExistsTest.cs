using FluentAssertions;
using SolarisRec.Persistence.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace SolarisRec.Persistence.Tests.UnitTests.AccountRepositoryTests
{
    //public sealed class EmailExistsTest : AccountRepositoryTestBase
    //{
    //    [Fact]
    //    public async Task EmailExistsReturnsTrue()
    //    {
    //        using (var dbContext = CreateDbContext())
    //        {
    //            sut = new AccountRepository(dbContext, persistenceModelMapper, domainModelMapper);

    //            var exists = await sut.EmailExists("unit@test.com");

    //            exists.Should().Be(true);
    //        }
    //    }

    //    [Fact]
    //    public async Task EmailDoesNotExistsReturnsFalse()
    //    {
    //        using (var dbContext = CreateDbContext())
    //        {
    //            sut = new AccountRepository(dbContext, persistenceModelMapper, domainModelMapper);
    //            var exists = await sut.EmailExists("unit@test.");

    //            exists.Should().Be(false);
    //        }
    //    }

    //    internal override SolarisRecDbContext CreateDbContext()
    //    {
    //        var account = new PersistenceModel.Account
    //        {
    //            AccountName = "Unit Test",
    //            Password = "unittest",
    //            Email = "unit@test.com"
    //        };

    //        return new SolarisRecDbContextBuilder().WithAccount(account).Build();
    //    }
    //}
}