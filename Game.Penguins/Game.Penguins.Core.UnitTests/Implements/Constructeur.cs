using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.Players;
using Game.Penguins.Core.Implements.Game.GameBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Game.Penguins.Core.Interfaces.Game.GameBoard;

namespace Game.Penguins.Core.UnitTests
{
    [TestClass]
    public class Constructeur
    {
        public Constructeur()
        {
            //Players List init
            TestPlayers = new List<Player>();
            TestPlayers.Add(new Player((PlayerType)0, "test1"));
            TestPlayers[0].Color = (PlayerColor)0;
            TestPlayers.Add(new Player((PlayerType)1, "test2"));
            TestPlayers[1].Color = (PlayerColor)1;
            TestPlayers.Add(new Player((PlayerType)2, "test3"));
            TestPlayers[2].Color = (PlayerColor)2;
            TestPlayers.Add(new Player((PlayerType)3, "test4"));
            TestPlayers[3].Color = (PlayerColor)3;

            //Penguin Init
            TestPenguin = new Penguin(TestPlayers[0]);

            //Cell Init
            TestCells = new List<Cell>();
            TestCells.Add(new Cell((CellType)0, 0, 0, 0));
            TestCells[0].CurrentPenguin = TestPenguin;
            TestCells.Add(new Cell((CellType)1, 1, 0, 0));
            TestCells.Add(new Cell((CellType)2, 2, 0, 0));
            TestCells.Add(new Cell((CellType)3, 3, 0, 0));

            //Board Init
            TestBoard = new Plateau();

            //Game Init
            TestGame = new Core.Implements.Game.GameBoard.Game();
            TestGame.AddPlayer("player1", PlayerType.Human);
            TestGame.AddPlayer("player2", PlayerType.Human);
        }

        public List<Player> TestPlayers { get; }
        public Penguin TestPenguin { get; }
        public List<Cell> TestCells { get; set; }
        public Plateau TestBoard { get; }

        public Core.Implements.Game.GameBoard.Game TestGame { get; }

    }
}
