using SolarisRec.UI.UIModels;

namespace SolarisRec.UI.Mappers.ToDomainModel
{
    internal class CostMapper : IMapToDomainModel<Cost, Core.Card.Cost>
    {
        public Core.Card.Cost Map(Cost input)
        {
            return new Core.Card.Cost
            {
                Quantity = input.Quantity,
                ResourceType = input.ResourceType
            };
        }
    }
}