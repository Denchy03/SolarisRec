using CoreDeck = SolarisRec.Core.Deck;
using SolarisRec.Core.Deck.Processes.SecondaryPorts;
using System;
using System.Threading.Tasks;
using SolarisRec.Persistence.PersistenceModel;
using SolarisRec.Persistence.Mappers;
using System.Linq;
using SolarisRec.Core.Deck.Enums;

namespace SolarisRec.Persistence.Repositories
{
    internal class DeckRepository : IDeckRepository
    {
        private readonly SolarisRecDbContext context;
        private readonly IDeckItemToPersistenceModelMapper deckItemToPersistenceModelMapper;

        public DeckRepository(
            SolarisRecDbContext context,
            IDeckItemToPersistenceModelMapper deckItemToPersistenceModelMapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.deckItemToPersistenceModelMapper = deckItemToPersistenceModelMapper ?? throw new ArgumentNullException(nameof(deckItemToPersistenceModelMapper));
        }

        public async Task SaveDeckList(CoreDeck.DeckList deckList)
        {
            Deck deck = new()
            {
                CreationDate = DateTime.Now,
            };

            await context.Decks.AddAsync(deck);
            await context.SaveChangesAsync();

            await context.DeckItems.AddRangeAsync(deckList.MainDeck.Select(d => deckItemToPersistenceModelMapper.Map(d, deck.Id, (int)DeckType.Main)));
            await context.DeckItems.AddRangeAsync(deckList.MissionDeck.Select(d => deckItemToPersistenceModelMapper.Map(d, deck.Id, (int)DeckType.Mission)));
            await context.DeckItems.AddRangeAsync(deckList.TacticalDeck.Select(d => deckItemToPersistenceModelMapper.Map(d, deck.Id, (int)DeckType.Tactical)));

            await context.SaveChangesAsync();
        }
    }
}