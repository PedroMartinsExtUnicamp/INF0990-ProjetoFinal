using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Player;

namespace JewelCollector.Entities.Jewels
{
    public abstract class Jewel : ICell, ICollectable
    {
        private bool _isPassable;
        public int Value { get; set; }
        public int[] Position { get; set; } = new int[2];
        public bool IsPassable 
        {
            get => _isPassable; 
            set => _isPassable = value;
        }

        public abstract void BeCollected(Robot robot);

        public abstract void Print();


    }
}