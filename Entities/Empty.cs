using JewelCollector.Entities.Interfaces;

namespace JewelCollector.Entities
{
    public class Empty : ICell
    {
        private bool _isPassable;
        public bool IsPassable 
        { 
            get => _isPassable; 
            set => _isPassable = value;
        }
        public int[] Position { get; set; } = new int[2];

        public Empty()
        {
            IsPassable = true;
        }

        public void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("--");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }
    }

}