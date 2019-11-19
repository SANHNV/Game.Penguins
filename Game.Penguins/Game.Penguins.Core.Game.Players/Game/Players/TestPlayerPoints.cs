using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Game.Players
{
    public class TestPlayerPoints : PlayerTest
    {
        [TestMethod]
        public void PlayerPoints()
        {
            Assert.AreEqual(0, TestPlayers[0].Points);

            Assert.AreNotEqual(-3, TestPlayers[1].Points);
        }
    }
}
