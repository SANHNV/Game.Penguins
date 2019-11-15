using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Penguins.Core.Interfaces.Game.Players;


namespace Game.Penguins.Core.Implements.Game.Players
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPlayer()
        {
            Player testPlayer = new Player((PlayerType)0, (PlayerColor)0, "test", 2);

            Assert.AreEqual(PlayerType.Human, testPlayer.PlayerType);
            Assert.AreEqual(PlayerColor.Blue, testPlayer.Color);
            Assert.AreEqual("test", testPlayer.Name);
            Assert.AreEqual(2, testPlayer.Penguins);
            Assert.IsNotNull(testPlayer.Identifier);
            Assert.AreEqual(0, testPlayer.Points);
        }
    }
}
