using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{
    [TestClass]
    public class GetCellsWithMyFish : Constructeur
    {
        [TestMethod]
        public void CellsWithFish()
        {
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            Core.Implements.Game.GameBoard.Cell origin = TestGame.Board.Board[0, 0] as Core.Implements.Game.GameBoard.Cell;
            for (int i = 1; i < 4; i++)
            {
                foreach (var el in AI.GetCellsWithMyFish(origin, i, TestGame.Board as Core.Implements.Game.GameBoard.Plateau))
                {
                    Assert.AreEqual(i, el.FishCount);
                }
            }
        }
    }
}
