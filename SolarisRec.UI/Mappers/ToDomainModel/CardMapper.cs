using SolarisRec.UI.UIModels;
using System;
using System.Collections.Generic;

namespace SolarisRec.UI.Mappers.ToDomainModel
{
    internal class CardMapper : IMapToDomainModel<Card, Core.Card.Card>
    {
        private readonly IMapToDomainModel<Cost, Core.Card.Cost> costToDomainModelMapper;
        private readonly IMapToDomainModel<Talent, Core.Card.Talent> talentToDomainModelMapper;

        public CardMapper(
            IMapToDomainModel<Cost, Core.Card.Cost> costToDomainModelMapper,
            IMapToDomainModel<Talent, Core.Card.Talent> talentToDomainModelMapper)
        {
            this.costToDomainModelMapper = costToDomainModelMapper ?? throw new ArgumentNullException(nameof(costToDomainModelMapper));
            this.talentToDomainModelMapper = talentToDomainModelMapper ?? throw new ArgumentNullException(nameof(talentToDomainModelMapper));
        }

        public Core.Card.Card Map(Card input)
        {
            return new Core.Card.Card
            {
                Id = input.Id,
                Name = input.Name,
                Ability = input.Ability,
                AttackValue = input.AttackValue,
                HealthValue = input.HealthValue,
                ExpansionSerialNumber = input.ExpansionSerialNumber,
                ExpansionName = input.ExpansionName,
                Factions = input.Factions,
                Unique = input.Unique,                
                Type = input.Type,
                Costs = MapCosts(input.Costs),
                Talents = MapTalents(input.Talents)                
            };
        }

        private List<Core.Card.Cost> MapCosts(List<Cost> costs)
        {
            List<Core.Card.Cost> result = new List<Core.Card.Cost>();

            foreach (var cost in costs)
            {
                result.Add(costToDomainModelMapper.Map(cost));
            }

            return result;
        }

        private List<Core.Card.Talent> MapTalents(List<Talent> talents)
        {
            List<Core.Card.Talent> result = new List<Core.Card.Talent>();

            foreach (var talent in talents)
            {
                result.Add(talentToDomainModelMapper.Map(talent));
            }

            return result;
        }       
    }
}