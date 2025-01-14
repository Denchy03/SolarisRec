﻿using Microsoft.AspNetCore.Components;
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
using SolarisRec.UI.Services;
using System;

namespace SolarisRec.UI.Pages
{
    public partial class Deck
    {       
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ICardProvider CardProvider { get; set; }
        [Inject] private IFactionDropdownItemProvider FactionDropdownItemProvider { get; set; }
        [Inject] private ITalentDropdownItemProvider TalentDropdownItemProvider { get; set; }
        [Inject] private ICardTypeDropdownProvider CardTypeDropdownItemProvider { get; set; }
        [Inject] private IKeywordDropdownItemProvider KeywordDropdownItemProvider { get; set; }
        [Inject] private IConvertedResourceCostDropdownItemProvider ConvertedResourceCostDropdownItemProvider { get; set; }
        [Inject] private IPagingValuesProvider PagingValuesProvider { get; set; }
        [Inject] private IDeckGenerator DeckGenerator { get; set; }
        [Inject] private IDeckValidator DeckValidator { get; set; }
        [Inject] private ISaveDeckListService SaveDeckListService { get; set; }
        [Inject] private IFileSaveService SaveFile { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        [Inject] private ILogExceptionEvent ExceptionEventLogger { get; set; }

        private const int DEFAULT_PAGE_SIZE = 8;
        private const int DEFAULT_FROM_MUD_BLAZOR = 10;
        private const int START_PAGE = 0;

        private MudMultiSelectDropdown factionDropdown;
        private MudMultiSelectDropdown cardTypeDropdown;
        private MudMultiSelectDropdown crcDropdown;
        private MudMultiSelectDropdown talentsDropdown;
        private MudMultiSelectDropdown keywordDropdown;
        private MudTextField<string> searchByName;
        private MudTextField<string> searchByAbility;

        private bool hide = false;
        private bool showWhenCardSearchIsHidden => !hide;
        private Color hideEyeIconColor = Color.Error;
        private bool reload = true;
        private int MainDeckCardCount => DeckList.MainDeck.Select(d => d.Quantity).Sum();
        private int MainDeckAgentCount => DeckList.MainDeck.Where(d => d.Card.Type == nameof(CardTypeConstants.Agent)).Select(d => d.Quantity).Sum();

        private int Page { get; set; } = START_PAGE;
        private int PageSize { get; set; } = DEFAULT_PAGE_SIZE;
        private string SortLabel { get; set; } = string.Empty;
        private int SortingDirection { get; set; } = (int)Core.SortingDirection.None;
        private int TotalItems { get; set; }

        private string ImgSrc { get; set; } = @"../Assets/0Cardback.jpg";

        private List<Card> Cards { get; set; } = new();
        private DeckList DeckList { get; set; } = new();

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

        private CoreCard.CardFilter Filter { get; set; } = new CoreCard.CardFilter();
        private ValidationResult ValidationResult { get; set; } = new ValidationResult();

        private readonly ChartOptions cardTypeChartOptions = new ChartOptions
        {
            ChartPalette = new string[]
                {
                    "#5B403E",
                    "#3B3B55",
                    "#8D8D56"
                }
        };

        private string[] CardTypePieLabels = Array.Empty<string>();

        private double[] CardTypePieData { get; set; } = Array.Empty<double>();

        private ChartOptions CardFactionChartOptions { get; set; } = new ChartOptions
        {
            ChartPalette = Array.Empty<string>()            
        };

        private string[] CardFactionPieLabels { get; set; } = Array.Empty<string>();

        private double[] CardFactionPieData { get; set; } = Array.Empty<double>();

        private readonly string[] ConvertedResourceCostLables = new string[] { "1", "2", "3", "4", "5", "6" };

        private List<ChartSeries> ConvertedResourceCostSeries { get; set; } = new();

        private readonly ChartOptions convertedResourceCostChartOptions = new ChartOptions
        {
            ChartPalette = new string[]
                {
                    "#8D8D56"
                },
            DisableLegend = true
        };

        protected override void OnParametersSet()
        {

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

            ValidationResult = DeckValidator.Validate(DeckList);
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

            //This triggers the PropertyChanged event causing GetCardsFiltered to be called.
            //This is why we should not call GetCardsFiltered here to avoid double execution!
            SelectedPagingValue.Selected = PagingValues.Where(p => p.Id == 8);
        }

        private async Task ApplyDropdownFilters()
        {
            Page = START_PAGE;
            await GetCardsFiltered();
            StateHasChanged();
        }

        private async Task ApplyPaging()
        {
            PageSize = SelectedPagingValue.Selected.First().Id;
            Page = START_PAGE;

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
                try
                {
                    Cards = await CardProvider.GetCardsFiltered(Filter);
                }
                catch (Exception ex)
                {
                    await ExceptionEventLogger.Log(ex);
                    NavigationManager.NavigateTo("error");
                }
            }

            TotalItems = Filter.MatchingCardCount;
        }

