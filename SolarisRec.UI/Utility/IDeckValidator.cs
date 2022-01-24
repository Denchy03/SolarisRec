using SolarisRec.UI.UIModels;
using System.Collections.Generic;

namespace SolarisRec.UI.Utility
{
    public interface IDeckValidator
    {
        ValidationResult Validate(DeckList deckList);        
    }
}