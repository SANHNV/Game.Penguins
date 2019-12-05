using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class CheckActions : Constructeur
    {
        [TestMethod]
        public void CheckPlayerAction()
        {
            #region test CheckNextPlayer
            IPlayer testCurrentPlayer = TestGame.CurrentPlayer;
            TestGame.CheckNextPlayer();
            Assert.AreNotEqual(testCurrentPlayer, TestGame.CurrentPlayer);
            #endregion

            #region test CheckNextAction
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
        }
    }
}
