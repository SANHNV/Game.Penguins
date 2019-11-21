using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Type : Constructeur
    {
        [TestMethod]
        public void PlayerType()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((PlayerType)i, TestPlayers[i].PlayerType);
            }
        }
    }
}
