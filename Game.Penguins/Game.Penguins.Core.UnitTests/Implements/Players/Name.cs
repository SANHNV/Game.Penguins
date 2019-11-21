using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.Players
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
