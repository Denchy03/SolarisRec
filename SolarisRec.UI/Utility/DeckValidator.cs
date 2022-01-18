using SolarisRec.Core.CardType;
using SolarisRec.UI.UIModels;
using System.Collections.Generic;
using System.Linq;

namespace SolarisRec.UI.Utility
{
    internal class DeckValidator : IDeckValidator
    {
        public const int MAIN_DECK_CARD_COUNT = 45;
        public const int TACTICAL_DECK_CARD_COUNT = 10;        
        public const int MISSION_DECK_CARD_COUNT = 5;
        public const int MAX_NON_MISSION_IN_TACTICAL_DECK = 9;
        public const int MAX_MISSION_IN_TACTICAL_DECK = 1;

        private ValidationResult validationResult = new ValidationResult();

        public ValidationResult Validate(List<DeckItem> maindeck, List<DeckItem> missionDeck, List<DeckItem> tacticalDeck)
        {
            validationResult = new ValidationResult();

            ValidateMainDeck(maindeck);

            ValidateMissionDeck(missionDeck);

            ValidateTacticalDeck(tacticalDeck);

            return validationResult;            
        }

        private void ValidateMainDeck(List<DeckItem> maindeck)
        {
            if(maindeck.Select(c => c.Quantity).Sum() != MAIN_DECK_CARD_COUNT)
            {
                validationResult.Reasons.Add($"Main Deck must consist of exactly {MAIN_DECK_CARD_COUNT} cards.");
            }          
        }

        private void ValidateMissionDeck(List<DeckItem> missionDeck)
        {            
            if (missionDeck.Select(c => c.Quantity).Sum() != MISSION_DECK_CARD_COUNT)
            {
                validationResult.Reasons.Add($"Mission Deck must consist of exactly {MAIN_DECK_CARD_COUNT} cards.");
            }            
        }

        private void ValidateTacticalDeck(List<DeckItem> tacticalDeck)
        {
            if (tacticalDeck.Select(c => c.Quantity).Sum() > TACTICAL_DECK_CARD_COUNT)
            {
                validationResult.Reasons.Add($"Tactical Deck may not have more than {MAIN_DECK_CARD_COUNT} cards.");
            }

            if (tacticalDeck.Where(d => d.Card.Type != CardTypeConstants.Mission).Count() > MAX_NON_MISSION_IN_TACTICAL_DECK)
            {
                validationResult.Reasons.Add($"Tactical Deck may not have more than {MAX_NON_MISSION_IN_TACTICAL_DECK} Main deck Cards.");
            }

            if (tacticalDeck.Where(d => d.Card.Type == CardTypeConstants.Mission).Count() > MAX_MISSION_IN_TACTICAL_DECK)
            {
                validationResult.Reasons.Add($"Tactical Deck may not have more than {MAX_MISSION_IN_TACTICAL_DECK} Mission.");
            }
        }
    }
}