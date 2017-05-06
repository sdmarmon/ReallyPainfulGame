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

        private List<Item> _inventory;

        public Weapon Weapon
        {
            get
            {
                return _weapon;
            }

            set
            {
                _weapon = value;
            }
        }

        public Player(string name, int attack, int defense, int critical, int speed) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _experience = 0;
            _inventory = new List<Item>();
        }

        public bool battle(Enemy enemy)
        {
            bool win = false;
            while (Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                Console.WriteLine("--- " + enemy.Name + " ---");
                Console.WriteLine("Hp: " + enemy.Health + "/" + enemy.HealthMax);
                Console.WriteLine("------------------");
                Console.WriteLine("--- " + Name + " ---");
                Console.WriteLine("Hp: " + Health + "/" + HealthMax);
                Console.WriteLine("Mp: " + Mana + "/" + ManaMax);
                Console.WriteLine("------------------");
                Console.WriteLine("1: Attaque basique");
                Console.WriteLine("2: Lancer un sort");
                Console.WriteLine("3: Boire une potion");

                if (Health > 0)
                {
                    string choice = "";
                    do
                    {
                        choice = Console.ReadLine();
                    } while (choice != "1");

                    switch (choice)
                    {
                        case "1":
                            attack(enemy);
                            break;
                        case "2":

                            break;
                        case "3":

                            break;
                        case "4":

                            break;
                    }
                }

                if (enemy.Health > 0)
                {
                    enemy.attack(this);
                }
            }
            Console.Clear();

            if (enemy.Health <= 0)
            {
                win = true;
            }

            return win;
        }

        public void attack(Enemy enemy)
        {
            int damages = Attack;
            if (Weapon != null)
            {
                damages += Weapon.Attack;
            }
            
            enemy.Health -= (int)(((2 * damages - enemy.Defense) / 2) * Math.Pow(damages, 1/3) * Math.Sqrt(enemy.Defense));
        }

        public void levelUp(Enemy enemy)
        {
            _experience = (int)(10 * Math.Pow(enemy.Level / Level,2));
            if(_experience>=100)
            {
                Level++;
                HealthMax += 5;
                Health = HealthMax;
                ManaMax += 2;
                Mana = ManaMax;
                Critical++;

                Attack++;
                Defense++;
                Speed++;
                _experience = 0;
            }
            Console.WriteLine("Experience : "+_experience);

        }

        public abstract void spell();

    }

}
