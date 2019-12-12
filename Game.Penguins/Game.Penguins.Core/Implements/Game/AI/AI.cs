using Game.Penguins.Core.Implements.Game.Actions;
using Game.Penguins.Core.Implements.Game.GameBoard;
using Game.Penguins.Core.Implements.Game.Players;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using System;
using System.Collections.Generic;

namespace Game.Penguins.Core.Implements.Game.AI
{
    public class AI
    {
        public AI()
        {
            Players = new List<IPlayer>();
            aleatoire = new Random();
        }
        /// <summary>
        /// private except for test
        /// </summary>
        public Player CurrentPlayer { get; set; }
        /// <summary>
        /// private except for test
        /// </summary>
        public IList<IPlayer> Players { get; set; }
        /// <summary>
        /// private except for test
        /// </summary>
        public Random aleatoire { get; }

        /// <summary>
        /// Place Penguin on Cell with one Fish Randomly
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Cell PlacePenguin(Plateau board)
        {
            Cell temp; 
            do
            {
                temp = board.Board[aleatoire.Next(8), aleatoire.Next(8)] as Cell;

            } while (!(temp.CellType == CellType.Fish && temp.FishCount == 1));

            return temp;
        }

        /// <summary>
        /// Move AI randomly except FishCount
        /// TO DO : 
        ///     not choose a Penguin randomly, 
        ///     check if destination is a deadend or not, 
        ///     check if enemy Penguin is blocked
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<Cell> Move(Plateau board, Player player)
        {
            CurrentPlayer = player;
            int i = (int)CurrentPlayer.PlayerType;
            var myPengs = board.GetMyPenguins(CurrentPlayer.Identifier);
            int test = aleatoire.Next(myPengs.Count);
            List<Cell> moveToMake = new List<Cell>();
            do
            {
                var list = GetCellsWithMyFish(myPengs[test], i, board);
                if (list.Count > 0) //move possible, so pick one randomly
                {
                    moveToMake.Add(myPengs[test]); //cell origin
                    moveToMake.Add(list[aleatoire.Next(list.Count)]); //cell destination
                    return moveToMake;
                }
                else //no move possible for i Fish so modify i Fish
                {
                    if (CurrentPlayer.PlayerType == PlayerType.AIEasy) //go for 1 then 2 then 3
                    {
                        i++;
                    }
                    else if (CurrentPlayer.PlayerType == PlayerType.AIHard) //go for 3 then 2 then 1
                    {
                        i--;
                    }
                    else //AIMedium go for 2 then 3 then 1 // 4==break the loop
                    {
                        i = (i == 3) ? 1 : (i == 2) ? 3 : 4;
                    };
                }
            } while (i!=0 && i!=4);
            return moveToMake;
        }

        /// <summary>
        /// Get List of possible Cells to move with the number Fish of choice
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="nbFish">number of Fish</param>
        /// <param name="board"></param>
        /// <returns name="possibleMove"></returns>
        public List<Cell> GetCellsWithMyFish(Cell origin, int nbFish, Plateau board)
        {
            List<Cell> possibleMove = new List<Cell>();
            Cell newOrigin = origin;
            Cell temp = null;

            //Get all possible moves from origin, one direction at a time, cell by cell
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    temp = board.GetAvailableCell(newOrigin, (Direction)i);
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

            //Remove Cells whith a different amount of Fishs
            possibleMove.RemoveAll(el => el.FishCount != nbFish);
            return possibleMove;
        }
    }
}
