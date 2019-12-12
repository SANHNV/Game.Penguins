using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{
    [TestClass]
    public class CurrentPlayer : Constructeur
    {
        [TestMethod]
        public void Player()
        {
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            Assert.IsNull(AI.CurrentPlayer);

            AI.CurrentPlayer = TestGame.Players[0] as Core.Implements.Game.Players.Player;
            Assert.AreEqual(AI.CurrentPlayer.Identifier, TestGame.Players[0].Identifier);
        }
    }
}
