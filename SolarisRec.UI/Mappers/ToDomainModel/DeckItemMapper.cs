using SolarisRec.UI.UIModels;
using System;

namespace SolarisRec.UI.Mappers.ToDomainModel
{
    internal class DeckItemMapper : IMapToDomainModel<DeckItem, Core.Deck.DeckItem>
    {
        private readonly IMapToDomainModel<Card, Core.Card.Card> cardTodomainModelMapper;

        public DeckItemMapper(
            IMapToDomainModel<Card, Core.Card.Card> cardTodomainModelMapper)
        {
            this.cardTodomainModelMapper = cardTodomainModelMapper ?? throw new ArgumentNullException(nameof(cardTodomainModelMapper));
        }

        public Core.Deck.DeckItem Map(DeckItem input)
        {
            return new Core.Deck.DeckItem
            {
                Quantity = input.Quantity,
                Card = cardTodomainModelMapper.Map(input.Card)
            };
        }
    }
}