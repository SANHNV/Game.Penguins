using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Plateau
{
    [TestClass]
    public class GetMyPinguins : Constructeur
    {
        [TestMethod]
        public void PlateauGyMyPenguins()
        {
            Assert.AreEqual(0,TestBoard.GetMyPenguins(TestPlayers[1].Identifier).Count);
        }
    }
}
