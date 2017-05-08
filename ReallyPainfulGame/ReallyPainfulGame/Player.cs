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

                /* The fastest strikes fisrt */
                if (Speed >= enemy.Speed)
                {
                    battleAction(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.attack(this);
                    }
                }
                else
                {
                    if (enemy.Health > 0)
                    {
                        enemy.attack(this);
                    }
                    battleAction(enemy);
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

            enemy.Health -= (int)(((2 * damages - enemy.Defense) / 2) * Math.Pow(damages, 1 / 3) / Math.Sqrt(enemy.Defense));
        }

        public void levelUp(Enemy enemy)
        {
            _experience = (int)(10 * Math.Pow(enemy.Level / Level, 2));
            if (_experience >= 100)
            {
                Level++;
                HealthMax += 5;
                ManaMax += 2;
                Critical++;
                Attack++;
                Defense++;
                Speed++;
                _experience = 0;
                regeneration();
            }
            Console.WriteLine("Experience : " + _experience);

        }

        public void battleAction(Enemy enemy)
        {
            if (Health > 0)
            {
                string choice = "";
                do
                {
                    choice = Console.ReadLine();
                } while (choice != "1" && choice != "2");

                switch (choice)
                {
                    case "1":
                        attack(enemy);
                        break;
                    case "2":
                        spell(enemy);
                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                }
            }
        }

        public void looting(Enemy enemy)
        {
            Golds += enemy.Golds;
            switch (enemy.Loot.GetType().Name)
            {
                case "Armor":
                    if (_armor != null)
                    {
                        if (enemy.Loot.Level > _armor.Level)
                        {
                            _armor = enemy.Loot as Armor;
                        }
                    }
                    else
                    {
                        _armor = enemy.Loot as Armor;
                    }
                    break;
                case "Boots":
                    if (_boots != null)
                    {
                        if (enemy.Loot.Level > _boots.Level)
                        {
                            _boots = enemy.Loot as Boots;
                        }
                    }
                    else
                    {
                        _boots = enemy.Loot as Boots;
                    }
                    break;
                case "Gloves":
                    if (_gloves != null)
                    {
                        if (enemy.Loot.Level > _gloves.Level)
                        {
                            _gloves = enemy.Loot as Gloves;
                        }
                    }
                    else
                    {
                        _gloves = enemy.Loot as Gloves;
                    }
                    break;
                case "Helmet":
                    if (_helmet != null)
                    {
                        if (enemy.Loot.Level > _helmet.Level)
                        {
                            _helmet = enemy.Loot as Helmet;
                        }
                    }
                    else
                    {
                        _helmet = enemy.Loot as Helmet;
                    }
                    break;
                case "Weapon":
                    if (_weapon != null)
                    {
                        if (enemy.Loot.Level > _weapon.Level)
                        {
                            _weapon = enemy.Loot as Weapon;
                        }
                    }
                    else
                    {
                        _weapon = enemy.Loot as Weapon;
                    }
                    break;
            }
        }

        public void equipmentChoice(Equipment equi)
        {

        }
        public abstract void spell(Enemy enemy);

    }

}
