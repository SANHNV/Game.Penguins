using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.GameBoard
{
    public class TestCellType : GameBoardTest
    {
        [TestMethod]
        public void TestCellTypes()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((CellType)i, TestCells[i].CellType);
            }
        }
    }
}
