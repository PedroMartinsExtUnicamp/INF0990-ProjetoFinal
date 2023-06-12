using JewelCollector.Entities.Player;
using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Obstacles;
using JewelCollector.Entities.Jewels;

namespace JewelCollector.Entities.Stages
{
    public class TestStage : Map
    {
        public TestStage()
        {
            Size = 11;
            Cells = new ICell[Size, Size];
            Fill();

            foreach(ICell cell in Cells)
            {
                if(cell is Jewel)
                    JewelCount += 1;
            }
        }

        public TestStage(Robot player) : this()
        {
            player.Stage = this;
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
            for(int row=0; row < Size; row++)
            {
                for(int column=0; column < Size; column++)
                {
                    Alocate(new Empty(), row, column);
                }
            }

            Alocate(new Water(), 6, 4);
            Alocate(new Water(), 6, 5);
            Alocate(new Water(), 6, 6);
            Alocate(new Tree(), 5, 4);
            Alocate(new Tree(), 5, 6);
            Alocate(new RedJewel(), 3, 5);
            Alocate(new GreenJewel(), 3, 4);
            Alocate(new BlueJewel(), 3, 6);
        }
    }
}