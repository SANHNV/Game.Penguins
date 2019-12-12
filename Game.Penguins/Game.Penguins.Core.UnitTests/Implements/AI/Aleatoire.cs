using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{
    [TestClass]
    public class Aleatoire : Constructeur
    {
        [TestMethod]
        public void PlacePenguins()
        {
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            Assert.IsNotNull(AI.aleatoire);
        }
    }
}
