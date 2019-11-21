using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Cell
{
    [TestClass]
    public class CellPenguin : Constructeur
    {
        [TestMethod]
        public void TestCellPenguins()
        {
            Assert.AreEqual(TestPenguin.Player.Identifier, TestCells[0].CurrentPenguin.Player.Identifier);
        }
    }
}
