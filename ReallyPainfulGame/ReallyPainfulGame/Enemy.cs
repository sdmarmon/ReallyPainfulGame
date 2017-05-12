using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Enemy : Entity
    {
        private Equipment _loot;
        public Equipment Loot
        {
            get
            {
                return _loot;
            }

            set
            {
                _loot = value;
            }
        }
        // Constructeur pour tests
        public Enemy() : base("Ennemi", 1, 10, 100, 10, 5, 2, 10, 10)
        {
            Loot = new Weapon("Masamune",4, 50);
        }
        public Enemy(int level) : base("Ennemi", 1, 10, 100, 10, 5, 2, 10, 10)
        {
            Loot = new Weapon("1", level, 10);
        }

        public Enemy(string name, int level, int healthMax, int manaMax, int attack, int defense, int critical, int speed, int golds, Equipment loot) : 
            base(name, level, healthMax, manaMax, attack, defense, critical, speed, golds)
        {
            Loot = loot;
        }

        public void Fight(Player player)
        {
            player.Health -= GetDamages(Attack, player.Defense);
            Console.WriteLine(this.Name + " vous attaque ! Il vous retire " + GetDamages(Attack, player.Defense) + "PV.\n");
        }
    }
}
