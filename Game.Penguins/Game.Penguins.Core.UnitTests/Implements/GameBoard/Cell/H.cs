using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Cell
{   
    [TestClass]
    public class H : Constructeur
    {
        [TestMethod]
        public void TestCellH()
        {
            Assert.AreEqual(0, TestCells[0].H);

            Assert.AreNotEqual(-1, TestCells[0].H);
        }
    }
}
