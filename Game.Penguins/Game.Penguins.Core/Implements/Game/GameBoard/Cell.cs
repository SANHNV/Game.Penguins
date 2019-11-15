﻿using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Cell : ICell
    {
        public Cell(CellType cellType, int fishCount, IPenguin currentPenguin)
        {
            CellType = cellType;
            FishCount = fishCount;
            CurrentPenguin = currentPenguin;
        }

        public CellType CellType { get; set; }

        public int FishCount { get; }

        public IPenguin CurrentPenguin { get; set; }

        public event EventHandler StateChanged;
    }
}