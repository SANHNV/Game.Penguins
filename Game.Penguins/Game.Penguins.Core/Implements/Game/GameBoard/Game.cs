﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Penguins.Core.Implements.Game.Actions;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Game : IGame
    {
        /// <summary>
        /// Constructor of GAME
        /// </summary>
        public Game() { Players = new List<IPlayer>(); }

        private Plateau plateau {
            get
            {
                return Board as Plateau;
            }
        }
        public IBoard Board { get; set; }

        private NextActionType nextActionType { get; set; }
        public NextActionType NextAction
        {
            get
            {
                return nextActionType;
            }

            set
            {
                nextActionType = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);
            }
        }

        private IPlayer currentPlayer { get; set; }
        public IPlayer CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);
            }
        }

        private IList<IPlayer> players { get; set; }
        public IList<IPlayer> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);
            }
        }

        public event EventHandler StateChanged;
        private int currentPlayerIndex = 0;
        public int penguinsByPlayer = 0; //private hors test

        /// <summary>
        /// Create and Add a Player
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerType"></param>
        /// <returns>Player</returns>
        public IPlayer AddPlayer(string playerName, PlayerType playerType)
        {
            IPlayer temp = new Player(playerType, playerName);
            Players.Add(temp);
            return Players.Last();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            //TO DO MAYBE AI
        }

        /// <summary>
        /// Get a list of possible moves and return true if destination is one of them
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns>bool</returns>
        public bool CheckMove(Cell origin, Cell destination)
        {
            bool possible = false;
            List<Cell> possibleMove = new List<Cell>();
            Cell newOrigin = origin;
            Cell temp = null;

            //Get all possible moves from origin, one direction at a time, cell by cell
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    temp = plateau.GetAvailableCell(newOrigin, (Direction)i);
                    if (temp != null && temp.CellType == CellType.Fish)
                    {
                        possibleMove.Add(temp); //Merci Simon !
                        newOrigin = temp;
                    }
                    else { temp = null; }
                }
                while (temp != null);
                newOrigin = origin;
            }

            //Check if destination is a possibleMove
            for (int i=0;i<possibleMove.Count;i++)
            {
                if (possibleMove[i].V==destination.V && possibleMove[i].H == destination.H)
                {
                    possible = true;
                    break;
                }
            }

            return possible;
        }

        /// <summary>
        /// Vérifie et déplace le pinguin si c'est bon
        /// Sinon rien ne se passe et elle recommance
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public void MoveManual(ICell origin, ICell destination)
        {
            if (CheckMove(origin as Cell, destination as Cell))
            {
                //Make the move
                MovePenguinOnMap(origin, destination);
                // Check blocked penguins : aka clean up
                CheckBlockedPenguins();
                CheckActions();
            }
        }

        /// <summary>
        /// 
        /// private hors test
        /// </summary>
        public void CheckActions()
        {
            CheckNextPlayer();

            CheckNextAction();

            if (StateChanged != null)
                StateChanged.Invoke(this, null);
        }

        /// <summary>
        /// Ajout nombre de pinguins et la couleur des joueurs
        /// private hors test
        /// </summary>
        public void InitPlayers()
        {
            penguinsByPlayer = Players.Count == 2 ? 4 : (Players.Count == 3 ? 3 : 2);
            foreach (var player in Players)
            {
                var p = player as Player;
                p.Penguins = 0;
                p.Color = (PlayerColor)Players.IndexOf(player);
            }
        }

        /// <summary>
        /// Increase index of currentPlayer
        /// private hors test
        /// </summary>
        public void CheckNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex +1 >= Players.Count) ? 0 : currentPlayerIndex+1 ;
            CurrentPlayer = Players[currentPlayerIndex];
        }

        /// <summary>
        /// Modify NextAction Type : Place Penguins, EndGame or Move Penguin
        /// private hors test
        /// </summary>
        public void CheckNextAction()
        {
            var board = Board as Plateau;
            // Need to place more penguins ?
            if (Players.Any(e => e.Penguins < penguinsByPlayer))
            {
                NextAction = NextActionType.PlacePenguin;
                return;
            }

            if (!Players.Any(e => board.GetMyPenguins(e.Identifier).Count > 0))
            {
                // No more penguins, we can stop the game
                NextAction = NextActionType.Nothing;
            }
            else
            {
                NextAction = NextActionType.MovePenguin;
                // We check the current player available actions :
                var penguinCells = board.GetMyPenguins(CurrentPlayer.Identifier);
                if (penguinCells.Count == 0)
                    CheckActions();
            }
        }

        /// <summary>
        /// Place Penguin on destination, take points and nullify origin
        /// private hors test
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public void MovePenguinOnMap(ICell origin, ICell destination)
        {
            var originCell = origin as Cell;
            var destinationCell = destination as Cell;
            var currentPlayer = CurrentPlayer as Player; 

            //Place Penguin on destination
            destinationCell.CurrentPenguin = originCell.CurrentPenguin;
            //destination change CellType 
            destinationCell.CellType = CellType.FishWithPenguin;

            //Add Points
            currentPlayer.Points += originCell.FishCount;

            //origin nullified
            originCell.CellType = CellType.Water;
            originCell.FishCount = 0;
            originCell.CurrentPenguin = null;

            CheckBlockedPenguins();
        }

        /// <summary>
        /// Check if any Penguin are blocked and act
        /// private hors test
        /// </summary>
        public void CheckBlockedPenguins()
        {
            foreach (var player in Players)
            {
                var board = Board as Plateau;
                var currentPlayer = CurrentPlayer as Player;
                var penguinCells = board.GetMyPenguins(player.Identifier);
                foreach (var penguinCell in penguinCells)
                {
                    // We check if the destination cell is specific (no available cell in a next round) :
                    if (board.GetListCellsAvailableAround(penguinCell).Count == 0)
                    { 
                        currentPlayer.Points += penguinCell.FishCount;
                        penguinCell.CellType = CellType.Water;
                        penguinCell.FishCount = 0;
                        penguinCell.CurrentPenguin = null;
                    }
                }
            }
        }

        /// <summary>
        /// TO DO AI
        /// </summary>
        public void PlacePenguin()
        {
            /*if (CurrentPlayer.PlayerType != PlayerType.Human)
                CurrentPlayer.IA.PlacePenguin();*/
        }

        /// <summary>
        /// Place Penguin on Cell with 1 fish
        /// </summary>
        /// <param name="h"></param>
        /// <param name="v"></param>
        public void PlacePenguinManual(int h, int v)
        {
            var currentPlayer = CurrentPlayer as Player;
            var cell = Board.Board[h, v] as Cell;

            if (cell.FishCount ==1 && cell.CellType!=CellType.FishWithPenguin)
            {
                cell.CellType = CellType.FishWithPenguin;
                cell.CurrentPenguin = new Penguin(currentPlayer);
            }
            else { return; }

            currentPlayer.Penguins++;

            CheckActions();
        }

        /// <summary>
        /// StartGame TO DO
        /// </summary>
        public void StartGame()
        {
            InitPlayers();

            Board = new Plateau();

            CheckActions();
        }
    }
}
