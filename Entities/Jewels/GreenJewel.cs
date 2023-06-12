using JewelCollector.Entities.Player;
namespace JewelCollector.Entities.Jewels
{
    public class GreenJewel : Jewel
    {
        public GreenJewel()
        {
            Value = 50;
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
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("JG");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }

        public override string ToString()
        {
            Print();
            return $" - Green Jewel ${Value}";
        }
    }
}