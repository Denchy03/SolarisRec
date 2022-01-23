using SolarisRec.UI.UIModels;
using System;
using System.Linq;
using CoreDeck = SolarisRec.Core.Deck;

namespace SolarisRec.UI.Mappers.ToDomainModel
{
    public class DeckListMapper : IMapToDomainModel<DeckList, CoreDeck.DeckList>
    {
        private readonly IMapToDomainModel<DeckItem, CoreDeck.DeckItem> deckItemToDomainModelMapper;

        public DeckListMapper(
            IMapToDomainModel<DeckItem, CoreDeck.DeckItem> deckItemToDomainModelMapper)
        {
            this.deckItemToDomainModelMapper = deckItemToDomainModelMapper ?? throw new ArgumentNullException(nameof(deckItemToDomainModelMapper));
        }

        public CoreDeck.DeckList Map(DeckList input)
        {
            CoreDeck.DeckList result = new();

            result.MainDeck.AddRange(input.MainDeck.Select(deckItem => deckItemToDomainModelMapper.Map(deckItem)));

            result.MissionDeck.AddRange(input.MissionDeck.Select(deckItem => deckItemToDomainModelMapper.Map(deckItem)));

            result.TacticalDeck.AddRange(input.TacticalDeck.Select(deckItem => deckItemToDomainModelMapper.Map(deckItem)));

            return result;
        }
    }
}