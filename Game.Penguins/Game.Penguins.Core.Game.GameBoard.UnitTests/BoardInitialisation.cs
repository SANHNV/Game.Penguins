using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    [TestClass]
    public class BoardInitialisation : GameBoardTest
    {
        [TestMethod]
        public void TestCellTypes()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j=0; j<8;j++)
                {
                    Assert.AreEqual(TestBoard.Board[i,j].CellType, CellType.Fish);
                    Assert.AreNotEqual(-1,TestBoard.Board[i, j].FishCount);
                }
            }
        }
    }
}