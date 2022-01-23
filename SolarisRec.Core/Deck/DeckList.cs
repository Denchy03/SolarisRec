using System.Collections.Generic;

namespace SolarisRec.Core.Deck
{
    public class DeckList
    {
        public List<DeckItem> MainDeck { get; set; } = new();

        public List<DeckItem> MissionDeck { get; set; } = new();

        public List<DeckItem> TacticalDeck { get; set; } = new();
    }
}