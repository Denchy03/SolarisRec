using System.Collections.Generic;

namespace SolarisRec.UI.UIModels
{
    public class DeckList
    {
        public List<DeckItem> MainDeck { get; set; } = new();

        public List<DeckItem> MissionDeck { get; set; } = new();

        public List<DeckItem> TacticalDeck { get; set; } = new();
    }
}