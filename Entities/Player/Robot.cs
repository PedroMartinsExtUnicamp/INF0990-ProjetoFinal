using JewelCollector.Entities.Interfaces;
using JewelCollector.Entities.Jewels;
using JewelCollector.Entities.Stages;

namespace JewelCollector.Entities.Player
{
    public class Robot : ICell
    {
        public ICell SteppingCell { get; set; }
        private bool _isPassable;
        public bool IsPassable
        {
            get => _isPassable; 
            set => _isPassable = value;
        }
        public int Score { get; private set; } 
        public int Energy { get; set; }
        public Map Stage { get; set; }
        public List<ICollectable> Bag { get; private set; }
        public int[] Position { get; set; } = new int[2];

        public Robot(Map stage)
        {
            Energy = 5;
            Stage = stage;
            Score = 0;
            IsPassable = false;
            Bag = new List<ICollectable>();
            SteppingCell = new Empty();
        }

        public void SetPosition()
        {
            int[] position = new int[2];
            for(int row = 0; row < Stage.Cells!.GetLength(0); row++)
            {
                for(int column = 0; column < Stage.Cells.GetLength(1); column++)
                {
                    if(Stage.Cells[row, column] is Robot)
                    {
                        Position[0] = row;
                        Position[1] = column;
                        break;
                    }
                }
            }
        }

        public void MoveSouth()
        {
            try
            {
                if(Stage.Cells![Position[0]+1, Position[1]].IsPassable)
                {
                    Stage.Alocate(SteppingCell, Position[0], Position[1]);
                    SteppingCell = Stage.Cells![Position[0]+1, Position[1]];
                    Stage.Alocate(this, Position[0]+1, Position[1]);
                    SetPosition();
                    Charge(-1);
                }
            }
            catch(IndexOutOfRangeException) {}
        }
        
        public void MoveEast()
        {
            try
            {
                if(Stage.Cells![Position[0], Position[1]+1].IsPassable)
                {
                    Stage.Alocate(SteppingCell, Position[0], Position[1]);
                    SteppingCell = Stage.Cells![Position[0], Position[1]+1];
                    Stage.Alocate(this, Position[0], Position[1]+1);
                    SetPosition();
                    Charge(-1);
                }
            }
            catch(IndexOutOfRangeException) {}
        }

        public void MoveNorth()
        {
            try
            {
                if(Stage.Cells![Position[0]-1, Position[1]].IsPassable)
                {
                    Stage.Alocate(SteppingCell, Position[0], Position[1]);
                    SteppingCell = Stage.Cells![Position[0]-1, Position[1]];
                    Stage.Alocate(this, Position[0]-1, Position[1]);
                    SetPosition();
                    Charge(-1);
                }
            }
            catch(IndexOutOfRangeException) {}
        }

        public void MoveWest()
        {
            try
            {
                if(Stage.Cells![Position[0], Position[1]-1].IsPassable)
                {
                    Stage.Alocate(SteppingCell, Position[0], Position[1]);
                    SteppingCell = Stage.Cells![Position[0], Position[1]-1];
                    Stage.Alocate(this, Position[0], Position[1]-1);
                    SetPosition();
                    Charge(-1);
                }
            }
            catch(IndexOutOfRangeException) {}
        }

        public void Collect()
        {
            List<Func<ICell>> adjacentCells = LookAround();
            foreach(Func<ICell> fnc in adjacentCells)
            {
                ICell cell = fnc.Invoke();
                if(cell is ICollectable)
                {
                    ICollectable collectableCell = (ICollectable)cell;
                    collectableCell.BeCollected(this);
                    
                    cell = new Empty();
                }
            }
        }

        private List<Func<ICell>> LookAround()
        {
            List<Func<ICell>> adjacentCells = new List<Func<ICell>>();

            try
            {
                ICell _ = SouthCell();
                adjacentCells.Add(SouthCell);
            }
            catch(IndexOutOfRangeException) {}
            try
            {
                ICell _ = EastCell();
                adjacentCells.Add(EastCell);
            }
            catch(IndexOutOfRangeException) {}
            try
            {
                ICell _ = NorthCell();
                adjacentCells.Add(NorthCell);
            }
            catch(IndexOutOfRangeException) {}
            try
            {
                ICell _ = WestCell();
                adjacentCells.Add(WestCell);
            }
            catch(IndexOutOfRangeException) {}

            return adjacentCells;
        }

        
        
        private ICell SouthCell() => Stage.Cells![Position[0]+1, Position[1]];

        private ICell EastCell() => Stage.Cells![Position[0], Position[1]+1];

        private ICell NorthCell() => Stage.Cells![Position[0]-1, Position[1]];

        private ICell WestCell() => Stage.Cells![Position[0], Position[1]-1];

        public void Charge(int value)
        {
            if(Energy+value < 0)
            {
                Stage.GameOver();
            }
            Energy += value;
        }

        public void Punctuate(int value)
        {
            Score += value;
        }

        public void Print()
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor foregroundDefault = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ME");
            
            Console.BackgroundColor = backgroundDefault;
            Console.ForegroundColor = foregroundDefault;
        }
    }
}