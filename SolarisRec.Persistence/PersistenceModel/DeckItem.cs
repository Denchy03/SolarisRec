﻿namespace SolarisRec.Persistence.PersistenceModel
{
    public class DeckItem
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
        public Deck Deck { get; set; }
        public Card Card { get; set; }
        public int DeckType { get; set; }        
        public int Quantity { get; set; }
    }
}