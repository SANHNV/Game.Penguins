using System;
using System.Collections.Generic;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Game : IGame
    {
        /// <summary>
        /// Constructor of GAME
        /// Init Board, Players, NextAction and CurrentPlayer
        /// </summary>
        public Game()
        {
            Board = new Plateau();
            Players = null; //TO CHANGE
            NextAction = NextActionType.PlacePenguin;
            CurrentPlayer = Players[0];

        }
        public IBoard Board { get; set; }
        public NextActionType NextAction { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IList<IPlayer> Players { get; set; }

        public event EventHandler StateChanged;
        /// <summary>
        /// Create a Player
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerType"></param>
        /// <returns>Player</returns>
        public IPlayer AddPlayer(string playerName, PlayerType playerType)
        {
            return new Player(playerType, playerName);
        }

        public void Move()
        {
            //TO DO
        }

        public void MoveManual(ICell origin, ICell destination)
        {
            //TO DO
        }

        public void PlacePenguin()
        {
            //TO DO
        }

        public void PlacePenguinManual(int x, int y)
        {
            //TO DO
        }
        /// <summary>
        /// StartGame TO DO
        /// </summary>
        public void StartGame()
        {
            //TO DO
        }
    }
}
