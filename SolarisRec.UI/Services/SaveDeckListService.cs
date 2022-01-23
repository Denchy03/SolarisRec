using SolarisRec.UI.Mappers;
using SolarisRec.UI.UIModels;
using System;
using System.Threading.Tasks;
using CorePort = SolarisRec.Core.Deck.Processes.PrimaryPorts;

namespace SolarisRec.UI.Services
{
    internal class SaveDeckListService : ISaveDeckListService
    {
        private readonly CorePort.ISaveDeckListService saveDeckListService;
        private readonly IMapToDomainModel<DeckList, Core.Deck.DeckList> deckListToDomainModelMapper;

        public SaveDeckListService(
            CorePort.ISaveDeckListService saveDeckListService,
            IMapToDomainModel<DeckList, Core.Deck.DeckList> deckListToDomainModelMapper)
        {
            this.saveDeckListService = saveDeckListService ?? throw new ArgumentNullException(nameof(saveDeckListService));
            this.deckListToDomainModelMapper = deckListToDomainModelMapper ?? throw new ArgumentNullException(nameof(deckListToDomainModelMapper));
        }

        public async Task Save(DeckList deckList)
        {
            var deckListToSave = deckListToDomainModelMapper.Map(deckList);

            await saveDeckListService.Save(deckListToSave);
        }
    }
}