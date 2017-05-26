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
            Init();
            while (!_player.Leave)
            {
                _player.Duel();
                if (!_player.Leave)
                {
                    _player.Move();
                }
            }

            Console.ReadLine();
        }

        /*
          Name : PlayerCreation
          Description : Create the player
       */
        public void PlayerCreation(Room room)
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
                    _player = new Squire(name, room);
                    break;
                case "2":
                    _player = new Fighter(name, room);
                    break;
                case "3":
                    _player = new Paladin(name, room);
                    break;
                case "4":
                    _player = new Ninja(name, room);
                    break;
            }

        }

        /*
          Name : Init
          Description : Create the world
       */
        public void Init()
        {
            Alchemist alchemist = new Alchemist();
            // Cyril
            BlackSmith blacksmith1 = new BlackSmith(1);
            Room cyril1 = new Room("Cyril 0.0", null, blacksmith1);
            Room cyril2 = new Room("Cyril 1.0", null, null);
            Room cyril3 = new Room("Cyril 0.1", null, null);
            PlayerCreation(cyril3);
            Room cyril4 = new Room("Cyril 1.1", null, alchemist);

            cyril1.LinkRoom(ref cyril2, Direction.East);
            cyril1.LinkRoom(ref cyril3, Direction.South);
            cyril2.LinkRoom(ref cyril4, Direction.South);
            cyril3.LinkRoom(ref cyril4, Direction.East);

            // Gobelin's Dungeon
            Room goblin1 = new Room("Donjon Gobelin 0.0", Enemy.Goblin(), null);
            Room goblin2 = new Room("Donjon Gobelin 1.0", Enemy.Goblin(), null);
            Room goblin3 = new Room("Donjon Gobelin 0.1", null, null);
            Room goblin4 = new Room("Donjon Gobelin 1.1", Enemy.BossGoblin(), null);

            goblin1.LinkRoom(ref cyril2, Direction.West);

            goblin1.LinkRoom(ref goblin3, Direction.South);
            goblin2.LinkRoom(ref goblin4, Direction.South);
            goblin3.LinkRoom(ref goblin4, Direction.East);
            goblin1.LinkRoom(ref goblin2, Direction.East);

            // Sprohm
            BlackSmith blacksmith2 = new BlackSmith(2);
            Room sprohm1 = new Room("Sprohm 0.0", null, blacksmith2);
            Room sprohm2 = new Room("Sprohm 1.0", null, null);
            Room sprohm3 = new Room("Sprohm 0.1", null, null);
            Room sprohm4 = new Room("Sprohm 1.1", null, alchemist);

            sprohm1.LinkRoom(ref sprohm2, Direction.East);
            sprohm1.LinkRoom(ref sprohm3, Direction.South);
            sprohm2.LinkRoom(ref sprohm4, Direction.South);
            sprohm3.LinkRoom(ref sprohm4, Direction.East);

            sprohm3.LinkRoom(ref goblin4, Direction.West);

            // Troll's Dungeon
            Room troll1 = new Room("Donjon Troll 0.0", Enemy.Troll(), null);
            Room troll2 = new Room("Donjon Troll 1.0", Enemy.Troll(), null);
            Room troll3 = new Room("Donjon Troll 0.1", null, null);
            Room troll4 = new Room("Donjon Troll 1.1", Enemy.Troll(), null);
            Room troll5 = new Room("Donjon Troll 2.0", Enemy.BossTroll(), null);

            troll1.LinkRoom(ref sprohm2, Direction.West);

            troll1.LinkRoom(ref troll3, Direction.South);
            troll2.LinkRoom(ref troll4, Direction.South);
            troll3.LinkRoom(ref troll4, Direction.East);
            troll1.LinkRoom(ref troll2, Direction.East);
            troll2.LinkRoom(ref troll5, Direction.East);

            // Cadoan
            BlackSmith blacksmith3 = new BlackSmith(3);
            Room cadoan1 = new Room("Cadoan 0.0", null, blacksmith3);
            Room cadoan2 = new Room("Cadoan 1.0", null, null);
            Room cadoan3 = new Room("Cadoan 0.1", null, null);
            Room cadoan4 = new Room("Cadoan 1.1", null, alchemist);

            cadoan1.LinkRoom(ref cadoan2, Direction.East);
            cadoan1.LinkRoom(ref cadoan3, Direction.South);
            cadoan2.LinkRoom(ref cadoan4, Direction.South);
            cadoan3.LinkRoom(ref cadoan4, Direction.East);

            cadoan3.LinkRoom(ref troll5, Direction.West);

            // Centaur's Dungeon
            Room centaur1 = new Room("Donjon Centaure 0.0", Enemy.Centaur(), null);
            Room centaur2 = new Room("Donjon Centaure 1.0", null, null);
            Room centaur3 = new Room("Donjon Centaure 0.1", Enemy.Centaur(), null);
            Room centaur4 = new Room("Donjon Centaure 1.1", Enemy.Centaur(), null);
            Room centaur5 = new Room("Donjon Centaure 2.0", null, null);
            Room centaur6 = new Room("Donjon Centaure 2.1", Enemy.BossCentaur(), null);

            centaur1.LinkRoom(ref cadoan2, Direction.West);

            centaur1.LinkRoom(ref centaur3, Direction.South);
            centaur2.LinkRoom(ref centaur4, Direction.South);
            centaur3.LinkRoom(ref centaur4, Direction.East);
            centaur1.LinkRoom(ref centaur2, Direction.East);
            centaur2.LinkRoom(ref centaur5, Direction.East);
            centaur6.LinkRoom(ref centaur4, Direction.West);
            centaur6.LinkRoom(ref centaur5, Direction.North);

            // Baguba
            BlackSmith blacksmith4 = new BlackSmith(4);
            Room baguba1 = new Room("Baguba 0.0", null, blacksmith4);
            Room baguba2 = new Room("Baguba 1.0", null, null);
            Room baguba3 = new Room("Baguba 0.1", null, null);
            Room baguba4 = new Room("Baguba 1.1", null, alchemist);

            baguba3.LinkRoom(ref centaur6, Direction.West);

            baguba1.LinkRoom(ref baguba2, Direction.East);
            baguba1.LinkRoom(ref baguba3, Direction.South);
            baguba2.LinkRoom(ref baguba4, Direction.South);
            baguba3.LinkRoom(ref baguba4, Direction.East);

            // Orc's Dungeon
            Room orc1 = new Room("Donjon Orc 0.0", null, null);
            Room orc2 = new Room("Donjon Orc 1.0", Enemy.Orc(), null);
            Room orc3 = new Room("Donjon Orc 0.1", Enemy.Orc(), null);
            Room orc4 = new Room("Donjon Orc 1.1", Enemy.Orc(), null);
            Room orc5 = new Room("Donjon Orc 2.0", null, null);
            Room orc6 = new Room("Donjon Orc 2.1", Enemy.Orc(), null);
            Room orc7 = new Room("Donjon Orc 2.2", Enemy.BossOrc(), null);

            orc1.LinkRoom(ref baguba2, Direction.West);

            orc1.LinkRoom(ref orc3, Direction.South);
            orc2.LinkRoom(ref orc4, Direction.South);
            orc3.LinkRoom(ref orc4, Direction.East);
            orc1.LinkRoom(ref orc2, Direction.East);
            orc2.LinkRoom(ref orc5, Direction.East);
            orc6.LinkRoom(ref orc4, Direction.West);
            orc6.LinkRoom(ref orc5, Direction.North);
            orc7.LinkRoom(ref orc6, Direction.North);

            // Muscadet
            BlackSmith blacksmith5 = new BlackSmith(5);
            Room muscadet1 = new Room("Muscadet 0.0", null, blacksmith4);
            Room muscadet2 = new Room("Muscadet 1.0", null, null);
            Room muscadet3 = new Room("Muscadet 0.1", null, null);
            Room muscadet4 = new Room("Muscadet 1.1", null, alchemist);

            muscadet3.LinkRoom(ref orc7, Direction.West);

            muscadet1.LinkRoom(ref muscadet2, Direction.East);
            muscadet1.LinkRoom(ref muscadet3, Direction.South);
            muscadet2.LinkRoom(ref muscadet4, Direction.South);
            muscadet3.LinkRoom(ref muscadet4, Direction.East);

            // Dragon's Dungeon
            Room dragon1 = new Room("Donjon Dragon 0.0", Enemy.Dragon(), null);
            Room dragon2 = new Room("Donjon Dragon 1.0", Enemy.Dragon(), null);
            Room dragon3 = new Room("Donjon Dragon 0.1", Enemy.Dragon(), null);
            Room dragon4 = new Room("Donjon Dragon 1.1", Enemy.Dragon(), null);
            Room dragon5 = new Room("Donjon Dragon 2.0", Enemy.Dragon(), null);
            Room dragon6 = new Room("Donjon Dragon 2.1", Enemy.Dragon(), null);
            Room dragon7 = new Room("Donjon Dragon 2.2", Enemy.BossDragon(), null);
            Room dragon8 = new Room("Donjon Dragon 1.2", Enemy.Dragon(), null);

            dragon1.LinkRoom(ref muscadet2, Direction.West);

            dragon1.LinkRoom(ref dragon3, Direction.South);
            dragon2.LinkRoom(ref dragon4, Direction.South);
            dragon3.LinkRoom(ref dragon4, Direction.East);
            dragon1.LinkRoom(ref dragon2, Direction.East);
            dragon2.LinkRoom(ref dragon5, Direction.East);
            dragon6.LinkRoom(ref dragon4, Direction.West);
            dragon6.LinkRoom(ref dragon5, Direction.North);
            dragon7.LinkRoom(ref dragon6, Direction.North);
            dragon8.LinkRoom(ref dragon4, Direction.North);
            dragon8.LinkRoom(ref dragon7, Direction.East);

            dragon7.LinkRoom(ref cyril3, Direction.East);
        }

    }
}
