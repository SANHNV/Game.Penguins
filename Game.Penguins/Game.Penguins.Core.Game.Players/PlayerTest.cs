using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Game.Penguins.Core.Game.Players
{
    [TestClass]
    public class PlayerTest
    {
        public PlayerTest()
        {
            TestPlayers = new List<Player>();
            TestPlayers.Add(new Player((PlayerType)0, (PlayerColor)0, "test1", 1));
            TestPlayers.Add(new Player((PlayerType)1, (PlayerColor)2, "test2", 2));
            TestPlayers.Add(new Player((PlayerType)2, (PlayerColor)3, "test3", 3));
            TestPlayers.Add(new Player((PlayerType)3, (PlayerColor)4, "test4", 4));
        }

        public List<Player> TestPlayers { get; }
    }
}
