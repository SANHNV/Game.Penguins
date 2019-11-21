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
        public CellType CellType { get; set; }
        public int FishCount { get; set; }

        public IPenguin CurrentPenguin { get; set; }

        public int H { get; }
        public int V { get; }

        public event EventHandler StateChanged;
    }
}
