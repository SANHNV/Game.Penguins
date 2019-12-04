using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class CheckBlockedPenguin : Constructeur
    {
        [TestMethod]
        public void BlockedPenguin()
        {
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            TestGame.PlacePenguinManual(0, 0);

            //No Penguin Blocked
            TestGame.CheckBlockedPenguins();
            Assert.AreEqual(CellType.FishWithPenguin, TestGame.Board.Board[0, 0].CellType);

            //Penguin Blocked
            Core.Implements.Game.GameBoard.Cell temp = TestGame.Board.Board[1, 0] as Core.Implements.Game.GameBoard.Cell;
            temp.CellType = CellType.Empty;
            temp = TestGame.Board.Board[0, 1] as Core.Implements.Game.GameBoard.Cell;
            temp.CellType = CellType.Empty;
            TestGame.CheckBlockedPenguins();
            Assert.AreNotEqual(CellType.FishWithPenguin, TestGame.Board.Board[0, 0].CellType);

        }
    }
}
