using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class Move : Constructeur
    {
        [TestMethod]
        public void MoveAI()
        {
            TestGame.AddPlayer("Ai",Interfaces.Game.Players.PlayerType.AIEasy);
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            TestGame.CurrentPlayer = TestGame.Players.Last();
            Core.Implements.Game.GameBoard.Cell temp = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            temp.FishCount = 1;
            TestGame.PlacePenguinManual(0,0);
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Move();

            Assert.AreNotEqual(temp.CellType, temp.FishCount);
        }
    }
}
