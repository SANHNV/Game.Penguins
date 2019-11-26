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

        private PlayerColor color { get; set; }
        public PlayerColor Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        private string name { get; set; }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        private int points { get; set; }
        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        private int penguins { get; set; }
        public int Penguins
        {
            get
            {
                return penguins;
            }

            set
            {
                penguins = value;
                if (StateChanged != null)
                    StateChanged.Invoke(this, null);

            }
        }

        public event EventHandler StateChanged;
    }
}
