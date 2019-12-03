using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class AddPlayer : Constructeur
    {
        [TestMethod]
        public void GameAddPlayer()
        {
            IPlayer test = TestGame.AddPlayer("test", PlayerType.Human);
            Assert.AreEqual(TestGame.Players.Last().Identifier, test.Identifier);
        }
    }
}
