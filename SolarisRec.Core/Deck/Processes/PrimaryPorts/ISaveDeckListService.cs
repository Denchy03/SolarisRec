using System.Threading.Tasks;

namespace SolarisRec.Core.Deck.Processes.PrimaryPorts
{
    public interface ISaveDeckListService
    {
        Task Save(DeckList deckList);
    }
}