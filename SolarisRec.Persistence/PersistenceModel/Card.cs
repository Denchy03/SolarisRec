using SolarisRec.Persistence.PersistenceModel.JoiningTables;
using System.Collections.Generic;

namespace SolarisRec.Persistence.PersistenceModel
{
    public class Card
    {
        public Card()
        {
            CardTalents = new HashSet<CardTalent>();
            CardResources = new HashSet<CardResource>();
            CardFactions = new HashSet<CardFaction>();
            DeckItems = new HashSet<DeckItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Unique { get; set; }

        public string Ability { get; set; }

        public int Type { get; set; }

        public int? AttackValue { get; set; }

        public int? HealthValue { get; set; }
        
        public int ExpansionId { get; set; }

        public Expansion Expansion { get; set; }

        public string ExpansionSerialNumber { get; set; }
        
        public virtual ICollection<CardFaction> CardFactions { get; set; }
        
        public virtual ICollection<CardTalent> CardTalents { get; set; }
       
        public virtual ICollection<CardResource> CardResources { get; set; }

        public virtual ICollection<DeckItem> DeckItems { get; set; }
    }
}