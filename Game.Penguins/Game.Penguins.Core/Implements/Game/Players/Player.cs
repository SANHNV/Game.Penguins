using Game.Penguins.Core.Interfaces.Game.Players;
using System;

namespace Game.Penguins.Core.Implements.Game.Players
{
    public class Player : IPlayer
    {
        public Player(PlayerType playerType, string name)
        {
            Identifier = Guid.NewGuid();
            PlayerType = playerType;
            Name = name;
            Color = PlayerColor.Blue;
            Points = 0;
            Penguins = 0;
        }

        public Guid Identifier { get; }

        public PlayerType PlayerType { get; }
        public PlayerColor Color { get; set; }

        public string Name { get; }
        public int Points { get; set; }
        public int Penguins { get; set; }

        public event EventHandler StateChanged;
    }
}
