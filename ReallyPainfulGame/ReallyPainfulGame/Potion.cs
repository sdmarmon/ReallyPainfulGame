using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Potion : Consumable
    {
        private int _health;
        public Potion(string name, int health,int price) : base(name,price)
        {
            _health = health;
        }

        /*
          Name : Use
          Description : The Potion heals the player
          Parameters :
              in out Player player
       */
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

        /* Construct different types of Potions */
        public static Potion SimplePotion()
        {
            return new Potion("Potion", 10,10);
        }
        public static Potion SuperPotion()
        {
            return new Potion("Super Potion", 25,25);
        }
        public static Potion HyperPotion()
        {
            return new Potion("Hyper Potion", 50,50);
        }
        public static Potion PotionX()
        {
            return new Potion("Potion X", 100,100);
        }
    }
}
