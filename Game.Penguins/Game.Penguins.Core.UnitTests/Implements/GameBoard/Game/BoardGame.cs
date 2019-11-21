using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Game
{
    [TestClass]
    class BoardGame : Constructeur
    {
        [TestMethod]
        public void TestBoardInit()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(TestBoard.Board[i, j].CellType, CellType.Fish);
                    Assert.AreNotEqual(-1, TestBoard.Board[i, j].FishCount);
                }
            }
        }
    }
}
