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
            #region test if checkmove
            //Init and block cells 2.0 1.1 1.2
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            int i = 0;
            int[] j = { 2, 0, 1, 1, 1, 2 };
            do
            {
                Core.Implements.Game.GameBoard.Cell tempCell = TestGame.Board.Board[j[i * 2], j[i * 2 + 1]] as Core.Implements.Game.GameBoard.Cell;
                tempCell.CellType = CellType.FishWithPenguin;
                i++;
            } while (i < 3);

            Core.Implements.Game.GameBoard.Cell origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            Core.Implements.Game.GameBoard.Cell destination = TestGame.Board.Board[0, 1] as Core.Implements.Game.GameBoard.Cell;

            //TEST
            Assert.IsTrue(TestGame.CheckMove(origin, destination));
            #endregion

            #region testMovePenguinOM
            //Init
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            Player tempPlayer = TestGame.CurrentPlayer as Player;
            origin.CurrentPenguin = new Core.Implements.Game.GameBoard.Penguin(tempPlayer);
            origin.CellType = CellType.FishWithPenguin;
            ICell destinationP = TestGame.Board.Board[0, 1];

            //TEST
            TestGame.MovePenguinOnMap(origin, destinationP);

            Assert.IsNotNull(destinationP.CurrentPenguin);
            Assert.IsNull(origin.CurrentPenguin);
            Assert.AreEqual(origin.CellType, CellType.Water);
            Assert.AreEqual(destinationP.CellType, CellType.FishWithPenguin);
            Assert.AreNotEqual(origin.FishCount, TestGame.CurrentPlayer.Points);
            #endregion

            #region testBlockedPenguins
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            TestGame.PlacePenguinManual(0, 0);

            //Penguin Blocked
            Core.Implements.Game.GameBoard.Cell temp = TestGame.Board.Board[1, 0] as Core.Implements.Game.GameBoard.Cell;
            temp.CellType = CellType.Empty;
            temp = TestGame.Board.Board[0, 1] as Core.Implements.Game.GameBoard.Cell;
            temp.CellType = CellType.Empty;
            TestGame.CheckBlockedPenguins();
            Assert.AreNotEqual(CellType.FishWithPenguin, TestGame.Board.Board[0, 0].CellType);
            #endregion

            #region textCheckAction
            IPlayer testCurrentPlayer = TestGame.CurrentPlayer;
            TestGame.CheckNextPlayer();
            Assert.AreNotEqual(testCurrentPlayer, TestGame.CurrentPlayer);

            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();

            //First if place a Penguin if there are none
            TestGame.penguinsByPlayer = 4;
            TestGame.CheckNextAction();
            Assert.AreEqual(Interfaces.Game.GameBoard.NextActionType.PlacePenguin, TestGame.NextAction);

            //Second if, end the game
            Player tempPlayer1 = TestGame.Players[0] as Player;
            tempPlayer1.Penguins = 4;
            Player tempPlayer2 = TestGame.Players[1] as Player;
            tempPlayer2.Penguins = 4;
            TestGame.CheckNextAction();
            Assert.AreEqual(Interfaces.Game.GameBoard.NextActionType.Nothing, TestGame.NextAction);

            //Else move a penguins if all penguins are placed on the board
            TestGame.CurrentPlayer = tempPlayer1;
            Core.Implements.Game.GameBoard.Cell testCell = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            testCell.CellType = Interfaces.Game.GameBoard.CellType.FishWithPenguin;
            Core.Implements.Game.GameBoard.Penguin testP = new Core.Implements.Game.GameBoard.Penguin(tempPlayer1);
            testCell.CurrentPenguin = testP;
            TestGame.CheckNextAction();
            Assert.AreEqual(Interfaces.Game.GameBoard.NextActionType.MovePenguin, TestGame.NextAction);
            #endregion

            #region test if false MoveManual
            //If == false 
            destination = TestGame.Board.Board[1, 1] as Core.Implements.Game.GameBoard.Cell;
            Assert.IsFalse(TestGame.CheckMove(origin, destination));
            #endregion
        }
    }
}
