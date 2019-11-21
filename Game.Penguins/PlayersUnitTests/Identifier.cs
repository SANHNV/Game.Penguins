using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Identifier : Constructeur
    {
        [TestMethod]
        public void TestIdentifier()
        {

            Assert.IsNotNull(TestPlayers[0].Identifier);
            Assert.AreNotEqual(TestPlayers[0].Identifier, TestPlayers[1].Identifier);
        }
    }
}
