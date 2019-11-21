using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Penguin
{
    [TestClass]
    public class Player : Constructeur
    {
        [TestMethod]
        public void PinguinPlayer()
        {
            Assert.AreEqual(TestPlayers[0].Identifier, TestPenguin.Player.Identifier);

            Assert.AreNotEqual(TestPlayers[1].Identifier, TestPenguin.Player.Identifier);
        }
    }
}
