using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{
    [TestClass]
    public class PlacePenguin : Constructeur
    {
        [TestMethod]
        public void PlacePenguins()
        {
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();

            Core.Implements.Game.GameBoard.Cell retour = AI.PlacePenguin(TestGame.Board as Core.Implements.Game.GameBoard.Plateau);
            Assert.AreEqual(retour.FishCount, (int)retour.CellType);
        }
    }
}
