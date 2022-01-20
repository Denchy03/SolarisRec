using SolarisRec.UI.UIModels;

namespace SolarisRec.UI.Mappers.ToDomainModel
{
    internal class TalentMapper : IMapToDomainModel<Talent, Core.Card.Talent>
    {
        public Core.Card.Talent Map(Talent input)
        {
            return new Core.Card.Talent
            {
                Quantity = input.Quantity,
                TalentType = input.TalentType
            };
        }
    }
}