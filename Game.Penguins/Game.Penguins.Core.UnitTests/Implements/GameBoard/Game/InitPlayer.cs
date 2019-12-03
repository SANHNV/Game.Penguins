using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class InitPlayer : Constructeur
    {
        [TestMethod]
        public void InitPlayers()
        {
            int max = 2;
            do
            {
                TestGame.InitPlayers();
                for (int i = 0; i < max; i++)
                {
                    Assert.AreEqual((PlayerColor)i, TestGame.Players[i].Color);
                    Assert.AreEqual(0, TestGame.Players[i].Penguins);
                }
                max++;
                TestGame.AddPlayer("player"+max, PlayerType.Human);
            } while (max<5);

        }
    }
}
