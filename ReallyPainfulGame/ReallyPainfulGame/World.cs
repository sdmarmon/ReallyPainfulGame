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

            init();
            while (true) //sale, à changer
            {
                _player.duel();
                _player.move();
            }

            Console.ReadLine();
        }

        /* Player creation */
        public void playerCreation()
        {
            Room room1 = new Room("room 0.0", "Ceci est la room 0.0", null); // salle à revoir

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
        public void init()
        {

            
            Room room1 = new Room("room 0.0", "Ceci est la room 0.0", null);
            _player = new Squire("Moi",room1);
            Room room2 = new Room("room 1.0", "Ceci est la room 1.0", new Enemy(1));
            Room room3 = new Room("room 2.0", "Ceci est la room 2.0", null);
            Room room4 = new Room("room 0.1", "Ceci est la room 0.1", new Enemy());
            Room room5 = new Room("room 1.1", "Ceci est la room 1.1", null);

            room1.linkRoom(ref room2, Direction.East);
            room2.linkRoom(ref room3, Direction.East);
            room1.linkRoom(ref room4, Direction.South);
            room2.linkRoom(ref room5, Direction.South);
            room4.linkRoom(ref room5, Direction.East);
        }

        
    }
}
