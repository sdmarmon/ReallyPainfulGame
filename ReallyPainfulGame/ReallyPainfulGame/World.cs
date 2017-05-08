using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    class World
    {
        private Player _player;
        private Room _currentRoom;
        private Room _spawn;

        public World()
        {
            //playerCreation();

            init();
            _player = new Squire("Moi");
            while (true)
            {
                duel(_currentRoom);
                Console.WriteLine(_currentRoom);
                move();
            }

            Console.ReadLine();
        }

        /* Player creation */
        public void playerCreation()
        {
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
                    _player = new Squire(name);
                    break;
                case "2":
                    _player = new Fighter(name);
                    break;
                case "3":
                    _player = new Paladin(name);
                    break;
                case "4":
                    _player = new Ninja(name);
                    break;
            }

        }

        public void move()
        {
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
                do
                {
                    choice = Console.ReadLine();
                } while (choice != "1" && choice != "2" && choice != "3" && choice != "4");

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

        /* Create the world */
        public void init()
        {
            Enemy monster = new Enemy();

            Room room1 = new Room("room 0.0", "Ceci est la room 0.0", null);
            _currentRoom = room1;
            _spawn = room1;
            Room room2 = new Room("room 1.0", "Ceci est la room 1.0", monster);
            Room room3 = new Room("room 2.0", "Ceci est la room 2.0", null);
            Room room4 = new Room("room 0.1", "Ceci est la room 0.1", monster);
            Room room5 = new Room("room 1.1", "Ceci est la room 1.1", null);

            room1.linkRoom(ref room2, Direction.East);
            room2.linkRoom(ref room3, Direction.East);
            room1.linkRoom(ref room4, Direction.South);
            room2.linkRoom(ref room5, Direction.South);
            room4.linkRoom(ref room5, Direction.East);
        }

        /* Fight against an enemy */
        public void duel(Room room)
        {
            if (room.Monster != null)
            {
                Enemy monster = room.Monster;
                if (_player.battle(monster))
                {
                    Console.WriteLine("Vous avez tué un " + monster.Name);
                    _player.levelUp(monster);
                    /* Loot enemy */
                    _player.Golds += monster.Golds;
                }
                else
                {
                    /* Respawn */
                    Console.WriteLine("Vous avez été tué par un " + monster.Name);
                    _currentRoom = _spawn;
                    _player.regeneration();
                }
            }
        }
    }
}
