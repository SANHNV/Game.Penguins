using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class PenguinPlayer : GameBoardTest
    {
        [TestMethod]
        public void TestPinguin()
        {
            Assert.AreEqual(TestPlayer.Identifier, TestPenguin.Player.Identifier);
        }
    }
}
