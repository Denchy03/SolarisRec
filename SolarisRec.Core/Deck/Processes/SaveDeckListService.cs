using SolarisRec.Core.Deck.Processes.PrimaryPorts;
using SolarisRec.Core.Deck.Processes.SecondaryPorts;
using System;
using System.Threading.Tasks;

namespace SolarisRec.Core.Deck.Processes
{
    internal class SaveDeckListService : ISaveDeckListService
    {
        private readonly IDeckRepository deckRepository;

        public SaveDeckListService(
            IDeckRepository deckRepository)
        {
            this.deckRepository = deckRepository ?? throw new ArgumentNullException(nameof(deckRepository));
        }

        public async Task Save(DeckList deckList)
        {
            await deckRepository.SaveDeckList(deckList);
        }
    }
}