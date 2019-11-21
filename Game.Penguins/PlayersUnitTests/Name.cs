using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Name : Constructeur
    {
        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("test1", TestPlayers[0].Name);
        }
    }
}
