using JewelCollector.Entities.Player;
using JewelCollector.Entities.Stages;

namespace Program
{
    public class JewelCollector
    {
        public static void Main(string[] args)
        {
            RandomStage stage = new RandomStage();
            stage.SetNewPlayer(0, 0);
            
            do
            {
                Console.Clear();
                stage.Print();

                ConsoleKeyInfo key = Console.ReadKey();
                if(key.KeyChar == 's')
                {
                    stage.Player?.MoveSouth();
                }
                else if(key.KeyChar == 'd')
                {
                    stage.Player?.MoveEast();
                }
                else if(key.KeyChar == 'w')
                {
                    stage.Player?.MoveNorth();
                }
                else if(key.KeyChar == 'a')
                {
                    stage.Player?.MoveWest();
                }
                else if(key.KeyChar == 'g')
                {
                    stage.Player?.Collect();
                }

                if(stage.JewelCount == 0)
                {
                    RandomStage.SizeIncrease += 1;
                    if(RandomStage.SizeIncrease == 20)
                    {
                        stage.GameVictory();
                        break;
                    }

                    stage.StageVictory();
                    Robot player = stage.Player!;
                    stage = new RandomStage(player);
                }
            }while(true);
        }
    }
}