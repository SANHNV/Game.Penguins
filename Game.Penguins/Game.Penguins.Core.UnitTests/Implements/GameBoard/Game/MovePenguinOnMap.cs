using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class MovePenguinOnMap : Constructeur
    {
        [TestMethod]
        public void MovePenguin()
        {
            //Init
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            Core.Implements.Game.GameBoard.Cell origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            Player tempPlayer = TestGame.CurrentPlayer as Player;
            origin.CurrentPenguin = new Core.Implements.Game.GameBoard.Penguin(tempPlayer);
            origin.CellType = CellType.FishWithPenguin;
            ICell destination = TestGame.Board.Board[0, 1];

            //TEST
            TestGame.MovePenguinOnMap(origin, destination);

            Assert.IsNotNull(destination.CurrentPenguin);
            Assert.IsNull(origin.CurrentPenguin);
            Assert.AreEqual(origin.CellType, CellType.Water);
            Assert.AreEqual(destination.CellType, CellType.FishWithPenguin);
            Assert.AreNotEqual(origin.FishCount, TestGame.CurrentPlayer.Points);
        }
    }
}
