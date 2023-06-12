using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Player;

namespace JewelCollector.Entities.Jewels
{
    public class BlueJewel : Jewel, IEnergyContainer
    {
        private int _energy;
        public int Energy 
        { 
            get => _energy;
            set => _energy = value;
        }
        public BlueJewel()
        {
            Value = 10;
            Energy = 5;
            IsPassable = false;
        }

        public override void BeCollected(Robot robot)
        {
            robot.Charge(Discharge());
            robot.Bag.Add(this);
            robot.Stage.Cells![Position[0], Position[1]] = new Empty();
            robot.Stage.JewelCount -= 1;
        }

        public int Discharge()
        {  
            int charge = 0;
            if(Energy <= 5)
            {
                charge += Energy;
                Energy -= Energy;
            }
            else
            {
                charge = 5;
                Energy -= 5;
            }

            return charge;
        }

        public override void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("JB");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }

        public override string ToString()
        {
            Print();
            return $" - Blue Jewel ${Value}";
        }
    }
}