using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;

namespace Game.Penguins.Core.Implements.Game.GameBoard
{
    public class Penguin : IPenguin
    {
        public Penguin(IPlayer player)
        {
            Player = player;
        }

        public IPlayer Player { get; }
    }
}
