using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Game.Penguins.Core.UnitTests.Implements.AI
{   
    [TestClass]
    public class Move : Constructeur
    {
        [TestMethod]
        public void MoveAI()
        {
            Core.Implements.Game.AI.AI AI = new Core.Implements.Game.AI.AI();
            TestGame.Board = new Core.Implements.Game.GameBoard.Plateau();

            for (int i = 3; i > 0; i--)
            {
                TestGame.AddPlayer("AI", (Interfaces.Game.Players.PlayerType)i);
                TestGame.CurrentPlayer = TestGame.Players.Last();
                TestGame.PlacePenguin();
                List<Core.Implements.Game.GameBoard.Cell> move = AI.Move(TestGame.Board as Core.Implements.Game.GameBoard.Plateau, TestGame.CurrentPlayer as Core.Implements.Game.Players.Player);

                //Not the same cell coor
                Assert.IsFalse(move[0].H == move[1].H && move[0].V == move[1].V);

                Assert.AreEqual(Interfaces.Game.GameBoard.CellType.Fish, move[1].CellType);
            }
        }
    }
}
