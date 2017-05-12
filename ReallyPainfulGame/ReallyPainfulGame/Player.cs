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

        private Room _currentRoom;
        private Room _spawn;

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

        public Player(string name, int attack, int defense, int critical, int speed, Room spawn) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _experience = 0;
            _spawn = spawn;
            Respawn();
            _inventory = new List<Item>();
        }

        public bool Battle(Enemy enemy)
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
                    BattleAction(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.Fight(this);
                    }
                }
                else
                {
                    if (enemy.Health > 0)
                    {
                        enemy.Fight(this);
                    }
                    BattleAction(enemy);
                }
            }
            Console.Clear();

            if (enemy.Health <= 0)
            {
                win = true;
            }

            return win;
        }

        public void Fight(Enemy enemy)
        {
            int damages = Attack;
            if (Weapon != null)
            {
                damages += Weapon.Attack;
            }

            enemy.Health -= GetDamages(damages, enemy.Defense);
        }

        public void LevelUp(Enemy enemy)
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
                Regeneration();
            }
            Console.WriteLine("Experience : " + _experience);

        }

        public void BattleAction(Enemy enemy)
        {
            if (Health > 0)
            {
                string[] choices = new string[] {"1", "2"};
                string choice = "";
                do
                {
                    choice = Console.ReadLine();
                } while (!choices.Contains(choice));

                switch (choice)
                {
                    case "1":
                        Fight(enemy);
                        break;
                    case "2":
                        Spell(enemy);
                        break;
                    case "3":
                        
                        break;
                    case "4":

                        break;
                }
            }
        }

        public void Looting(Enemy enemy)
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

        /* Fight against an enemy */
        public void Duel()
        {
            if (_currentRoom.Monster != null)
            {
                Enemy monster = _currentRoom.Monster;
                if (Battle(monster))
                {
                    Console.WriteLine("Vous avez tué un " + monster.Name);
                    LevelUp(monster);
                    /* Loot enemy */
                    Looting(monster);

                }
                else
                {
                    /* Respawn */
                    Console.WriteLine("Vous avez été tué par un " + monster.Name);
                    Respawn();
                    Regeneration();
                }
            }
        }

        /* Move player */
        public void Move()
        {
            Console.WriteLine(_currentRoom);
            Console.WriteLine("Choisissez une direction");
            Console.WriteLine("1: Nord");
            Console.WriteLine("2: Sud");
            Console.WriteLine("3: Ouest");
            Console.WriteLine("4: Est");
            Console.WriteLine("------------------");

            string choice = "";
            Direction next;
            do
            {
                /* Check the action */
                string[] choices = new string[] { "1", "2", "3" ,"4"};
                do
                {
                    choice = Console.ReadLine();
                } while (!choices.Contains(choice));

                /* Define next room */
                next = (Direction)(int.Parse(choice) - 1);
                if (_currentRoom.Rooms[next] == null)
                {
                    Console.WriteLine("vous ne pouvez pas aller dans cette direction");
                }
            } while (_currentRoom.Rooms[next] == null);

            _currentRoom = _currentRoom.Rooms[next];
            Console.Clear();
        }

        public void Respawn()
        {
            _currentRoom = _spawn;
        }

        public abstract void Spell(Enemy enemy);

    }

}
