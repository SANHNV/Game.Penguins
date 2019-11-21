using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Cell
{
    [TestClass]
    public class V : Constructeur
    {
        [TestMethod]
        public void TestCellV()
        {
            Assert.AreEqual(0, TestCells[0].V);

            Assert.AreNotEqual(-1, TestCells[0].V);
        }
    }
}
