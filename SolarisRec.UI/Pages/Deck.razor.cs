using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using CoreCard = SolarisRec.Core.Card;
using SolarisRec.Core.CardType;
using SolarisRec.UI.Components.Dropdown;
using SolarisRec.UI.Mappers;
using SolarisRec.UI.UIModels;
using SolarisRec.UI.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarisRec.UI.Providers;

namespace SolarisRec.UI.Pages
{
    public partial class Deck
    {
        //todo: Features
        //todo: Validation for decks
        //todo: More Deck info (Agent vs non-agent count, avg crc etc.)

        //todo: CodeCleanup
        //todo: cardtype string, enum? how should I treat it? 
        //todo: FactionInformation: what is UI specific, what is domain specific?       
        //todo: check why UI has/needs reference to Persistence and fix
        //todo: clear filters shold reset sorting?
        //todo: adjust grid header/rows
        //todo: are void methods legit? Should I use Task.FromResult?
        //todo: understand scoped vs transient
        //todo: naming etc service, generator, provider etc
        //todo: move usings
        //todo: use for instead of foreach when using mappers
        //todo: converted resource cost???
        //todo: <MudTableSortLabel SortBy="new Func<TaskItemDisplayModel, object>(x => x.Name)"></MudTableSortLabel>

        [Inject] private ICardProvider CardProvider { get; set; }        
        [Inject] private IFactionDropdownItemProvider FactionDropdownItemProvider { get; set; }
        [Inject] private ITalentDropdownItemProvider TalentDropdownItemProvider { get; set; }
        [Inject] private ICardTypeDropdownProvider CardTypeDropdownItemProvider { get; set; }
        [Inject] private IKeywordDropdownItemProvider KeywordDropdownItemProvider { get; set; }
        [Inject] private IConvertedResourceCostDropdownItemProvider ConvertedResourceCostDropdownItemProvider { get; set; }
        [Inject] private IDeckGenerator DeckGenerator { get; set; }
        [Inject] private IFileSaveService SaveFile { get; set; }

        private const int DEFAULT_PAGE_SIZE = 8;
        private const int DEFAULT_FROM_MUD_BLAZOR = 10;
        private const int MAX_MISSION_SIZE = 5;

        private MudTable<Card> table;        

        private MudMultiSelectDropdown factionDropdown;
        private MudMultiSelectDropdown cardTypeDropdown;
        private MudMultiSelectDropdown crcDropdown;
        private MudMultiSelectDropdown talentsDropdown;
        private MudMultiSelectDropdown keywordDropown;
        private MudTextField<string> searchByName;
        private MudTextField<string> searchByAbility;

        private bool reload = true;
        private int mainDeckCardCount => MainDeck.Select(d => d.Quantity).Sum();
        private int mainDeckAgentCount => MainDeck.Where(d => d.Card.Type == nameof(CardTypeConstants.Agent)).Select(d => d.Quantity).Sum();

        private string ImgSrc { get; set; } = @"../Assets/0Cardback.jpg";
        private readonly int[] pageSizeOption = { 4, 6, 8, 50 };
        private List<Card> Cards { get; set; } = new List<Card>();
        private List<DeckItem> MainDeck { get; set; } = new List<DeckItem>();
        private List<DeckItem> MissionDeck { get; set; } = new List<DeckItem>();
        private List<DeckItem> TacticalDeck { get; set; } = new List<DeckItem>();

        private List<DropdownItem> FactionDropdownItems = new();
        private SelectedValues SelectedFactions = new();
        private List<DropdownItem> TalentDropdownItems = new();
        private SelectedValues SelectedTalents = new();
        private List<DropdownItem> CardTypeDropdownItems = new();
        private SelectedValues SelectedCardTypes = new();
        private List<DropdownItem> KeywordDropdownItems = new();
        private SelectedValues SelectedKeywords = new();
        private List<DropdownItem> ConvertedResourceCostDropdownItems = new();
        private SelectedValues SelectedConvertedResourceCosts = new();

