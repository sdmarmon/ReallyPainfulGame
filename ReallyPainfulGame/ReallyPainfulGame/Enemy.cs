using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Enemy : Entity
    {
        private Equipment _loot;

        // Constructeur pour tests
        public Enemy() : base("Ennemi", 1, 10, 100, 10, 5, 2, 10, 10)
        {
            _loot = new Weapon("Masamune",4, 50);
        }
        public Enemy(string name, int level, int healthMax, int manaMax, int attack, int defense, int critical, int speed, int golds, Equipment loot) : 
            base(name, level, healthMax, manaMax, attack, defense, critical, speed, golds)
        {
            _loot = loot;
        }

        public void attack(Player player)
        {
            player.Health -= (int)(((2 * Attack - player.Defense) / 2) * Math.Pow(Attack, 1 / 3) / Math.Sqrt(player.Defense));
        }
    }
}
