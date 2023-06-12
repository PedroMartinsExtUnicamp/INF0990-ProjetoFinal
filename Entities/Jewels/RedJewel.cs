using JewelCollector.Entities.Player;

namespace JewelCollector.Entities.Jewels
{
    public class RedJewel : Jewel
    {
        public RedJewel()
        {
            Value = 100;
            IsPassable = false;
        }

        public override void BeCollected(Robot robot)
        {
            robot.Bag.Add(this);
            robot.Stage.Cells![Position[0], Position[1]] = new Empty();
            robot.Stage.JewelCount -= 1;
        }

        public override void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("JR");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }

        public override string ToString()
        {
            Print();
            return $" - Red Jewel ${Value}";
        }
    }
}