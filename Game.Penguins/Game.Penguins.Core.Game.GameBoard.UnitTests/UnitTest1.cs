using Game.Penguins.Core.Implements.Game.GameBoard;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPinguin()
        {
            Player testPlayer = new Player((PlayerType)0, (PlayerColor)0, "test", 2);
            Penguin testPenguin = new Penguin(testPlayer);

            Assert.AreEqual(testPlayer, testPenguin.Player);
        }
        [TestMethod]
        public void TestCell()
        {
            Player testPlayer = new Player((PlayerType)0, (PlayerColor)0, "test", 2);
            Penguin testPenguin = new Penguin(testPlayer);
            Cell testCell = new Cell((CellType)0, 0, testPenguin);

            Assert.AreEqual(0,testCell.FishCount);
            Assert.AreEqual(CellType.Empty, testCell.CellType);
            Assert.AreEqual(testPenguin, testCell.CurrentPenguin);
        }
    }
}
