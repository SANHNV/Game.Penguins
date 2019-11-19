using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Game.Penguins.Core.Game.Players
{
    [TestClass]
    public class TestPlayerPenguins : PlayerTest
    {
        [TestMethod]
        public void PlayerPinguins()
        {
            Assert.AreEqual(0, TestPlayers[0].Penguins);

            Assert.AreNotEqual(-3, TestPlayers[1].Penguins);
        }
    }
}
