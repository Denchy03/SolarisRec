using SolarisRec.UI.UIModels;
using System.Threading.Tasks;

namespace SolarisRec.UI.Services
{
    internal interface ISaveDeckListService
    {
        Task Save(DeckList deckList);
    }
}