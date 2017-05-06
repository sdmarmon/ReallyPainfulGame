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
        private List<Room> _rooms;

        public World()
        {
            //createPlayer();

            /* Test combat contre un ennemi */
            //_player = new Squire("Moi");
            Enemy monster = new Enemy();
            //if (_player.battle(monster))
            //{
            //    Console.WriteLine("Vous avez tué un " + monster.Name);
            //    _player.levelUp(monster);
            //    /* Loot enemy */
            //    _player.Golds += monster.Golds;
                

            //}
            //else
            //{
            //    /* Respawn */
            //    Console.WriteLine("Vous avez été tué par un " + monster.Name);
            //}

            Room room1 = new Room("room1", "room1", monster);
            Room room2 = new Room("room2", "room2", monster);
            room1.linkRoom(ref room2, Direction.North);
            Console.WriteLine(room2.Rooms[Direction.South]);

            Console.ReadLine();
        }

        public void createPlayer()
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

            } while (choice!= "1"&& choice != "2" && choice != "3" && choice != "4");
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
    }
}
