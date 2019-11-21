using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Cell
{
    [TestClass]
    class CellFishCount : Constructeur
    {
        [TestMethod]
        public void TestFishCount()
        {
            Assert.AreEqual(0, TestCells[0].FishCount);

            Assert.AreNotEqual(-1, TestCells[1].FishCount);
        }
    }
}
