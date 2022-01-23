using SolarisRec.UI.Utility;
using System.Collections.Generic;
using System.Linq;

namespace SolarisRec.UI.UIModels
{
    public class Card
    {
        public int Id { get; set; }

        public string ExpansionName { get; set; }

        public string ExpansionSerialNumber { get; set; }

        public string Name { get; set; }

        public bool Unique { get; set; }

        public string Ability { get; set; }

        public string Factions { get; set; }

        public int TalentAffinity { get; set; }

        public string Type { get; set; }

        public string AttackValue { get; set; }

        public string HealthValue { get; set; }

        public List<Cost> Costs { get; set; }

        public List<Talent> Talents { get; set; }

        public string ImageSrc => $@"..\Assets\Expansions\{ExpansionMap.Map(ExpansionName)}\{ExpansionSerialNumber}.jpg";

        public int ConvertedResourceCost => Costs.Select(c => c.Quantity).Sum();
    }
}
