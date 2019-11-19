
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.GameBoard
{
    class TestCellFishCount : GameBoardTest
    {
        [TestMethod]
        public void TestFishCount()
        {
            Assert.AreEqual(0, TestCells[0].FishCount);

            Assert.AreNotEqual(-1, TestCells[1].FishCount);
        }
    }
}
