using JewelCollector.Entities.Player;
using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Jewels;

namespace JewelCollector.Entities.Stages
{
    public abstract class Map : IMap
    {
        public ICell[,]? Cells { get; set; }
        public Robot? Player { get; set; }
        public int Size { get; set; }
        public int JewelCount { get; set; } = 0;

        public Map()
        {
            
        }

        public abstract void Fill();
        public void StageVictory()
        {
            foreach(Jewel jewel in Player!.Bag)
            {
                Player.Punctuate(jewel.Value);
            }
            Player.Bag.RemoveAll(item => item is Jewel);
        }

        public void Alocate(ICell cell, int row, int column)
        {
            cell.Position[0] = row;
            cell.Position[1] = column;
            Cells![row, column] = cell;
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine( "\n\n\n============GAME OVER============");
            Console.WriteLine(     "\n     You ran out of energy!\n");
            Console.WriteLine($"            score: {Player!.Score}");
            Environment.Exit(0);
        }

        public virtual void Print()
        {
            for(int row=0; row < Cells!.GetLength(0); row++)
            {
                for(int column=0; column < Cells.GetLength(1); column++)
                {
                    Cells[row, column].Print();
                    Console.Write(' ');
                }
                Console.Write("\n");
            }
            
            Console.Write($"SCORE: {Player!.Score}    | ");
            Console.WriteLine($"ENERGY: {Player!.Energy}");
            Console.WriteLine($"Remaining Jewels: {JewelCount}");
            Console.WriteLine($"Player's Bag: ");
            foreach (ICell item in Player!.Bag)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}