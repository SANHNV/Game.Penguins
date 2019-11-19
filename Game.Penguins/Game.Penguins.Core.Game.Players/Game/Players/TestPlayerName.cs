using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.Players
{
    public class TestPlayerName : PlayerTest
    {
        [TestMethod]
        public void PlayerName()
        {
            Assert.AreEqual("test1", TestPlayers[0].Name);
        }
    }
}
