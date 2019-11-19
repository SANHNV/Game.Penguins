using Game.Penguins.Core.Implements.Game.GameBoard;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

//A modifier comme pour PlayerTest

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class GameBoardTest
    {
        public GameBoardTest()
        {
            TestPlayer = new Player((PlayerType)0, (PlayerColor)0, "test", 2);
            TestPenguin = new Penguin(TestPlayer);
            TestCells.Add(new Cell((CellType)0, 0, TestPenguin));
            TestCells.Add(new Cell((CellType)1, 1, TestPenguin));
            TestCells.Add(new Cell((CellType)2, 2, TestPenguin));
            TestCells.Add(new Cell((CellType)3, 3, TestPenguin));
        }
        public Player TestPlayer { get; }
        public Penguin TestPenguin { get; }
        public List<Cell> TestCells { get; }
    }
}
