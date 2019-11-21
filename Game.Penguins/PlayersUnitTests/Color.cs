using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Color : Constructeur
    {
        [TestMethod]
        public void PlayerColor()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((PlayerColor)i, TestPlayers[i].Color);
            }
        }
    }
}
