namespace JewelCollector.Entities.Interfaces
{
    public interface IEnergyContainer
    {
        int Energy { get; set; }
        int Discharge();
    }
}