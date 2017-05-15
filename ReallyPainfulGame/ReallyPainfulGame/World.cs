using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    class World
    {
        private Player _player;

        public World()
        {
            //playerCreation();

            Init();
            while (true) //sale, à changer
            {
                _player.Duel();
                _player.Move();
            }

            Console.ReadLine();
        }

        /* Player creation */
        public void PlayerCreation()
        {
            Room room1 = new Room("room 0.0", "Ceci est la room 0.0", null,null); // sale à revoir

            Console.WriteLine("Rentrez le nom de votre personnage :");
            string name = Console.ReadLine();
            string choice = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Choisissez votre classe de personnage");
                Console.WriteLine("1:Ecuyer");
                Console.WriteLine("2:Spadassin");
                Console.WriteLine("3:Paladin");
                Console.WriteLine("4:Ninja\n");
                choice = Console.ReadLine();

            } while (choice != "1" && choice != "2" && choice != "3" && choice != "4");
            Console.Clear();
            switch (choice)
            {
                case "1":
                    _player = new Squire(name,room1);
                    break;
                case "2":
                    _player = new Fighter(name, room1);
                    break;
                case "3":
                    _player = new Paladin(name, room1);
                    break;
                case "4":
                    _player = new Ninja(name, room1);
                    break;
            }

        }

        /* Create the world */
        public void Init()
        {

            Alchemist alchemist = new Alchemist();
            Room room1 = new Room("room 0.0", "Ceci est la room 0.0", null,alchemist);
            _player = new Squire("Moi",room1);
            _player.Inventory.Add(Potion.SimplePotion());
            Room room2 = new Room("room 1.0", "Ceci est la room 1.0", Enemy.Gobelin(),null);
            Room room3 = new Room("room 2.0", "Ceci est la room 2.0", null,null);
            Room room4 = new Room("room 0.1", "Ceci est la room 0.1", Enemy.Gobelin(),null);
            Room room5 = new Room("room 1.1", "Ceci est la room 1.1", null,null);

            room1.LinkRoom(ref room2, Direction.East);
            room2.LinkRoom(ref room3, Direction.East);
            room1.LinkRoom(ref room4, Direction.South);
            room2.LinkRoom(ref room5, Direction.South);
            room4.LinkRoom(ref room5, Direction.East);
        }

        
    }
}
