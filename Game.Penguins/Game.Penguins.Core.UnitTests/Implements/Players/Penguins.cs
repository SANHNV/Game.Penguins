using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.Players
{
    [TestClass]
    public class Penguins : Constructeur
    {
        [TestMethod]
        public void PlayerPinguins()
        {
            Assert.AreEqual(0, TestPlayers[0].Penguins);

            Assert.AreNotEqual(-3, TestPlayers[1].Penguins);
        }
    }
}
