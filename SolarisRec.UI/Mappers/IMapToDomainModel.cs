namespace SolarisRec.UI.Mappers
{
    public interface IMapToDomainModel<TUI, TDomain>
    {
        TDomain Map(TUI input);
    }
}