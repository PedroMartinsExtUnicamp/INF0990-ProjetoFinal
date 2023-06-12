namespace JewelCollector.Entities.Interfaces
{
    public interface ICell
    {
        int[] Position { get; set; }
        bool IsPassable { get; set; }
        void Print();
    }
}