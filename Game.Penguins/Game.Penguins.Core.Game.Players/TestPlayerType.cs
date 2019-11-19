using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.Players
{
    [TestClass]
    public class TestPlayerType : PlayerTest
    {
        [TestMethod]
        public void PlayerType()
        {
            for (int i=0; i<4;i++)
            {
                Assert.AreEqual((PlayerType)i,TestPlayers[i].PlayerType);
            }
        }
    }
}
