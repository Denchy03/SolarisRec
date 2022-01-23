using Microsoft.Extensions.DependencyInjection;
using SolarisRec.Core.Account;
using SolarisRec.Core.Account.Processes;
using SolarisRec.Core.Account.Processes.PrimaryPorts;
using SolarisRec.Core.Account.Processes.SecondaryPorts;
using SolarisRec.Core.Card.Processes;
using SolarisRec.Core.Card.Processes.PrimaryPorts;
using SolarisRec.Core.CardType.Processes;
using SolarisRec.Core.CardType.Processes.PrimaryPorts;
using SolarisRec.Core.Deck.Processes;
using SolarisRec.Core.Deck.Processes.PrimaryPorts;
using SolarisRec.Core.Faction.Processes;
using SolarisRec.Core.Faction.Processes.PrimaryPorts;
using SolarisRec.Core.Keyword.Processes;
using SolarisRec.Core.Keyword.Processes.PrimaryPorts;
using SolarisRec.Core.ResourceCost.Processes;
using SolarisRec.Core.ResourceCost.Processes.PrimaryPorts;
using SolarisRec.Core.Talent.Processes;
using SolarisRec.Core.Talent.Processes.PrimaryPorts;

namespace SolarisRec.Core.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection UseSolarisRecCore(this IServiceCollection serviceCollection)
        {
            return serviceCollection                
                .AddTransient<IRegisterAccountService, RegisterAccountService>()
                .AddTransient<ILoginService, LoginService>()
                .AddTransient<IHashPassword, PasswordHasher>()
                .AddTransient<IProvideCardService, ProvideCardService>()
                .AddTransient<IProvideFactionService, ProvideFactionService>()
                .AddTransient<IProvideTalentService, ProvideTalentService>()
                .AddTransient<IProvideCardTypeService, ProvideCardTypeService>()
                .AddTransient<IProvideKeywordService, ProvideKeywordService>()
                .AddTransient<IProvideConvertedResourceCostService, ProvideConvertedResourceCostService>()
                .AddTransient<IProvideFactionInformationService, ProvideFactionInformationService>()
                .AddTransient<IValidateDeckService, ValidateDeckService>()
                .AddTransient<ISaveDeckListService, SaveDeckListService>()
                ;            
        }
    }
}