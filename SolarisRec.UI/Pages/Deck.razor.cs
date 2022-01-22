using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using CoreCard = SolarisRec.Core.Card;
using SolarisRec.Core.CardType;
using SolarisRec.UI.Components.Dropdown;
using SolarisRec.UI.UIModels;
using SolarisRec.UI.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using SolarisRec.UI.Providers;
using SolarisRec.Core.Card.Enums;
using SolarisRec.UI.Components.ValidationDialog;
using SolarisRec.UI.Components.ConfirmOnlyDialog;
using SolarisRec.UI.Enums;

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
        //todo? MudPaper to component?       
                
        [Inject] private ICardProvider CardProvider { get; set; }        
        [Inject] private IFactionDropdownItemProvider FactionDropdownItemProvider { get; set; }
        [Inject] private ITalentDropdownItemProvider TalentDropdownItemProvider { get; set; }
        [Inject] private ICardTypeDropdownProvider CardTypeDropdownItemProvider { get; set; }
        [Inject] private IKeywordDropdownItemProvider KeywordDropdownItemProvider { get; set; }
        [Inject] private IConvertedResourceCostDropdownItemProvider ConvertedResourceCostDropdownItemProvider { get; set; }
        [Inject] private IPagingValuesProvider PagingValuesProvider { get; set; }
        [Inject] private IDeckGenerator DeckGenerator { get; set; }
        [Inject] private IFileSaveService SaveFile { get; set; }
        [Inject] private IDeckValidator DeckValidator { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        private const int DEFAULT_PAGE_SIZE = 8;
        private const int DEFAULT_FROM_MUD_BLAZOR = 10;

        private MudMultiSelectDropdown factionDropdown;
        private MudMultiSelectDropdown cardTypeDropdown;
        private MudMultiSelectDropdown crcDropdown;
        private MudMultiSelectDropdown talentsDropdown;
        private MudMultiSelectDropdown keywordDropdown;
        private MudTextField<string> searchByName;
        private MudTextField<string> searchByAbility;

        private bool reload = true;
        private int MainDeckCardCount => MainDeck.Select(d => d.Quantity).Sum();
        private int MainDeckAgentCount => MainDeck.Where(d => d.Card.Type == nameof(CardTypeConstants.Agent)).Select(d => d.Quantity).Sum();

        private int Page { get; set; } = 0;
        private int PageSize { get; set; } = 8;        
        private string SortLabel { get; set; } = string.Empty;
        private int SortingDirection { get; set; } = (int)Core.SortingDirection.None;
        private int TotalItems { get; set; }       

        private string ImgSrc { get; set; } = @"../Assets/0Cardback.jpg";
        
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

        private List<DropdownItem> PagingValues = new();
        private SelectedValues SelectedPagingValue = new();
        //private MudSelect<DropdownItem> PagingSelect { get; set; }

        private CoreCard.CardFilter Filter { get; set; } = new CoreCard.CardFilter();
        private ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected override void OnParametersSet() {
            
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

            SelectedPagingValue.PropertyChanged += async (sender, e) =>
            {
                if (reload)
                    await InvokeAsync(ApplyPaging);
            };

            ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);            
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            FactionDropdownItems = await FactionDropdownItemProvider.ProvideDropdownItems();
            TalentDropdownItems = await TalentDropdownItemProvider.ProvideDropdownItems();
            CardTypeDropdownItems = await CardTypeDropdownItemProvider.ProvideDropdownItems();
            KeywordDropdownItems = await KeywordDropdownItemProvider.ProvideDropdownItems();
            ConvertedResourceCostDropdownItems = await ConvertedResourceCostDropdownItemProvider.ProvideDropdownItems();
            PagingValues = await PagingValuesProvider.ProvideDropdownItems();

            Cards = await CardProvider.GetCardsFiltered(Filter);
            TotalItems = Filter.MatchingCardCount;
        }      

        private async Task ApplyDropdownFilters()
        {
            await GetCardsFiltered();
            StateHasChanged();
        }

        private async Task ApplyPaging()
        {
            PageSize = SelectedPagingValue.Selected.First().Id;

            await GetCardsFiltered();
            StateHasChanged();
        }

        private async Task GetCardsFiltered()
        {
            PageSize = PageSize == DEFAULT_FROM_MUD_BLAZOR ? DEFAULT_PAGE_SIZE : PageSize;

            Filter.PageSize = PageSize;
            Filter.Page = Page + 1;
            Filter.Factions = SelectedFactions.Selected.Select(f => f.Id).ToList();
            Filter.Talents = SelectedTalents.Selected.Select(t => t.Id).ToList();
            Filter.CardTypes = SelectedCardTypes.Selected.Select(ct => ct.Id).ToList();
            Filter.Keywords = SelectedKeywords.Selected.Select(k => k.Name).ToList();
            Filter.ConvertedResourceCost = SelectedConvertedResourceCosts.Selected.Select(c => c.Id).ToList();
            Filter.OrderBy = SortLabel;
            Filter.SortingDirection = SortingDirection;

            if (reload)
            {
                Cards = await CardProvider.GetCardsFiltered(Filter);
            }

            TotalItems = Filter.MatchingCardCount;
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
            await GetCardsFiltered();
        }

        private async Task OnSearchByAbility(string abilitySearchTerm)
        {
            reload = true;

            Filter.Ability = abilitySearchTerm;
            await GetCardsFiltered();
        }
        
        private async Task ClearFilters()
        {
            SortingDirection = (int)Core.SortingDirection.None;
            SortLabel = string.Empty;

            reload = false;

            await factionDropdown.Clear();
            await cardTypeDropdown.Clear();
            await crcDropdown.Clear();
            await talentsDropdown.Clear();
            await keywordDropdown.Clear();
            await searchByName.Clear();
            await searchByAbility.Clear();

            reload = true;

            await GetCardsFiltered();
        }

        private async Task ClearDeck()
        {
            var parameters = new DialogParameters { ["reasons"] = new List<string>() };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<ValidationDialog>("Are you sure you want to delete this deck?", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                MainDeck = new List<DeckItem>();
                MissionDeck = new List<DeckItem>();
                TacticalDeck = new List<DeckItem>();
            }            
        }

        private void AddToDeck(MouseEventArgs e, Card card)
        {
            var isMission = card.Type == nameof(CardTypeConstants.Mission);

            if (card.Id is (int)CardId.PlanetaryPolitics or (int)CardId.SearchforLostKnowledge)
            {
                return;
            }

            if (e.CtrlKey)
            {
                card.AddCard(TacticalDeck);
                TacticalDeck = TacticalDeck
                    .OrderBy(d => d.Card.Factions)
                    .ThenBy(d => d.Card.Type)
                    .ThenBy(d => d.Card.ConvertedResourceCost)
                    .ThenBy(d => d.Card.Name)
                    .ToList();

                ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
                return;
            }

            if (isMission)
            {
                card.AddCard(MissionDeck);
                MissionDeck = MissionDeck
                    .OrderBy(d => d.Card.Talents.Select(t => t.Quantity).Sum())
                    .ThenBy(d => d.Card.Name)
                    .ToList();

                ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
                return;
            }

            card.AddCard(MainDeck);
            MainDeck = MainDeck
                .OrderBy(d => d.Card.Factions)
                .ThenBy(d => d.Card.Type)
                .ThenBy(d => d.Card.ConvertedResourceCost)
                .ThenBy(d => d.Card.Name)
                .ToList();

            ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
        }

        private void RemoveFromDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(MainDeck);
            ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
        }

        private void RemoveFromMissionDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(MissionDeck);
            ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
        }

        private void RemoveFromTacticalDeck(DeckItem deckItem)
        {
            deckItem.RemoveCard(TacticalDeck);
            ValidationResult = DeckValidator.Validate(MainDeck, MissionDeck, TacticalDeck);
        }

        private async Task Export()
        {
            if(!ValidationResult.IsDeckValid)
            {               
                var parameters = new DialogParameters { ["reasons"] = ValidationResult.Reasons };

                var options = new DialogOptions { CloseOnEscapeKey = true };
                var dialog = DialogService.Show<ValidationDialog>("Illegal Deck state! Are you sure you want to continue?", parameters, options);
                var result = await dialog.Result;

                if(!result.Cancelled)
                {
                    var deck = DeckGenerator.Generate(MainDeck, MissionDeck, TacticalDeck);

                    var stream = StringToStreamConverter.Convert(deck);

                    using var streamRef = new DotNetStreamReference(stream: stream);

                    await SaveFile.Save(streamRef);
                }
            }                       
        }
        
        private async Task ShowReasons()
        {
            var parameters = new DialogParameters { ["reasons"] = ValidationResult.Reasons };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<ConfirmOnlyDialog>("Your deck state is illegal, because:", parameters, options);
            await dialog.Result;
        }

        private async Task SetSorting(string sortLabel)
        {
            SortLabel = sortLabel;

            if (SortingDirection is (int)Core.SortingDirection.None or (int)Core.SortingDirection.Descending)
            {
                SortingDirection = (int)Core.SortingDirection.Ascending;
            }
            else
            {
                SortingDirection = (int)Core.SortingDirection.Descending;
            }

            await GetCardsFiltered();
        }
        
        private async Task MovePage(PagingDirection direction)
        {
            switch (direction)
            {
                case PagingDirection.FirstPage:
                    Page = 0;
                    break;
                case PagingDirection.PreviousPage:
                    Page = Page - 1;
                    break;
                case PagingDirection.NextPage:
                    Page = Page + 1;
                    break;
                case PagingDirection.LastPage:
                    Page = Filter.MatchingCardCount / Filter.PageSize;
                    break;
            }

            await GetCardsFiltered();
            StateHasChanged();
        }
    }
}