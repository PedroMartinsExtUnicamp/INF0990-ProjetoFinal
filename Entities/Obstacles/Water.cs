using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Player;

namespace JewelCollector.Entities.Obstacles
{
    public class Water : ICell
    {
        private bool _isPassable;
        public bool IsPassable 
        {
            get => _isPassable; 
            set => _isPassable = value;
        }
        public Water()
        {
            IsPassable = false;
        }
        public int[] Position { get; set; } = new int[2];

        public void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("##");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }
    }
}