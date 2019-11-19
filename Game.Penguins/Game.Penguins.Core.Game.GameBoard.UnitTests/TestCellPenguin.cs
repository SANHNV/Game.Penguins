﻿using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Penguins.Core.Game.GameBoard.UnitTests
{
    public class TestCellPenguin : GameBoardTest
    {
        [TestMethod]
        public void TestCellPenguins()
        {
            Assert.AreEqual(TestPenguin, TestCells[0].CurrentPenguin);
        }
    }
}
