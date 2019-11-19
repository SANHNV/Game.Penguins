using Game.Penguins.Core.Interfaces.Game.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Implements.Game.Players
{
    public class Player : IPlayer
    {
        public Player(PlayerType playerType, PlayerColor color, string name, int penguins)
        {
            Identifier = Guid.NewGuid();
            PlayerType = playerType;
            Name = name;
            Points = 0;
            Penguins = penguins;
        }

        public Guid Identifier { get; }

        public PlayerType PlayerType { get; }

        public PlayerColor Color { get; }

        public string Name { get; }

        public int Points { get; set; }

        public int Penguins { get; set; }

        public event EventHandler StateChanged;
    }
}
