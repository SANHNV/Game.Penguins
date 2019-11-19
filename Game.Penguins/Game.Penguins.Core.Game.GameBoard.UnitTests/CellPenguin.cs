using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class CellPenguin : GameBoardTest
    {
        [TestMethod]
        public void TestCellPenguins()
        {
            Assert.AreEqual(TestPenguin, TestCells[0].CurrentPenguin);
        }
    }
}