using System.Collections.Generic;

namespace SolarisRec.UI.UIModels
{
    public class DeckList   
    {        
        public List<DeckItem> MainDeck { get; set; }

        public List<DeckItem> MissionDeck { get; set; }        

        public List<DeckItem> TacticalDeck { get; set; }       

        public DeckList()
        {
            MainDeck = new();
            MissionDeck = new();
            TacticalDeck = new();
        }         
    }
}