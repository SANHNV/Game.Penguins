using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class CheckBlockedPenguin : Constructeur
    {
        [TestMethod]
        public void BlockedPenguinTODO()
        {
            //TO DO
            //NOT THE BEST METHOD
            TestGame.CurrentPlayer = TestGame.Players.Last();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            TestGame.PlacePenguinManual(0, 0);

            TestGame.CheckBlockedPenguins();
        }
    }
}
