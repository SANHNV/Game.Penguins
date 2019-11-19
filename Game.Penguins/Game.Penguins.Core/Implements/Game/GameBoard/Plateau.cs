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
            var points = Enumerable.Repeat(1, 34).ToList();
            points.AddRange(Enumerable.Repeat(2, 20).ToList());
            points.AddRange(Enumerable.Repeat(3, 10).ToList());
            var random = new Random();

            for (int hor=0; hor<8;hor++)
            {
                for(int ver=0; ver<8;ver++)
                {
                    var pointIndex = random.Next(0, points.Count);
                    Board[hor, ver] = new Cell(CellType.Fish, pointIndex);
                    points.RemoveAt(pointIndex);
                }
            }
        }
        /// <summary>
        /// Plateau composé de Cell
        /// </summary>
        public ICell[,] Board { get; set; }
    }
}
