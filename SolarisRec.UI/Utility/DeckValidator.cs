﻿using SolarisRec.Core.Deck.Processes.PrimaryPorts;
using SolarisRec.UI.Mappers;
using SolarisRec.UI.UIModels;
using System;
using System.Collections.Generic;

namespace SolarisRec.UI.Utility
{
    internal class DeckValidator : IDeckValidator
    {
        private readonly IValidateDeckService validateDeckService;
        private readonly IMapToDomainModel<DeckItem, Core.Deck.DeckItem> deckItemToDomainModelMapper;

        public DeckValidator(
            IValidateDeckService validateDeckService,
            IMapToDomainModel<DeckItem, Core.Deck.DeckItem> deckItemToDomainModelMapper)
        {
            this.validateDeckService = validateDeckService ?? throw new ArgumentNullException(nameof(validateDeckService));
            this.deckItemToDomainModelMapper = deckItemToDomainModelMapper ?? throw new ArgumentNullException(nameof(deckItemToDomainModelMapper));
        }

        public ValidationResult Validate(List<DeckItem> maindeck, List<DeckItem> missionDeck, List<DeckItem> tacticalDeck)
        {
            var coreMaindeck = Map(maindeck);
            var coreMissionDeck = Map(missionDeck);
            var coreTacticalDeck = Map(tacticalDeck);

            var reasons = validateDeckService.Validate(coreMaindeck, coreMissionDeck, coreTacticalDeck);

            return new ValidationResult
            {
                Reasons = reasons
            };
        }

        private List<Core.Deck.DeckItem> Map(List<DeckItem> deckItems)
        {
            List<Core.Deck.DeckItem> mappedDeckItems = new List<Core.Deck.DeckItem>();

            foreach (var deckItem in deckItems)
            {
                mappedDeckItems.Add(deckItemToDomainModelMapper.Map(deckItem));
            }

            return mappedDeckItems;
        }
    }
}