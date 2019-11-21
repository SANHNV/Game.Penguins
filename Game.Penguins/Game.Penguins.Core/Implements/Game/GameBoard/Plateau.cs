using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
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
            P_Board = new Cell[8, 8];
            var points = Enumerable.Repeat(1, 34).ToList();
            points.AddRange(Enumerable.Repeat(2, 20).ToList());
            points.AddRange(Enumerable.Repeat(3, 10).ToList());
            var random = new Random();

            for (int ver=0; ver<8;ver++)
            {
                for(int hor=0; hor<8;hor++)
                {
                    var pointIndex = random.Next(0, points.Count);
                    Board[hor, ver] = new Cell(CellType.Fish, pointIndex, ver, hor);
                    points.RemoveAt(pointIndex);
                }
            }
        }
        private Cell[,] P_Board { get; set; }
        /// <summary>
        /// Plateau composé de Cell
        /// </summary>
        public ICell[,] Board
        {
            get
            {
                return P_Board;
            }
        }
    }
}
