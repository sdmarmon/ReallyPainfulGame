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

        public override void Use(Player player)
        {
            if (player.Health+_health >= player.HealthMax)
            {
                player.Health = player.HealthMax;
            }
            else
            {
                player.Health += _health;
            }
        }

        public override string ToString()
        {
            return (base.ToString() + "Vous rend " + this._health + "PV.\n");
        }

        public static Potion SimplePotion()
        {
            return new Potion("Potion", 10);
        }
        public static Potion SuperPotion()
        {
            return new Potion("Super Potion", 25);
        }
        public static Potion HyperPotion()
        {
            return new Potion("Hyper Potion", 50);
        }
        public static Potion PotionX()
        {
            return new Potion("Potion X", 100);
        }
    }
}
