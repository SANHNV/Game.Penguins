using Game.Penguins.Core.Implements.Game.Actions;
using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Plateau : IBoard
    {
        /// <summary>
        /// Initialisation de chaque Cell de Board avec un nombre de poisson aléatoire
        /// </summary>
        public Plateau()
        {
            Board = new Cell[8, 8];
            var points = Enumerable.Repeat(1, 34).ToList();
            points.AddRange(Enumerable.Repeat(2, 20).ToList());
            points.AddRange(Enumerable.Repeat(3, 10).ToList());
            var random = new Random();

            for (int hor=0; hor<8;hor++)
            {
                for(int ver=0; ver<8;ver++)
                {
                    var pointIndex = random.Next(0, points.Count);
                    Board[hor, ver] = new Cell(CellType.Fish, points[pointIndex], ver, hor);
                    points.RemoveAt(pointIndex);
                }
            }
        }

        /// <summary>
        /// Plateau composé de Cell
        /// </summary>
        public ICell[,] Board { get; set; }

        /// <summary>
        /// Returns List de cells with penguins for a player
        /// </summary>
        /// <param name="playerIdentifier"></param>
        /// <returns></returns>
        public List<Cell> GetMyPenguins(Guid playerIdentifier)
        {
            var result = new List<Cell>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell temp = Board[i, j] as Cell;
                    //CellWithPenguin && Player==Player
                    if (Board[i, j].CellType == CellType.FishWithPenguin && Board[i, j].CurrentPenguin.Player.Identifier == playerIdentifier)
                        result.Add(temp);
                }
            }

            return result;
        }

        /// <summary>
        /// Return List Cell Available Around
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public List<Cell> GetListCellsAvailableAround(Cell origin)
        {
            var result = new List<Cell>();
            for (int i = 0; i <= 5; i++)
            {
                Cell temp = GetAvailableCell(origin, (Direction)i);
                // use try catch to replace if ?
                if (temp!= null)
                    result.Add(temp);
            }
            return result ;
        }

        /// <summary>
        /// Return Cell in direction or null
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Cell GetAvailableCell(Cell origin, Direction direction)
        {
            var board = Board as Cell[,];
            Cell destination = null;
            int xDest = 0;
            switch (direction)
            {
                case Direction.Left:
                    if (origin.H > 0)
                    {
                        destination = board[origin.H - 1, origin.V];
                    }
                    break;
                case Direction.Right:
                    if (origin.H < 7)
                    {
                        destination = board[origin.H + 1, origin.V];
                    }
                    break;
                case Direction.TopLeft:
                    xDest = (origin.H % 2 == 0) ? origin.H : origin.H -1;
                    if (xDest >= 0 && origin.V > 0)
                    {
                        destination = board[xDest, origin.V - 1];
                    }
                    break;
                case Direction.TopRight:
                    xDest = (origin.H % 2 == 0) ? origin.H +1 : origin.H;
                    if (xDest < 8 && origin.V > 0)
                    {
                        destination = board[xDest, origin.V - 1];
                    }
                    break;
                case Direction.BottomLeft:
                    xDest = (origin.H % 2 == 0) ? origin.H : origin.H -1;
                    if (xDest >= 0 && origin.V < 7)
                    {
                        destination = board[xDest, origin.V + 1];
                    }
                    break;
                case Direction.BottomRight:
                    xDest = (origin.H % 2 == 0) ? origin.H +1 : origin.H;
                    if (xDest < 8 && origin.V < 7)
                    {
                        destination = board[xDest, origin.V + 1];
                    }
                    break;
            }
            return destination;
        }
    }
}
