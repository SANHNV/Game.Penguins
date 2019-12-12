using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{
    [TestClass]
    public class Players : Constructeur
    {
        [TestMethod]
        public void PlayerList()
        {
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            Assert.AreEqual(0,AI.Players.Count);

            AI.Players = TestGame.Players;
            for (int i=0; i<AI.Players.Count;i++)
            {
                Assert.AreEqual(AI.Players[i].Identifier, TestGame.Players[i].Identifier);
            }
        }
    }
}
