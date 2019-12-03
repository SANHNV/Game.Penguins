using Game.Penguins.Core.Implements.Game.Actions;
using Game.Penguins.Core.Implements.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.UnitTests.Implements.GameBoard.Plateau
{
    [TestClass]
    public class GetAvailableCell : Constructeur
    {
        [TestMethod]
        public void PlateauGetAvailableCell()
        {
            int j = 0;
            int[] result = { 1,0,1,2,0,1,0,2,2,1,2,2};
            Core.Implements.Game.GameBoard.Cell origin = TestBoard.Board[1, 1] as Core.Implements.Game.GameBoard.Cell;
            for (int i =0;i<6;i++)
            {

                Assert.AreEqual(result[j],TestBoard.GetAvailableCell(origin, (Direction)i).H);
                j++;
                Assert.AreEqual(result[j], TestBoard.GetAvailableCell(origin, (Direction)i).V);
                j++;
            }
        }

    }
}
