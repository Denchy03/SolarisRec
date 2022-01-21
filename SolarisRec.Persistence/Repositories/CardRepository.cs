using Microsoft.EntityFrameworkCore;
using SolarisRec.Core.Card;
using SolarisRec.Core.Card.Processes.SecondaryPorts;
using SolarisRec.Persistence.Helpers;
using SolarisRec.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarisRec.Core.Card.Enums;

namespace SolarisRec.Persistence.Repositories
{
    internal class CardRepository : ICardRepository
    {
        private readonly SolarisRecDbContext context;
        private readonly IMapToDomainModel<PersistenceModel.Card, Card> persistenceModelMapper;
        private readonly IMapToPersistenceModel<Card, PersistenceModel.Card> domainModelMapper;

        public CardRepository(
            SolarisRecDbContext context,
            IMapToDomainModel<PersistenceModel.Card, Card> persistenceModelMapper,
            IMapToPersistenceModel<Card, PersistenceModel.Card> domainModelMapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.persistenceModelMapper = persistenceModelMapper ?? throw new ArgumentNullException(nameof(persistenceModelMapper));
            this.domainModelMapper = domainModelMapper ?? throw new ArgumentNullException(nameof(domainModelMapper));
        }

        public async Task<Card> Get(int id)
        {
            var card = await context.Cards
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (card == null)
            {
                throw new KeyNotFoundException($"Card with Card Id {id} does not exist.");
            }

            return persistenceModelMapper.Map(card);
        }

        public async Task<List<Card>> List()
        {
            var result = new List<Card>();

            var allCards =
                await context.Cards
                .Include(c => c.Expansion)
                .Include(c => c.CardFactions)
                    .ThenInclude(cf => cf.Faction)
                .Include(c => c.CardResources)
                    .ThenInclude(cr => cr.Resource)
                .Include(c => c.CardTalents)
                    .ThenInclude(ct => ct.Talent)
                .ToListAsync();


            if (allCards.Count > 0)
            {
                result.AddRange(allCards.Select(card => persistenceModelMapper.Map(card)));
            }

            return result;
        }

        public async Task<List<Card>> GetCardsFiltered(CardFilter filter)
        {
            var result = new List<Card>();

            var allCards =
                await context.Cards
                .Include(c => c.Expansion)
                .Include(c => c.CardFactions)
                    .ThenInclude(cf => cf.Faction)
                .Include(c => c.CardResources)
                    .ThenInclude(cr => cr.Resource)
                .Include(c => c.CardTalents)
                    .ThenInclude(ct => ct.Talent)
                .ToListAsync();

            var filteredCards = allCards.Where
                   (
                       c => (filter.Factions.Count <= 0 || c.CardFactions.Any(cf => filter.Factions.Contains(cf.FactionId)))
                        &&
                       (filter.Talents.All(t => c.CardTalents.Select(ct => ct.TalentId).Contains(t)))
                        &&
                       (filter.CardTypes.Count <= 0 || filter.CardTypes.Contains(c.Type))
                        &&
                       (string.IsNullOrEmpty(filter.Name) || c.Name.ToLower().Contains(filter.Name.ToLower()))
                        &&
                       (string.IsNullOrEmpty(filter.Ability) || c.Ability.ToLower().Contains(filter.Ability.ToLower()))
                        &&
                       (filter.Keywords.Count <= 0 || filter.Keywords.All(k => c.Ability.ToLower().Contains(k.ToLower())))
                        &&
                       (filter.ConvertedResourceCost.Count <= 0 || filter.ConvertedResourceCost.Any(crc => ConvertedResourceCostCalculator.Calculate(c.CardResources) == crc))
                   );

            if (filter.OrderBy == nameof(Card.Name) && filter.SortingDirection == (int)SortingDirection.Ascending)
            {
                filteredCards = filteredCards.OrderBy(c => c.Name).ToList();
            }
            else if (filter.OrderBy == nameof(Card.Name) && filter.SortingDirection == (int)SortingDirection.Descending)
            {
                filteredCards = filteredCards.OrderByDescending(c => c.Name).ToList();
            }
            else if (filter.OrderBy == nameof(Card.AttackValue) && filter.SortingDirection == (int)SortingDirection.Ascending)
            {
                filteredCards = filteredCards.OrderBy(c => c.AttackValue).ToList();
            }
            else if (filter.OrderBy == nameof(Card.AttackValue) && filter.SortingDirection == (int)SortingDirection.Descending)
            {
                filteredCards = filteredCards.OrderByDescending(c => c.AttackValue).ToList();
            }
            else if (filter.OrderBy == nameof(Card.HealthValue) && filter.SortingDirection == (int)SortingDirection.Ascending)
            {
                filteredCards = filteredCards.OrderBy(c => c.HealthValue).ToList();
            }
            else if (filter.OrderBy == nameof(Card.HealthValue) && filter.SortingDirection == (int)SortingDirection.Descending)
            {
                filteredCards = filteredCards.OrderByDescending(c => c.HealthValue).ToList();
            }
            else if (filter.OrderBy == nameof(Card.Costs) && filter.SortingDirection == (int)SortingDirection.Ascending)
            {
                filteredCards = filteredCards.OrderBy(c => ConvertedResourceCostCalculator.Calculate(c.CardResources)).ToList();
            }
            else if (filter.OrderBy == nameof(Card.Costs) && filter.SortingDirection == (int)SortingDirection.Descending)
            {
                filteredCards = filteredCards.OrderByDescending(c => ConvertedResourceCostCalculator.Calculate(c.CardResources)).ToList();
            }

            var enumerable = filteredCards.ToList();
            filter.MatchingCardCount = enumerable.Count;

            var paged = enumerable
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            if (paged.Count > 0)
            {
                result.AddRange(paged.Select(card => persistenceModelMapper.Map(card)));
            }

            return result;
        }

        public async Task<List<Card>> GetFactionCards(int factionId)
        {
            var result = new List<Card>();

            var cards = await context
                .Cards
                    .Include(c => c.Expansion)
                    .Include(c => c.CardFactions)
                        .ThenInclude(cf => cf.Faction)
                    .Include(c => c.CardResources)
                        .ThenInclude(cr => cr.Resource)
                    .Include(c => c.CardTalents)
                        .ThenInclude(ct => ct.Talent)
                .Where(c => c.CardFactions.Any(cf => cf.FactionId == factionId))
                .ToListAsync();

            if (cards.Count > 0)
            {
                result.AddRange(cards.Select(card => persistenceModelMapper.Map(card)));
            }

            return result;
        }
    }
}