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
        private bool _leave;
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

        public bool Leave
        {
            get
            {
                return _leave;
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

        public int EffectiveAttack
        {
            get
            {
                return _effectiveAttack;
            }

            set
            {
                _effectiveAttack = value;
            }
        }

        public int EffectiveCritical
        {
            get
            {
                return _effectiveCritical;
            }

            set
            {
                _effectiveCritical = value;
            }
        }

        public int EffectiveHealth
        {
            get
            {
                return _effectiveHealth;
            }

            set
            {
                _effectiveHealth = value;
            }
        }

        public int EffectiveSpeed
        {
            get
            {
                return _effectiveSpeed;
            }

            set
            {
                _effectiveSpeed = value;
            }
        }

        public Armor Armor
        {
            get
            {
                return _armor;
            }

            set
            {
                _armor = value;
            }
        }

        public Boots Boots
        {
            get
            {
                return _boots;
            }

            set
            {
                _boots = value;
            }
        }

        public Gloves Gloves
        {
            get
            {
                return _gloves;
            }

            set
            {
                _gloves = value;
            }
        }

        public Helmet Helmet
        {
            get
            {
                return _helmet;
            }

            set
            {
                _helmet = value;
            }
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

        public Player(string name, int attack, int defense, int critical, int speed, Room spawn) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _leave = false;
            _experience = 0;
            _spawn = spawn;
            Respawn();
            _inventory = new List<Consumable>();
            EffectiveHealth = HealthMax;
            EffectiveAttack = Attack;
            EffectiveDefense = Defense;
            EffectiveSpeed = Speed;
            EffectiveCritical = Critical;
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
                Console.WriteLine("Hp: " + Health + "/" + EffectiveHealth);
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
        protected void HitEnemy(Enemy enemy)
        {
            enemy.Health -= GetDamages(EffectiveAttack, enemy.Defense);
            Console.WriteLine("Vous attaquez "+enemy.Name+" ! Votre attaque lui retire "+GetDamages(EffectiveAttack,enemy.Defense)+"PV.\n");
        }

        /*
          Name : Regeneration
          Description : Restore all the Health and Mana
        */
        public override void Regeneration()
        {
            Health = EffectiveHealth;
            Mana = ManaMax;
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
                Console.WriteLine("Level up !");
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
                        Console.Clear();
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
                    if (Armor != null)
                    {
                        if (enemy.Loot.Level > Armor.Level)
                        {
                            Armor = enemy.Loot as Armor;
                            EffectiveDefense = Defense + Armor.Defense;
                            Console.WriteLine("Vous obtenez : " + enemy.Loot);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Armor = enemy.Loot as Armor;
                        EffectiveDefense = Defense + Armor.Defense;
                        Console.WriteLine("Vous obtenez : " + enemy.Loot);
                        Console.ReadLine();
                    }
                    break;
                case "Boots":
                    if (Boots != null)
                    {
                        if (enemy.Loot.Level > Boots.Level)
                        {
                            Boots = enemy.Loot as Boots;
                            EffectiveSpeed = Speed + Boots.Speed;
                            Console.WriteLine("Vous obtenez : " + enemy.Loot);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Boots = enemy.Loot as Boots;
                        EffectiveSpeed = Speed + Boots.Speed;
                        Console.WriteLine("Vous obtenez : " + enemy.Loot);
                        Console.ReadLine();
                    }
                    break;
                case "Gloves":
                    if (Gloves != null)
                    {
                        if (enemy.Loot.Level > Gloves.Level)
                        {
                            Gloves = enemy.Loot as Gloves;
                            EffectiveCritical = Critical + Gloves.Critical;
                            Console.WriteLine("Vous obtenez : " + enemy.Loot);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Gloves = enemy.Loot as Gloves;
                        EffectiveCritical = Critical + Gloves.Critical;
                        Console.WriteLine("Vous obtenez : " + enemy.Loot);
                        Console.ReadLine();
                    }
                    break;
                case "Helmet":
                    if (Helmet != null)
                    {
                        if (enemy.Loot.Level > Helmet.Level)
                        {
                            Helmet = enemy.Loot as Helmet;
                            EffectiveHealth = HealthMax + Helmet.Health;
                            Console.WriteLine("Vous obtenez : " + enemy.Loot);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Helmet = enemy.Loot as Helmet;
                        EffectiveHealth = HealthMax + Helmet.Health;
                        Console.WriteLine("Vous obtenez : " + enemy.Loot);
                        Console.ReadLine();
                    }
                    break;
                case "Weapon":
                    if (Weapon != null)
                    {
                        if (enemy.Loot.Level > Weapon.Level)
                        {
                            Weapon = enemy.Loot as Weapon;
                            EffectiveAttack = Attack + Weapon.Attack;
                            Console.WriteLine("Vous obtenez : " + enemy.Loot);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Weapon = enemy.Loot as Weapon;
                        EffectiveAttack = Attack + Weapon.Attack;
                        Console.WriteLine("Vous obtenez : " + enemy.Loot);
                        Console.ReadLine();
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
                        Console.WriteLine("Bravo vous avez terminé le jeu\n");
                        Console.WriteLine("Voulez vous continuer de jouer ?");
                        Console.WriteLine("1: Oui");
                        Console.WriteLine("2: Non");
                        /* Check the action */
                        string choice;
                        do
                        {
                            choice = Console.ReadLine();
                        } while (choice != "1" && choice != "2");

                        if(choice == "2")
                        {
                            _leave = true;
                        }
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
         Description : Display a menu allowing to choose your next room and display helping tools
       */
        public void Move()
        {
            if (_currentRoom.Npc != null)
            {
                _currentRoom.Npc.Talk(this);
            }
            /* Check the action */
            Direction next;
            string[] choices = new string[] { "1", "2", "3", "4"};
            string choice = "";
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine(_currentRoom);
                    Console.WriteLine("Choisissez une direction");
                    Console.WriteLine("        1:Nord");
                    Console.WriteLine("3:Ouest" + "        " + "4:Est");
                    Console.WriteLine("        2:Sud");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Autres actions possibles");
                    Console.WriteLine("5 : Carte");
                    Console.WriteLine("6 : Inventaire");
                    Console.WriteLine("7 : Equipement");
                    Console.WriteLine("8 : Stats");
                    Console.WriteLine("9 : Aide");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "5":
                            DisplayMap();
                            break;
                        case "6":
                            DisplayInventory();
                            break;
                        case "7":
                            DisplayEquipment();
                            break;
                        case "8":
                            Console.WriteLine(ToString());
                            Console.ReadLine();
                            break;
                        case "9":
                            DisplayHelp();
                            break;
                    }
                }
                while (!choices.Contains(choice));

                /* Define next room */
                next = (Direction)(int.Parse(choice) - 1);
                if (_currentRoom.Rooms[next] == null)
                {
                    Console.WriteLine("Vous ne pouvez pas aller dans cette direction");
                    Console.ReadLine();
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

        /*
         Name : DisplayInventory
         Description : Displays the player's inventory and gold
        */
        public void DisplayInventory()
        {
            Console.WriteLine("Voici une liste de tous vos consommables");
            Console.WriteLine("------------------");
            foreach (Consumable consumable in _inventory)
            {
                Console.WriteLine(consumable);
            }
            Console.WriteLine("------------------");
            Console.WriteLine("Or en poche : "+Gold);
            Console.ReadLine();
        }

        /*
         Name : DisplayEquipment
         Description : Displays the player's equipment
        */
        public void DisplayEquipment()
        {
            Console.WriteLine("Voici votre équipement courant");
            Console.WriteLine("------------------");
            Console.Write("Arme : " + _weapon);
            Console.Write("\nArmure : " + _armor);
            Console.Write("\nCasque : " + _helmet);
            Console.Write("\nGants : " + _gloves);
            Console.Write("\nBottes : " + _boots +"\n");
            Console.ReadLine();
        }

        /*
         Name : DisplayMap
         Description : Displays Ivalice's cities map
        */
        public void DisplayMap()
        {
            Console.WriteLine("Voici la disposition des villes d'Ivalice");
            Console.WriteLine("------------------");
            Console.ReadLine();
        }

        /*
         Name : DisplayMap
         Description : Displays the use of each command
        */
        public void DisplayHelp()
        {
            Console.WriteLine("Fonction d'aide");
            Console.WriteLine("------------------");
            Console.WriteLine("Les actions listées sont accessibles grâce au numéro les précédant.");
            Console.WriteLine("Les commandes Nord, Sud, Ouest et Est vous permettent de vous déplacer dans le monde d'Ivalice.");
            Console.WriteLine("La commande Carte vous permet d'afficher la disposition des villes. La topologie des donjons vous est inconnue.");
            Console.WriteLine("La commande Inventaire vous permet d'afficher l'ensemble de vos consommables, ainsi que votre or.");
            Console.WriteLine("La commande Equipement vous permet d'afficher votre équipement courant.");
            Console.WriteLine("La commande Stats vous permet d'afficher vos statistiques courantes.");
            Console.ReadLine();
        }

        public override string ToString()
        {
            string s = "------------------\n";
            s += "\nPV : " + (this.Health) + "/" + (EffectiveHealth);
            s += "\nMana : " + (this.Mana) + "/" + (ManaMax);
            s += "\nAttaque : " + (EffectiveAttack);
            s += "\nDéfense : " + (EffectiveDefense);
            s += "\nVitesse : " + (EffectiveSpeed);
            s += "\nCritique : " + (EffectiveCritical);
            return s;
        }
    }

}