        private void UpdateImageSrc(Card card)
        {
            ImgSrc = card.ImageSrc;
        }

        private void UpdateImageSrc(DeckItem deckItem)
        {
            ImgSrc = deckItem.Card.ImageSrc;
        }

        private async Task OnSearchByName(string searchTerm)
        {
            Page = START_PAGE;
            Filter.Name = searchTerm;
            await GetCardsFiltered();
        }

        private async Task OnSearchByAbility(string abilitySearchTerm)
        {
            Page = START_PAGE;
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

            Page = START_PAGE;

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
                DeckList.MainDeck = new List<DeckItem>();
                DeckList.MissionDeck = new List<DeckItem>();
                DeckList.TacticalDeck = new List<DeckItem>();
            }

            ValidationResult = DeckValidator.Validate(DeckList);
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
                card.AddCard(DeckList.TacticalDeck);
                DeckList.TacticalDeck = DeckList.TacticalDeck
                    .OrderBy(d => d.Card.Factions)
                    .ThenBy(d => d.Card.Type)
                    .ThenBy(d => d.Card.ConvertedResourceCost)
                    .ThenBy(d => d.Card.Name)
                    .ToList();

                ValidationResult = DeckValidator.Validate(DeckList);
                return;
            }

            if (isMission)
            {
                card.AddCard(DeckList.MissionDeck);
                DeckList.MissionDeck = DeckList.MissionDeck
                    .OrderBy(d => d.Card.Talents.Select(t => t.Quantity).Sum())
                    .ThenBy(d => d.Card.Name)
                    .ToList();

                ValidationResult = DeckValidator.Validate(DeckList);
                return;
            }

            card.AddCard(DeckList.MainDeck);
            DeckList.MainDeck = DeckList.MainDeck
                .OrderBy(d => d.Card.Factions)
                .ThenBy(d => d.Card.Type)
                .ThenBy(d => d.Card.ConvertedResourceCost)
                .ThenBy(d => d.Card.Name)
                .ToList();

