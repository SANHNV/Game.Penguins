using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Cell : ICell
    {
        public Cell(CellType newCellType, int fishCount, int v, int h)
        {
            CellType = newCellType;
            FishCount = fishCount;
            CurrentPenguin = null;
            V = v;
            H = h;
        }

        private CellType cellType { get; set; }
        public CellType CellType
        {
            get
            {
                return cellType;
            }

            set
            {
                cellType = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        private int fishCount { get; set; }
        public int FishCount
        {
            get
            {
                return fishCount;
            }

            set
            {
                fishCount = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        private IPenguin currentPenguin { get; set; }
        public IPenguin CurrentPenguin
        {
            get
            {
                return currentPenguin;
            }

            set
            {
                currentPenguin = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        public int H { get; }
        public int V { get; }

        public event EventHandler StateChanged;
    }
}
