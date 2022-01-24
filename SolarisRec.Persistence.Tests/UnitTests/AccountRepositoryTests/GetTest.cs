using FluentAssertions;
using SolarisRec.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SolarisRec.Persistence.Tests.UnitTests.AccountRepositoryTests
{
    //public sealed class GetTest : AccountRepositoryTestBase
    //{
    //    [Fact]
    //    public async Task ExistingAccountReturnsAccount()
    //    {
    //        var expected = new PersistenceModel.Account
    //        {
    //            Id = 1,
    //            AccountName = "Unit Test",
    //            Password = "unittest",
    //            Email = "unit@test.com"
    //        };

    //        using (var dbContext = CreateDbContext())
    //        {
    //            sut = new AccountRepository(dbContext, persistenceModelMapper, domainModelMapper);

    //            var result = await sut.Get("Unit Test");

    //            result.Should().BeEquivalentTo(expected);
    //        }
    //    }

    //    [Fact]
    //    public async Task NotExistingAccountThrowsException()
    //    {
    //        using (var dbContext = CreateDbContext())
    //        {
    //            sut = new AccountRepository(dbContext, persistenceModelMapper, domainModelMapper);

    //            Func<Task> act = async () => await sut.Get("Unut Tust");

    //            await act.Should()
    //                .ThrowAsync<KeyNotFoundException>()
    //                .WithMessage("Account with Account Name Unut Tust does not exist.");
    //        }
    //    }

    //    internal override SolarisRecDbContext CreateDbContext()
    //    {
    //        var account = new PersistenceModel.Account
    //        {
    //            Id = 1,
    //            AccountName = "Unit Test",
    //            Password = "unittest",
    //            Email = "unit@test.com"
    //        };

    //        return new SolarisRecDbContextBuilder().WithAccount(account).Build();
    //    }
    //}
}