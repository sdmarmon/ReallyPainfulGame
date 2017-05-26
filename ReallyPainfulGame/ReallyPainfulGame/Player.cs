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
        private bool _win;
        private Armor _armor;
        private Boots _boots;
        private Gloves _gloves;
        private Helmet _helmet;
        private Weapon _weapon;

        private int _effectiveHealth;
        private int _effectiveAttack;
        private int _effectiveDefense;
        private int _effectiveCritical;
        private int _effectiveSpeed;

        private Room _currentRoom;
        private Room _spawn;

        private List<Consumable> _inventory;

        protected int _spellManaCost;

        public List<Consumable> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

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

        public bool Win
        {
            get
            {
                return _win;
            }
        }

        public int EffectiveDefense
        {
            get
            {
                return _effectiveDefense;
            }

            set
            {
                _effectiveDefense = value;
            }
        }

        public Player(string name, int attack, int defense, int critical, int speed, Room spawn) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _win = false;
            _experience = 0;
            _spawn = spawn;
            Respawn();
            _inventory = new List<Consumable>();
            _effectiveHealth = HealthMax;
            _effectiveAttack = Attack;
            EffectiveDefense = Defense;
            _effectiveSpeed = Speed;
            _effectiveCritical = Critical;
        }

        /*
         Name : Fighting
         Description : 
            Combat infos, menu and actions
            Return the result of the battle
         Parameters :
             in out Enemy enemy
             out bool win
        */
        private bool Fighting(Enemy enemy)
        {
            bool win = false;
            while (Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("--- " + enemy.Name + " ---");
                Console.WriteLine("Hp: " + enemy.Health + "/" + enemy.HealthMax);
                Console.WriteLine("------------------");
                Console.WriteLine("--- " + Name + " ---");
                Console.WriteLine("Hp: " + Health + "/" + _effectiveHealth);
                Console.WriteLine("Mp: " + Mana + "/" + ManaMax);
                Console.WriteLine("------------------");
                Console.WriteLine("1: Attaque basique");
                Console.WriteLine("2: Lancer un sort");
                if (_inventory.OfType<Potion>().Any())
                {
                    Console.WriteLine("3: Boire une potion");
                }

                /* The fastest strikes fisrt */
                if (Speed >= enemy.Speed)
                {
                    BattleActions(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.HitPlayer(this);
                    }
                }
                else
                {
                    if (enemy.Health > 0)
                    {
                        enemy.HitPlayer(this);
                    }
                    BattleActions(enemy);
                }
            }
            Console.Clear();

            if (enemy.Health <= 0)
            {
                win = true;
            }

            return win;
        }

        /*
         Name : HitEnemy
         Description : The player deals damages to enemy
         Parameters :
             in out Enemy enemy
        */
        private void HitEnemy(Enemy enemy)
        {
            enemy.Health -= GetDamages(_effectiveAttack, enemy.Defense);
            Console.WriteLine("Vous attaquez "+enemy.Name+" ! Votre attaque lui retire "+GetDamages(_effectiveAttack,enemy.Defense)+"PV.\n");
        }

        /*
         Name : LevelUp
         Description : Get some experience from the enemy and level up
         Parameters :
             in out Enemy enemy
        */
        private void LevelUp(Enemy enemy)
        {
            _experience = (int)(10 * Math.Pow(enemy.Level / Level, 2));
            if (_experience >= _xpMax)
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

        /*
         Name : BattleActions
         Description : The player choose an action to perform
         Parameters :
             in out Enemy enemy
        */
        private void BattleActions(Enemy enemy)
        {
            if (Health > 0)
            {
                List<string> choices = new List<string> (new string[] {"1","2"});
                if (_inventory.OfType<Potion>().Any())
                {
                    choices.Add("3");
                }

                string choice = "";
                do
                {
                    choice = Console.ReadLine();
                } while (!choices.Contains(choice));

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        HitEnemy(enemy);
                        break;
                    case "2":
                        Spell(enemy);
                        break;
                    case "3":

                        choices.Clear();
                        Console.WriteLine("Choisissez une potion");
                        if (SearchItem("Potion")!=-1)
                        {
                            Console.WriteLine("1: Potion");
                            choices.Add("1");

                        }
                        if (SearchItem("Super Potion") != -1)
                        {
                            Console.WriteLine("2: Super Potion");
                            choices.Add("2");
                        }
                        if (SearchItem("Hyper Potion") != -1)
                        {
                            Console.WriteLine("3: Hyper Potion");
                            choices.Add("3");
                        }
                        if (SearchItem("Potion X") != -1)
                        {
                            Console.WriteLine("4: Potion X");
                            choices.Add("4");
                        }
                        choice = "";
                        do
                        {
                            choice = Console.ReadLine();
                        } while (!choices.Contains(choice));
                        Console.Clear();
                        switch (choice)
                        {
                            case "1":
                                UseConsumable("Potion");
                                break;
                            case "2":
                                UseConsumable("Super Potion");
                                break;
                            case "3":
                                UseConsumable("Hyper Potion");
                                break;
                            case "4":
                                UseConsumable("Potion X");
                                break;
                        }

                        break;
                    case "4":
                        break;
                }
            }
        }

        /*
         Name : Looting
         Description : Loot the money and the equipment on the enemy
         Parameters :
             in out Enemy enemy
        */
        private void Looting(Enemy enemy)
        {
            Gold += enemy.Gold;
            switch (enemy.Loot.GetType().Name)
            {
                case "Armor":
                    if (_armor != null)
                    {
                        if (enemy.Loot.Level > _armor.Level)
                        {
                            _armor = enemy.Loot as Armor;
                            EffectiveDefense = Defense + _armor.Defense;
                        }
                    }
                    else
                    {
                        _armor = enemy.Loot as Armor;
                        EffectiveDefense = Defense + _armor.Defense;
                    }
                    break;
                case "Boots":
                    if (_boots != null)
                    {
                        if (enemy.Loot.Level > _boots.Level)
                        {
                            _boots = enemy.Loot as Boots;
                            _effectiveSpeed = Speed + _boots.Speed;
                        }
                    }
                    else
                    {
                        _boots = enemy.Loot as Boots;
                        _effectiveSpeed = Speed + _boots.Speed;
                    }
                    break;
                case "Gloves":
                    if (_gloves != null)
                    {
                        if (enemy.Loot.Level > _gloves.Level)
                        {
                            _gloves = enemy.Loot as Gloves;
                            _effectiveCritical = Critical + _gloves.Critical;
                        }
                    }
                    else
                    {
                        _gloves = enemy.Loot as Gloves;
                        _effectiveCritical = Critical + _gloves.Critical;
                    }
                    break;
                case "Helmet":
                    if (_helmet != null)
                    {
                        if (enemy.Loot.Level > _helmet.Level)
                        {
                            _helmet = enemy.Loot as Helmet;
                            _effectiveHealth = HealthMax + _helmet.Health;
                        }
                    }
                    else
                    {
                        _helmet = enemy.Loot as Helmet;
                        _effectiveHealth = HealthMax + _helmet.Health;
                    }
                    break;
                case "Weapon":
                    if (_weapon != null)
                    {
                        if (enemy.Loot.Level > _weapon.Level)
                        {
                            _weapon = enemy.Loot as Weapon;
                            _effectiveAttack = Attack + _weapon.Attack;
                        }
                    }
                    else
                    {
                        _weapon = enemy.Loot as Weapon;
                        _effectiveAttack = Attack + _weapon.Attack;
                    }

                    break;
            }
        }

        /*
         Name : Duel
         Description : Main combat method
         Parameters :
             in out Enemy enemy
        */
        public void Duel()
        {
            if (_currentRoom.Monster != null && _currentRoom.Monster.Health > 0)
            {
                Enemy monster = _currentRoom.Monster;
                if (Fighting(monster))
                {
                    Console.WriteLine("Vous avez tué un " + monster.Name);
                    // Victory ?
                    if(monster.Name == "Boss Dragon")
                    {
                        _win = true;
                    }

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

        /*
         Name : Move
         Description : Display a menu allowing to choose your next room
       */
        public void Move()
        {
            if (_currentRoom.Npc != null)
            {
                _currentRoom.Npc.Talk(this);
            }
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

        /*
         Name : Respawn
         Description : Teleports the player to his respawn location
       */
        public void Respawn()
        {
            _currentRoom = _spawn;
        }

        /*
         Name : Spell
         Description : Cast a spell on the enemy
         Parameters :
             in out Enemy enemy
       */
        public abstract void Spell(Enemy enemy);

        /*
         Name : SearchItem
         Description : Find the index of an item in the inventory
         Parameters :
             in string name
             out int index
        */
        private int SearchItem(string name)
        {
            int index = _inventory.FindIndex(x => x.Name == name);
            return index;
        }

        /*
         Name : UseConsumable
         Description : The player uses a consumable and remove it from his inventory
         Parameters :
             in string name
        */
        private void UseConsumable(string name)
        {
            int index = SearchItem(name);
            if (index != -1)
            {
                Consumable usedConsumable = _inventory.ElementAt(index) as Consumable;
                usedConsumable.Use(this);
                Console.WriteLine("Vous utilisez : " + _inventory.ElementAt(index).Name + ".");
                Console.WriteLine(_inventory.ElementAt(index).ToString());
                _inventory.RemoveAt(index);
            }
        }

        public void DisplayEquipment()
        {

        }

        public override string ToString()
        {
            string s = "------------------\n";
            s += "\nPV : " + (this.Health) + "/" + (_effectiveHealth);
            s += "\nMana : " + (this.Mana) + "/" + (ManaMax);
            s += "\nAttaque : " + (_effectiveAttack);
            s += "\nDéfense : " + (EffectiveDefense);
            s += "\nVitesse : " + (_effectiveSpeed);
            s += "\nCritique : " + (_effectiveCritical);
            return s;
        }
    }

}
