using Game.Penguins.Core.Interfaces.Game.GameBoard;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Board : IBoard
    {
        private int nbFish1 = 34;
        private int nbFish2 = 20;
        private int nbFish3 = 10;

        public Board()
        {
            //create the board

        }

        ICell[,] IBoard.Board { get; }
    }
}
