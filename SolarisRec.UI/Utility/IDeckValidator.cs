using SolarisRec.UI.UIModels;
using System.Collections.Generic;

namespace SolarisRec.UI.Utility
{
    public interface IDeckValidator
    {
        ValidationResult Validate(List<DeckItem> maindeck, List<DeckItem> missionDeck, List<DeckItem> tacticalDeck);        
    }
}