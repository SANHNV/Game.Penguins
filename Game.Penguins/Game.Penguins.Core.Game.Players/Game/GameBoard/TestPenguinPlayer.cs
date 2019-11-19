using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.GameBoard
{
    [TestClass]
    public class TestPenguinPlayer : GameBoardTest
    {
        [TestMethod]
        public void TestPinguin()
        {
            Assert.AreEqual(TestPlayer, TestPenguin.Player);
        }
    }
}
