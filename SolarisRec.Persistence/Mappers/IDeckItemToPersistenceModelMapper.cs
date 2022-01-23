using SolarisRec.Persistence.PersistenceModel;
using CoreDeck = SolarisRec.Core.Deck;

namespace SolarisRec.Persistence.Mappers
{
    internal interface IDeckItemToPersistenceModelMapper
    {
        DeckItem Map(CoreDeck.DeckItem deckItem, int deckId, int decktype);
    }
}