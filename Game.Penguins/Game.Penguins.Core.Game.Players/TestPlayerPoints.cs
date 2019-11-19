using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.Players
{
    [TestClass]
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
