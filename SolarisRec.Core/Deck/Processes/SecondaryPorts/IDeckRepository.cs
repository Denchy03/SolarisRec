using System.Threading.Tasks;

namespace SolarisRec.Core.Deck.Processes.SecondaryPorts
{
    public interface IDeckRepository
    {
        Task SaveDeckList(DeckList deckList); 
    }
}