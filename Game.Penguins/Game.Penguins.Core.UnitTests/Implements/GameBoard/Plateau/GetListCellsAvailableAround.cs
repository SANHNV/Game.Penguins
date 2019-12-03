
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Plateau
{
    [TestClass]
    public class GetListCellsAvailableAround : Constructeur
    {
        [TestMethod]
        public void PlateauGetListAvailable()
        {
            List<ICell> result = new List<ICell>{ TestBoard.Board[0, 1], TestBoard.Board[2,1], TestBoard.Board[1,0], TestBoard.Board[2,0], TestBoard.Board[1, 2], TestBoard.Board[2,2]};
            Core.Implements.Game.GameBoard.Cell temp = null;

            List<Core.Implements.Game.GameBoard.Cell> listFunction = TestBoard.GetListCellsAvailableAround(TestBoard.Board[1, 1] as Core.Implements.Game.GameBoard.Cell);

            Assert.AreEqual(6, listFunction.Count);

            for(int i=0;i<listFunction.Count; i++)
            {
                temp = result[i] as Core.Implements.Game.GameBoard.Cell;
                Assert.AreEqual(temp.H, listFunction[i].H);
                Assert.AreEqual(temp.V, listFunction[i].V);
            }
        }
    }
}
