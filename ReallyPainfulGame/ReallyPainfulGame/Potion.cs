using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Potion : Consumable
    {
        private int _health;
        public Potion(string name, int health) : base(name)
        {
            _health = health;
        }

        public override void use(Player player)
        {
            player.Health += _health;
        }
    }
}
