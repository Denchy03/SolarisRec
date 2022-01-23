using System;
using System.Collections.Generic;

namespace SolarisRec.Persistence.PersistenceModel
{
    public class Deck
    {
        public Deck()
        {
            DeckItems = new HashSet<DeckItem>();
        }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<DeckItem> DeckItems { get; set; }
    }
}