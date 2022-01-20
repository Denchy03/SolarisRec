using System.Collections.Generic;

namespace SolarisRec.Core.Deck.Processes.PrimaryPorts
{
    public interface IValidateDeckService
    {
        List<string> Validate(List<DeckItem> maindeck, List<DeckItem> missionDeck, List<DeckItem> tacticalDeck);
    }
}