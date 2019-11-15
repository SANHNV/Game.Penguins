using Game.Penguins.Core.Interfaces.Game.GameBoard;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Board : IBoard
    {
        public Board()
        {
            
        }

        ICell[,] IBoard.Board { get; }
    }
}