        private CoreCard.CardFilter Filter { get; set; } = new CoreCard.CardFilter();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            SelectedFactions.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyDropdownFilters);
            };

            SelectedCardTypes.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyDropdownFilters);
            };

            SelectedConvertedResourceCosts.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyDropdownFilters);
            };

            SelectedTalents.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyDropdownFilters);
            };

            SelectedKeywords.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyDropdownFilters);
            };
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FactionDropdownItems = await FactionDropdownItemProvider.ProvideDropdownItems();
            TalentDropdownItems = await TalentDropdownItemProvider.ProvideDropdownItems();
            CardTypeDropdownItems = await CardTypeDropdownItemProvider.ProvideDropdownItems();
            KeywordDropdownItems = await KeywordDropdownItemProvider.ProvideDropdownItems();
            ConvertedResourceCostDropdownItems = await ConvertedResourceCostDropdownItemProvider.ProvideDropdownItems();
        }

        private async Task ApplyDropdownFilters()
        {
            await table.ReloadServerData();
        }

        private async Task<TableData<Card>> GetCardsFiltered(TableState state)
        {
            state.PageSize = state.PageSize == DEFAULT_FROM_MUD_BLAZOR ? DEFAULT_PAGE_SIZE : state.PageSize;
            table.SetRowsPerPage(state.PageSize);

            Filter.PageSize = state.PageSize;
            Filter.Page = state.Page + 1;
            Filter.Factions = SelectedFactions.Selected.Select(f => f.Id).ToList();
            Filter.Talents = SelectedTalents.Selected.Select(t => t.Id).ToList();
            Filter.CardTypes = SelectedCardTypes.Selected.Select(ct => ct.Id).ToList();
            Filter.Keywords = SelectedKeywords.Selected.Select(k => k.Name).ToList();
            Filter.ConvertedResourceCost = SelectedConvertedResourceCosts.Selected.Select(c => c.Id).ToList();
            Filter.OrderBy = state.SortLabel;
            Filter.SortingDirection = (int)state.SortDirection;

            if (reload)
            {
                Cards = await CardProvider.GetCardsFiltered(Filter);
            }

            return new TableData<Card>
            {
                Items = Cards,
                TotalItems = Filter.MatchingCardCount
            };
        }        

        public void UpdateImageSrc(Card card)
        {
            ImgSrc = card.ImageSrc;
        }

        public void UpdateImageSrc(DeckItem deckItem)
        {
            ImgSrc = deckItem.Card.ImageSrc;
        }

        private async Task OnSearchByName(string searchTerm)
        {
            reload = true;

            Filter.Name = searchTerm;
            await table.ReloadServerData();
        }

        private async Task OnSearchByAbility(string abilitySearchTerm)
        {
            reload = true;

            Filter.Ability = abilitySearchTerm;
            await table.ReloadServerData();
        }
        
        private async Task ClearFilters()
        {            
            reload = false;

            await factionDropdown.Clear();
            await cardTypeDropdown.Clear();
            await crcDropdown.Clear();
            await talentsDropdown.Clear();
            await keywordDropown.Clear();
            await searchByName.Clear();
            await searchByAbility.Clear();            

            reload = true;            

            await table.ReloadServerData();
        }

        private async Task AddToDeck(TableRowClickEventArgs<Card> card)
        {
            bool isMission = card.Item.Type == nameof(CardTypeConstants.Mission);

            if (card.MouseEventArgs.CtrlKey)
            {
                card.Item.AddCard(TacticalDeck);
                TacticalDeck = TacticalDeck
                    .OrderBy(d => d.Card.Factions)
                    .ThenBy(d => d.Card.Type)
                    .ThenBy(d => d.Card.ConvertedResourceCost)
                    .ThenBy(d => d.Card.Name)
                    .ToList();
                
                return;
            }

            if (isMission)
            {
                card.Item.AddCard(MissionDeck);
                MissionDeck = MissionDeck
                    .OrderBy(d => d.Card.Talents.Select(t => t.Quantity).Sum())
                    .ThenBy(d => d.Card.Name)
                    .ToList();
                
                return;
            } 
            
            card.Item.AddCard(MainDeck);
            MainDeck = MainDeck
                .OrderBy(d => d.Card.Factions)
                .ThenBy(d => d.Card.Type)
                .ThenBy(d => d.Card.ConvertedResourceCost)
                .ThenBy(d => d.Card.Name)
                .ToList();
            
        }

        private void RemoveFromDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(MainDeck);            
        }

        private void RemoveFromMissionDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(MissionDeck);
        }

        private void RemoveFromTacticalDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(TacticalDeck);
        }

        private async Task Export()
        {
            var deck = DeckGenerator.Generate(MainDeck, MissionDeck, TacticalDeck);

            var stream = StringToStreamConverter.Convert(deck);           

            using var streamRef = new DotNetStreamReference(stream: stream);

            await SaveFile.Save(streamRef);            
        }        
    }
}