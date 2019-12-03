using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class CheckNextPlayer : Constructeur
    {
        [TestMethod]
        public void NextPlayer()
        {
            IPlayer testCurrentPlayer = TestGame.CurrentPlayer;
            TestGame.CheckNextPlayer();
            Assert.AreNotEqual(testCurrentPlayer, TestGame.CurrentPlayer);
        }
    }
}
