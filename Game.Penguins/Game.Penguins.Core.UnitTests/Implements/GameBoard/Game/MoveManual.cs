using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class MoveManual : Constructeur
    {
        [TestMethod]
        public void HumanMove()
        {
            //Init
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            TestGame.CurrentPlayer= TestGame.Players.Last();
            Core.Implements.Game.GameBoard.Cell origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            Core.Implements.Game.GameBoard.Cell destination = TestGame.Board.Board[0, 1] as Core.Implements.Game.GameBoard.Cell;
            Player tempPlayer = TestGame.CurrentPlayer as Player;
            origin.CurrentPenguin = new Core.Implements.Game.GameBoard.Penguin(tempPlayer);
            origin.CellType = CellType.FishWithPenguin;
            ICell destinationP = TestGame.Board.Board[0, 1];

            TestGame.MoveManual(origin, destination);

            #region test if checkmove
            //Init and block cells 2.0 1.1 1.2
            int i = 0;
            int[] j = { 2, 0, 1, 1, 1, 2 };
            do
            {
                Core.Implements.Game.GameBoard.Cell tempCell = TestGame.Board.Board[j[i * 2], j[i * 2 + 1]] as Core.Implements.Game.GameBoard.Cell;
                tempCell.CellType = CellType.FishWithPenguin;
                i++;
            } while (i < 3);

            //TEST
            Assert.IsFalse(TestGame.CheckMove(origin, destination));
            #endregion

            #region testMovePenguinOM
            //TEST MovePenguinOnMap
            Assert.IsNotNull(destinationP.CurrentPenguin);
            Assert.IsNull(origin.CurrentPenguin);
            Assert.AreEqual(origin.CellType, CellType.Water);
            Assert.AreEqual(destinationP.CellType, CellType.FishWithPenguin);
            Assert.AreNotEqual(origin.FishCount, TestGame.CurrentPlayer.Points);
            #endregion

            #region textCheckAction
            //Assert.AreNotEqual(testCurrentPlayer, TestGame.CurrentPlayer);
            Assert.AreEqual(NextActionType.MovePenguin, TestGame.NextAction);
            #endregion
        }
    }
}
