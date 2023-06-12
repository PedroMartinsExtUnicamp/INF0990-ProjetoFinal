using JewelCollector.Entities.Player;
using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Obstacles;
using JewelCollector.Entities.Jewels;

namespace JewelCollector.Entities.Stages
{
    public class RandomStage : Map
    {
        public static int SizeIncrease { get; set; } = 0;

        public RandomStage()
        {
            Size = 10;
            Cells = new ICell[Size+SizeIncrease, Size+SizeIncrease];
            Fill();

            foreach(ICell cell in Cells)
            {
                if(cell is Jewel)
                    JewelCount += 1;
            }
        }

        public RandomStage(Robot player) : this()
        {
            player.Stage = this;
            if(Cells![0, 0] is Jewel)
            {
                JewelCount -= 1;
            }
            Alocate(player, 0, 0);
            Player = player;
            Player.SetPosition();
        }

        public void SetNewPlayer(int row, int column)
        {
            for(int x = 0; x < Size; x++)
            {
                for(int y = 0; y < Size; y++)
                {
                    if(Cells![x, y] is Robot)
                    {
                        Cells[x, y] = new Empty();
                        break;
                    }
                }
            }
            
            Robot robot = new Robot(this);
            Alocate(robot, row, column);
            Player = robot;
            Player.SetPosition();
        }

        public override void Fill()
        {
            for(int x = 0; x < (Size+SizeIncrease); x++)
            {
                for(int y = 0; y < (Size+SizeIncrease); y++)
                {
                    Alocate(new Empty(), x, y);
                }
            }

            List<Func<ICell>> jewelsConstructorList = new List<Func<ICell>>();
            List<Func<ICell>> obstaclesConstructorList = new List<Func<ICell>>();
            
            jewelsConstructorList.Add(() => new RedJewel());
            jewelsConstructorList.Add(() => new BlueJewel());
            jewelsConstructorList.Add(() => new GreenJewel());
            
            obstaclesConstructorList.Add(() => new Tree());
            obstaclesConstructorList.Add(() => new Water());
            
            int obstaclesQuantity = (int)((Size+SizeIncrease)*1.1);
            int jewelsQuantity = (int)((Size+SizeIncrease)*0.45);
            
            for(int x = 0; x < obstaclesQuantity; x++)
            {
                AlocateRandom(obstaclesConstructorList);
            }
            
            for(int x = 0; x < jewelsQuantity; x++)
            {
                AlocateRandom(jewelsConstructorList);
            }
        }
        
        public void AlocateRandom(List<Func<ICell>> constructorsList)
        {
            Random random = new Random();
            do
            {
                int row, column;
                row = random.Next(0, Size+SizeIncrease);
                column = random.Next(0, Size+SizeIncrease);

                if(Cells![row, column] is Empty)
                {
                    int index = random.Next(0, constructorsList.Count());
                    Alocate(constructorsList[index].Invoke(), row, column);
                    break;
                }

            } while(true);
        }

        public void GameVictory()
        {
            Console.Clear();
            Console.WriteLine("     CONGRATULATIONS");
            Console.WriteLine("     YOU WON THE GAME");
            Console.Write   ($"    Final score: {Player!.Score}\n");
        }

        public override void Print()
        {
            Console.WriteLine($"STAGE-{SizeIncrease+1}");
            Console.Write($"SCORE: {Player!.Score}    | ");
            Console.WriteLine($"ENERGY: {Player!.Energy}");
            for(int row=0; row < Cells!.GetLength(0); row++)
            {
                for(int column=0; column < Cells.GetLength(1); column++)
                {
                    Cells[row, column].Print();
                    Console.Write(' ');
                }
                Console.Write("\n");
            }

            Console.WriteLine($"Remaining Jewels: {JewelCount}");
            Console.WriteLine($"Player's Bag: ");
            foreach (ICell item in Player!.Bag)
            {
                Console.WriteLine($"{item}");
            }
        }

        ~RandomStage()
        {
            Console.WriteLine($"Stage: {SizeIncrease}");
        }
    }
}