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
        /// Return List Cell Available one case Around
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public List<Cell> GetListCellsAvailableAround(Cell origin)
        {
            var result = new List<Cell>();
            for (int i = 0; i < 6; i++)
            {
                Cell temp = GetAvailableCell(origin, (Direction)i);

                if (temp!= null && temp.CellType == CellType.Fish)
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
            int vDest = 0;
            switch (direction)
            {
                case Direction.Left:
                    if (origin.V > 0)
                    {
                        destination = board[origin.H, origin.V-1];
                    }
                    break;
                case Direction.Right:
                    if (origin.V < 7)
                    {
                        destination = board[origin.H, origin.V+1];
                    }
                    break;
                case Direction.TopLeft:
                    vDest = (origin.H % 2 == 0) ? origin.V : origin.V-1;
                    if (vDest >= 0 && origin.H > 0)
                    {
                        destination = board[origin.H-1, vDest];
                    }
                    break;
                case Direction.TopRight:
                    vDest = (origin.H % 2 == 0) ? origin.V+1 : origin.V;
                    if (vDest < 8 && origin.H > 0)
                    {
                        destination = board[origin.H-1, vDest];
                    }
                    break;
                case Direction.BottomLeft:
                    vDest = (origin.H % 2 == 0) ? origin.V : origin.V -1;
                    if (vDest >= 0 && origin.H < 7)
                    {
                        destination = board[origin.H+1, vDest];
                    }
                    break;
                case Direction.BottomRight:
                    vDest = (origin.H % 2 == 0) ? origin.V+1 : origin.V;
                    if (vDest < 8 && origin.H < 7)
                    {
                        destination = board[origin.H+1, vDest];
                    }
                    break;
            }
            return destination;
        }
    }
}
