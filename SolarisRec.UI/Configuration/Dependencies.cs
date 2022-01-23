using Microsoft.Extensions.DependencyInjection;
using SolarisRec.Core.CardType;
using SolarisRec.Core.Faction;
using SolarisRec.Core.Keyword;
using SolarisRec.Core.ResourceCost;
using SolarisRec.UI.Components.Dropdown;
using SolarisRec.UI.Mappers;
using SolarisRec.UI.Providers;
using SolarisRec.UI.Services;
using SolarisRec.UI.UIModels;
using SolarisRec.UI.Utility;
using CoreCard = SolarisRec.Core.Card;

namespace SolarisRec.UI.Configuration
{
    public static class Dependencies
    {
        public static IServiceCollection UseSolarisRecUi(this IServiceCollection serviceCollection)
        {
            return serviceCollection                
                .AddTransient<IMapToDropdownItem<Faction, DropdownItem>, Mappers.ToDropdownItems.FactionMapper>()
                .AddTransient<IFactionDropdownItemProvider, FactionDropdownItemProvider>()
                
                .AddTransient<IMapToDropdownItem<Core.Talent.Talent, DropdownItem>, Mappers.ToDropdownItems.TalentMapper>()
                .AddTransient<ITalentDropdownItemProvider, TalentDropdownItemProvider>()

                .AddTransient<IMapToDropdownItem<CardType, DropdownItem>, Mappers.ToDropdownItems.CardTypeMapper>()
                .AddTransient<ICardTypeDropdownProvider, CardTypeDropdownProvider>()

                .AddTransient<IMapToDropdownItem<Keyword, DropdownItem>, Mappers.ToDropdownItems.KeywordMapper>()
                .AddTransient<IKeywordDropdownItemProvider, KeywordDropdownItemProvider>()

                .AddTransient<IMapToDropdownItem<ConvertedResourceCost, DropdownItem>, Mappers.ToDropdownItems.ConvertedResourceCostMapper>()
                .AddTransient<IConvertedResourceCostDropdownItemProvider, ConvertedResourceCostDropdownItemProvider>()

                .AddTransient<IMapToUIModel<Core.Faction.FactionInformation, UIModels.FactionInformation>, Mappers.ToUIModel.FactionInformationMapper>()
                .AddTransient<IFactionInformationProvider, FactionInformationProvider>()

                .AddTransient<IPagingValuesProvider, PagingValuesProvider>()

                .AddTransient<IDeckGenerator, DeckGenerator>()
                .AddTransient<IFileSaveService, FileSaveService>()

                .AddTransient<ICardProvider, CardProvider>()
                .AddTransient<IMapToUIModel<CoreCard.Card, Card>, Mappers.ToUIModel.CardMapper>()
                .AddTransient<IMapToUIModel<CoreCard.Talent, Talent>, Mappers.ToUIModel.TalentMapper>()
                .AddTransient<IMapToUIModel<CoreCard.Cost, Cost>, Mappers.ToUIModel.CostMapper>()

                .AddTransient<IMapToDomainModel<Talent, CoreCard.Talent>, Mappers.ToDomainModel.TalentMapper>()
                .AddTransient<IMapToDomainModel<Cost, CoreCard.Cost>, Mappers.ToDomainModel.CostMapper>()
                .AddTransient<IMapToDomainModel<DeckItem, Core.Deck.DeckItem>, Mappers.ToDomainModel.DeckItemMapper>()
                .AddTransient<IMapToDomainModel<Card, CoreCard.Card>, Mappers.ToDomainModel.CardMapper>()
                .AddTransient<IDeckValidator, DeckValidator>()

                .AddTransient<ISaveDeckListService, SaveDeckListService>()
                .AddTransient<IMapToDomainModel<DeckList, Core.Deck.DeckList>, Mappers.ToDomainModel.DeckListMapper>()

                .AddTransient<ILogExceptionEvent, ExceptionEventLogger>()
                ;
        }       
    }
}