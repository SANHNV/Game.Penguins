using System;
using System.Collections.Generic;
using System.Linq;
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
        public Game() {}
        public IBoard Board { get; set; }
        public NextActionType NextAction { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        public IList<IPlayer> Players { get; set; }

        public event EventHandler StateChanged;
        private int currentPlayerIndex = 0;
        private int penguinsByPlayer = 0;

        /// <summary>
        /// Create a Player
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerType"></param>
        /// <returns>Player</returns>
        public IPlayer AddPlayer(string playerName, PlayerType playerType)
        {
            Players.Add(new Player(playerType, playerName));
            return Players.Last();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            //TO DO MAYBE
        }

        /// <summary>
        /// Vérifie et déplace le pinguin si c'est bon
        /// Sinon rien ne se passe et elle recommance
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public void MoveManual(ICell origin, ICell destination)
        {
            //Fonction Pinguin du Joueur bien au Joueur
            //Fonction return List<Cell> déplacement possible
            // Récupération destination do while
            //for ()
            // if Cell destination == List<Cell>[i]
            //      fonction vraiment faire le déplacement
            MovePenguinOnMap(origin, destination);
            //      break;
            //

            // Check blocked penguins : aka ménage
            CheckBlockedPenguins();

            CheckActions();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckActions()
        {
            CheckNextPlayer();

            CheckNextAction();

            /*if (StateChanged != null)
                StateChanged.Invoke(this, null);*/
        }

        /// <summary>
        /// Ajout nombre de pinguins et la couleur des joueurs
        /// </summary>
        private void InitPlayers()
        {
            penguinsByPlayer = Players.Count == 2 ? 4 : (Players.Count == 3 ? 3 : 2);
            foreach (var player in Players)
            {
                player.Penguins = 0;
                player.Color = (PlayerColor)Players.IndexOf(player);
            }
        }

        /// <summary>
        /// Augmente l'index du currentPlayer
        /// </summary>
        private void CheckNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1 > Players.Count) ? 0 : currentPlayerIndex+1 ;
            CurrentPlayer = Players[currentPlayerIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckNextAction()
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
                // No more penguins, we can stop the game :
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
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        private void MovePenguinOnMap(ICell origin, ICell destination)
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

            //origin nullify
            originCell.CellType = CellType.Water;
            originCell.FishCount = 0;
            originCell.CurrentPenguin = null;

            //
            CheckBlockedPenguins();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckBlockedPenguins()
        {
            foreach (var player in Players)
            {
                var board = Board as Plateau;
                var currentPlayer = CurrentPlayer as Player;
                var penguinCells = board.GetMyPenguins(player.Identifier);
                foreach (var penguinCell in penguinCells)
                {
                    // We check if the destination cell is specific (no available cell in a next round) :
                    if (board.GetAvailableCellsAround(penguinCell).Count == 0)
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
        /// 
        /// </summary>
        public void PlacePenguin()
        {
            /*if (CurrentPlayer.PlayerType != PlayerType.Human)
                CurrentPlayer.IA.PlacePenguin();*/
        }

        public void PlacePenguinManual(int x, int y)
        {
            if (Board.Board[x, y].CellType != CellType.Fish)
                return;

            Board.Board[x, y].CellType = CellType.FishWithPenguin;
            Board.Board[x, y].CurrentPenguin = new Penguin(CurrentPlayer);

            CurrentPlayer.Penguins++;

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
