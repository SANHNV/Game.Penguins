
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class PlacePenguinManual : Constructeur
    {
        [TestMethod]
        public void PlacePenguinsManual()
        {
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            Core.Implements.Game.GameBoard.Cell temp = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;

            for (int i = 0; i < 3; i++)
            {
                temp.CellType = (Interfaces.Game.GameBoard.CellType)i;
                temp.FishCount = i;
                TestGame.PlacePenguinManual(0, 0);
                if (i == 1)
                    Assert.AreEqual(Interfaces.Game.GameBoard.CellType.FishWithPenguin, temp.CellType);
                else { Assert.AreEqual((Interfaces.Game.GameBoard.CellType)i, temp.CellType); };
            }
        }
    }
}
