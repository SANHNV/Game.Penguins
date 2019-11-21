using Game.Penguins.Core.Implements.Game.GameBoard;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

//A modifier comme pour PlayerTest

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class GameBoardTest
    {
        public Player TestPlayer { get; }
        public Penguin TestPenguin { get; }
        public List<Cell> TestCells { get; }
        public Plateau TestBoard { get; }
        public GameBoardTest()
        {
            TestPlayer = new Player((PlayerType)0, (PlayerColor)0, "test", 2);
            TestPenguin = new Penguin(TestPlayer);
            TestCells.Add(new Cell((Interfaces.Game.GameBoard.CellType)0, 0,0,0));
            TestCells[0].CurrentPenguin = TestPenguin;
            TestCells.Add(new Cell((Interfaces.Game.GameBoard.CellType)1, 1, 0, 0));
            TestCells.Add(new Cell((Interfaces.Game.GameBoard.CellType)2, 2, 0, 0));
            TestCells.Add(new Cell((Interfaces.Game.GameBoard.CellType)3, 3, 0, 0));
            TestBoard = new Plateau();
        }
    }
}
