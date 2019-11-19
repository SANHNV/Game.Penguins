using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Game.Penguins.Core.UnitTests.Game.Players
{
    public class TestPlayerColor : PlayerTest
    {
        [TestMethod]
        public void PlayerColor()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((PlayerType)i, TestPlayers[i].Color);
            }
        }
    }
}
