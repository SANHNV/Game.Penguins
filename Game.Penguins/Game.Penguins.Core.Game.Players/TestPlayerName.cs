using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.Players
{
    [TestClass]
    public class TestPlayerName : PlayerTest
    {
        [TestMethod]
        public void PlayerName()
        {
            Assert.AreEqual("test1", TestPlayers[0].Name);
        }
    }
}