            UpdateCharts();
            ValidationResult = DeckValidator.Validate(DeckList);
        }

        private void RemoveFromMainDeck(DeckItem deckItem)
        {
            if (!hide)
            {
                deckItem.RemoveCard(DeckList.MainDeck);
                UpdateCharts();
                ValidationResult = DeckValidator.Validate(DeckList);
            }
        }

        private void RemoveFromMissionDeck(DeckItem deckItem)
        {
            if (!hide)
            {
                deckItem.RemoveCard(DeckList.MissionDeck);
                ValidationResult = DeckValidator.Validate(DeckList);
            }
        }

        private void RemoveFromTacticalDeck(DeckItem deckItem)
        {
            if (!hide)
            {
                deckItem.RemoveCard(DeckList.TacticalDeck);
                ValidationResult = DeckValidator.Validate(DeckList);
            }
        }

        private async Task Export()
        {
            bool canBeSaved = true;

            if (!ValidationResult.IsDeckValid)
            {
                var parameters = new DialogParameters { ["reasons"] = ValidationResult.Reasons };

                var options = new DialogOptions { CloseOnEscapeKey = true };
                var dialog = DialogService.Show<ValidationDialog>("Illegal Deck state! Are you sure you want to continue?", parameters, options);
                var result = await dialog.Result;

                canBeSaved = !result.Cancelled;
            }

            if (canBeSaved)
            {
                var deck = DeckGenerator.Generate(DeckList);

                var stream = StringToStreamConverter.Convert(deck);

                using var streamRef = new DotNetStreamReference(stream: stream);

                try
                {
                    await SaveFile.Save(streamRef);
                    await SaveDeckListService.Save(DeckList);
                }
                catch (Exception ex)
                {
                    await ExceptionEventLogger.Log(ex);
                    NavigationManager.NavigateTo("error");

                }
            }
        }

        private async Task ShowValidationResultReasons()
        {
            var parameters = new DialogParameters { ["reasons"] = ValidationResult.Reasons };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = DialogService.Show<ConfirmOnlyDialog>("Your deck state is illegal, because:", parameters, options);
            await dialog.Result;
        }

        private async Task SetSorting(string sortLabel)
        {
            Page = START_PAGE;
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
            var maxPage = Filter.MatchingCardCount / Filter.PageSize;

            Math.DivRem(Filter.MatchingCardCount, Filter.PageSize, out int remains);

            if (remains == 0)
            {
                maxPage--;
            }

            switch (direction)
            {
                case PagingDirection.FirstPage:
                    Page = START_PAGE;
                    break;
                case PagingDirection.PreviousPage:
                    if (Page - 1 >= START_PAGE)
                        Page--;
                    break;
                case PagingDirection.NextPage:
                    if (Page + 1 <= maxPage)
                        Page++;
                    break;
                case PagingDirection.LastPage:
                    Page = maxPage;
                    break;
            }

            await GetCardsFiltered();
            StateHasChanged();
        }

        private void UpdateCharts()
        {
            var agentCount = DeckList.MainDeck.Where(d => d.Card.Type == CardTypeConstants.Agent).Select(d => d.Quantity).Sum();
            var maneuverCount = DeckList.MainDeck.Where(d => d.Card.Type == CardTypeConstants.Maneuver).Select(d => d.Quantity).Sum();
            var constructionCount = DeckList.MainDeck.Where(d => d.Card.Type == CardTypeConstants.Construction).Select(d => d.Quantity).Sum();

            CardTypePieData = new double[]
            {
                agentCount,
                maneuverCount,
                constructionCount
            };

            CardTypePieLabels = new string[] { $"Agents [{agentCount}]", $"Maneuvers [{maneuverCount}]", $"Constructions [{constructionCount}]" };

            var deckFactionCardCount = DeckList.MainDeck
                .GroupBy(d => d.Card.Factions)
                .Select(x => new { Factions = x.Select(d => d.Card.Factions).First(), Quantity = x.Sum(d => d.Quantity) })
                .ToArray();

            CardFactionPieData = deckFactionCardCount.Select(x => (double)x.Quantity).ToArray();

            CardFactionPieLabels = deckFactionCardCount
                .Select(x => x.Factions + $" [{deckFactionCardCount.First(d => d.Factions == x.Factions).Quantity}]")
                .ToArray();

            CardFactionChartOptions.ChartPalette = ChartHelper.GenerateChartPalette(CardFactionPieLabels);

            ConvertedResourceCostSeries = new List<ChartSeries>
            {
                new ChartSeries
                {
                    Name = "Converted Resource Cost",
                    Data = DeckList.MainDeck
                        .GroupBy(d => d.Card.ConvertedResourceCost)
                        .Select(x => new { Quantity = x.Sum(d => d.Quantity) })
                        .Select(x => (double)x.Quantity)
                        .ToArray()
                }
            };

            StateHasChanged();
        }

        private void ShowHide()
        {
            hide = !hide;

            hideEyeIconColor = hide ? Color.Success : Color.Error;
        }
    }
}