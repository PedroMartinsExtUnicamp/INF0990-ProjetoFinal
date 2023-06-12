namespace JewelCollector.Entities.Interfaces
{
    public interface IMap
    {
        void Fill();
        void Alocate(ICell cell, int row, int column);
        void Print();
    }
}