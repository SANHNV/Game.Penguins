
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Cell
{
    [TestClass]
    public class CellTypes : Constructeur
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
