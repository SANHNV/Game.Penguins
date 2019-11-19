using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.Players
{
    [TestClass]
    public class TestPlayerIdentifier : PlayerTest
    {
        [TestMethod]
        public void PlayerIdentifier()
        {
            
            Assert.IsNotNull(TestPlayers[0].Identifier);
            Assert.AreNotEqual(TestPlayers[0].Identifier, TestPlayers[1].Identifier);
        }
    }
}
