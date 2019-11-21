using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PlayersUnitTests
{
    [TestClass]
    public class Constructeur
    {
        public Constructeur()
        {
            TestPlayers = new List<Player>();
            TestPlayers.Add(new Player((PlayerType)0, "test1"));
            TestPlayers[0].Color = (PlayerColor)0;
            TestPlayers.Add(new Player((PlayerType)1, "test2"));
            TestPlayers[1].Color = (PlayerColor)1;
            TestPlayers.Add(new Player((PlayerType)2, "test3"));
            TestPlayers[2].Color = (PlayerColor)2;
            TestPlayers.Add(new Player((PlayerType)3, "test4"));
            TestPlayers[3].Color = (PlayerColor)3;
        }
        public List<Player> TestPlayers { get; }
    }
}
