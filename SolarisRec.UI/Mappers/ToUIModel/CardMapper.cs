using SolarisRec.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreCard = SolarisRec.Core.Card;

namespace SolarisRec.UI.Mappers.ToUIModel
{
    internal class CardMapper : IMapToUIModel<CoreCard.Card, Card>
    {
        private readonly IMapToUIModel<CoreCard.Cost, Cost> costToUIModelMapper;
        private readonly IMapToUIModel<CoreCard.Talent, Talent> talentToUIModelMapper;

        public CardMapper(
            IMapToUIModel<CoreCard.Cost, Cost> costToUIModelMapper,
            IMapToUIModel<CoreCard.Talent, Talent> talentToUIModelMapper)
        {
            this.costToUIModelMapper = costToUIModelMapper ?? throw new ArgumentNullException(nameof(costToUIModelMapper));
            this.talentToUIModelMapper = talentToUIModelMapper ?? throw new ArgumentNullException(nameof(talentToUIModelMapper));
        }

        public Card Map(CoreCard.Card input)
        {
            return new Card
            {
                Id = input.Id,
                Name = input.Name,
                ExpansionName = input.ExpansionName,
                ExpansionSerialNumber = input.ExpansionSerialNumber,
                Unique = input.Unique,
                Ability = input.Ability,
                Factions = input.Factions,
                Type = input.Type,
                AttackValue = input.AttackValue,
                HealthValue = input.HealthValue,
                Costs = MapCosts(input.Costs),
                Talents = MapTalents(input.Talents, input.TalentAffinity),

            };
        }

        private List<Cost> MapCosts(List<CoreCard.Cost> costs)
        {
            var result = new List<Cost>();

            foreach (var cost in costs)
            {
                result.Add(costToUIModelMapper.Map(cost));
            }

            return result;
        }

        private List<Talent> MapTalents(List<CoreCard.Talent> talents, int talentAffinity)
        {
            var result = new List<Talent>();

            foreach (var talent in talents)
            {
                result.Add(talentToUIModelMapper.Map(talent));
            }

            result = result
                .OrderByDescending(t => t.Quantity)
                .ThenBy(t => (int)t.TalentType == talentAffinity)
                .ThenBy(t => t.TalentType).ToList();

            return result;
        }        
    }
}