using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Player;

namespace JewelCollector.Entities.Obstacles
{
    public class Tree : ICell, ICollectable, IEnergyContainer
    {
        private bool _isPassable;
        public bool IsPassable 
        {
            get => _isPassable; 
            set => _isPassable = value;
        }
        private int _energy;
        public int Energy 
        { 
            get => _energy; 
            set => _energy = value; 
        }
        public int[] Position { get; set; } = new int[2];

        public Tree()
        {
            Energy = 3;
            IsPassable = false;
        }

        public void BeCollected(Robot robot)
        {
            robot.Charge(Discharge());
        }

        public int Discharge()
        {
            int charge = 0;
            if(Energy <= 3)
            {
                charge += Energy;
                Energy -= Energy;
            }
            else
            {
                charge = 3;
                Energy -= 3;
            }

            return charge;
        }

        public void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("$$");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }
    }
}