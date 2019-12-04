using Game.Penguins.Core.Implements.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class CheckMove : Constructeur
    {
        [TestMethod]
        public void BlockedPenguin()
        {
            //Init and block cells 2.0 1.1 1.2
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            int i = 0;
            int[] j = { 2, 0, 1, 1, 1, 2 };
            do
            {
                Core.Implements.Game.GameBoard.Cell temp = TestGame.Board.Board[j[i*2],j[i*2+1]] as Core.Implements.Game.GameBoard.Cell;
                temp.CellType = Interfaces.Game.GameBoard.CellType.FishWithPenguin;
                i++;
            } while (i < 3);

            Core.Implements.Game.GameBoard.Cell origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            Core.Implements.Game.GameBoard.Cell destination = TestGame.Board.Board[0, 1] as Core.Implements.Game.GameBoard.Cell;

            //TEST
            Assert.IsTrue(TestGame.CheckMove(origin, destination));
            destination = TestGame.Board.Board[1, 1] as Core.Implements.Game.GameBoard.Cell;
            Assert.IsFalse(TestGame.CheckMove(origin, destination));
        }
    }
}
