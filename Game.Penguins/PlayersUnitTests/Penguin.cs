﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayersUnitTests
{
    [TestClass]
    public class Penguin : Constructeur
    {
        [TestMethod]
        public void PlayerPinguins()
        {
            Assert.AreEqual(0, TestPlayers[0].Penguins);

            Assert.AreNotEqual(-3, TestPlayers[1].Penguins);
        }
    }
}