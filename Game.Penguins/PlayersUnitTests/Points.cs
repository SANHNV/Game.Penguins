
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Points : Constructeur
    {
        [TestMethod]
        public void PlayerPoints()
        {
            Assert.AreEqual(0, TestPlayers[0].Points);

            Assert.AreNotEqual(-3, TestPlayers[1].Points);
        }
    }
}
