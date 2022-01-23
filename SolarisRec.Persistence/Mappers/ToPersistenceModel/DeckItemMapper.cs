using SolarisRec.Core.Deck;

namespace SolarisRec.Persistence.Mappers.ToPersistenceModel
{
    internal class DeckItemMapper : IDeckItemToPersistenceModelMapper
    {
        public PersistenceModel.DeckItem Map(DeckItem deckItem, int deckId, int decktype)
        {
            return new PersistenceModel.DeckItem
            {
                CardId = deckItem.Card.Id,
                DeckId = deckId,
                Quantity = deckItem.Quantity,
                DeckType = decktype
            };
        }
    }
}