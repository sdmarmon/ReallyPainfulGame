using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Player : Entity
    {
        private const int _xpMax = 100;
        private int _experience;
        private Armor _armor;
        private Boots _boots;
        private Gloves _gloves;
        private Helmet _helmet;
        private Weapon _weapon;

        public Player(string name, int attack, int defense, int critical, int speed) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _experience = 0;
        }

        public void battle(ref Enemy enemy)
        {
            Console.WriteLine("--- "+ enemy.Name +" ---");
            Console.WriteLine("Hp: " + enemy.Health + "/"+ enemy.HealthMax);
            Console.WriteLine("------------------");
            Console.WriteLine("--- " + Name + " ---");
            Console.WriteLine("Hp: " + Health + "/" + HealthMax);
            Console.WriteLine("Mp: " + Mana + "/" + ManaMax);
            Console.WriteLine("------------------");
            string choice = Console.ReadLine();

        }

        public void attack(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void levelUp()
        {

        }
        
        public abstract void spell();

    }

}
