using SolarisRec.Core.CardType;
using SolarisRec.Core.Deck.Processes.PrimaryPorts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarisRec.Core.Deck.Processes
{
    internal class ValidateDeckService : IValidateDeckService
    {
        public const int MAIN_DECK_CARD_COUNT = 45;
        public const int TACTICAL_DECK_CARD_COUNT = 10;        
        public const int MISSION_DECK_CARD_COUNT = 5;
        public const int MAX_NON_MISSION_IN_TACTICAL_DECK = 9;
        public const int MAX_MISSION_IN_TACTICAL_DECK = 1;
        public const int MAX_CARD_QUANTITY = 3;

        private List<string> validationResults; 

        public List<string> Validate(List<DeckItem> maindeck, List<DeckItem> missionDeck, List<DeckItem> tacticalDeck)
        {
            validationResults = new List<string>();

            ValidateMainDeck(maindeck);

            ValidateMissionDeck(missionDeck);

            ValidateTacticalDeck(tacticalDeck);

            ValidateMissionUniqueness(missionDeck, tacticalDeck);

            ValidateMaxCardQuantity(maindeck, tacticalDeck);

            return validationResults;            
        }       

        private void ValidateMainDeck(List<DeckItem> maindeck)
        {
            if(maindeck.Select(c => c.Quantity).Sum() != MAIN_DECK_CARD_COUNT)
            {
                validationResults.Add($"Main Deck must consist of exactly {MAIN_DECK_CARD_COUNT} cards.");
            }          
        }

        private void ValidateMissionDeck(List<DeckItem> missionDeck)
        {            
            if (missionDeck.Select(c => c.Quantity).Sum() != MISSION_DECK_CARD_COUNT)
            {
                validationResults.Add($"Mission Deck must consist of exactly {MISSION_DECK_CARD_COUNT} cards.");
            }            
        }

        private void ValidateTacticalDeck(List<DeckItem> tacticalDeck)
        {
            if (tacticalDeck.Select(c => c.Quantity).Sum() > TACTICAL_DECK_CARD_COUNT)
            {
                validationResults.Add($"Tactical Deck may not have more than {TACTICAL_DECK_CARD_COUNT} cards.");
            }

            if (tacticalDeck.Where(d => d.Card.Type != CardTypeConstants.Mission).Count() > MAX_NON_MISSION_IN_TACTICAL_DECK)
            {
                validationResults.Add($"Tactical Deck may not have more than {MAX_NON_MISSION_IN_TACTICAL_DECK} Main deck Cards.");
            }

            if (tacticalDeck.Where(d => d.Card.Type == CardTypeConstants.Mission).Count() > MAX_MISSION_IN_TACTICAL_DECK)
            {
                validationResults.Add($"Tactical Deck may not have more than {MAX_MISSION_IN_TACTICAL_DECK} Mission.");
            }
        }

        private void ValidateMissionUniqueness(List<DeckItem> missionDeck, List<DeckItem> tacticalDeck)
        {
            if (missionDeck.Where(m => m.Card.Type == CardTypeConstants.Mission).Select(m => m.Card.Name)
                .Any(m => tacticalDeck.Where(t => t.Card.Type == CardTypeConstants.Mission).Select(t => t.Card.Name).Contains(m)))
            {
                validationResults.Add($"The same mission can not be in both Tactical and Misison deck.");
            }
        }

        private void ValidateMaxCardQuantity(List<DeckItem> maindeck, List<DeckItem> tacticalDeck)
        {
            var maxCardQuantityViolated = maindeck.Concat(tacticalDeck)
                .GroupBy(d => d.Card.Id)
                .Select(x => new { Id = x.Key, Quantity = x.Sum(d => d.Quantity)} )
                .Any(c => c.Quantity > MAX_CARD_QUANTITY);

            if(maxCardQuantityViolated)
            {
                validationResults.Add($"No more than {MAX_CARD_QUANTITY} copies of the same card may be added.");
            }
        }
    }
}