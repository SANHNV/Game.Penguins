using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class CellTypes : GameBoardTest
    {
        [TestMethod]
        public void TestCellTypes()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((Interfaces.Game.GameBoard.CellType)i, TestCells[i].CellType);
            }
        }
    }
}
