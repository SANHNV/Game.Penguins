using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    public class PlacePenguin : Constructeur
    {
        [TestMethod]
        public void MoveAI()
        {
            TestGame.AddPlayer("Ai", Interfaces.Game.Players.PlayerType.AIEasy);
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();
            Core.Implements.Game.GameBoard.Plateau temp = TestGame.Board as Core.Implements.Game.GameBoard.Plateau;
            TestGame.CurrentPlayer = TestGame.Players.Last();
            Assert.AreEqual(0, temp.GetMyPenguins(TestGame.Players.Last().Identifier).Count);

            TestGame.PlacePenguin();
            Assert.AreEqual(1, temp.GetMyPenguins(TestGame.Players.Last().Identifier).Count);
        }
    }
}
