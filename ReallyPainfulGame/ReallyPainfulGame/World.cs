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
            createPlayer();
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
            switch (int.Parse(choice))
            {
                case 1:
                    _player = new Squire(name);
                    break;
                case 2:
                    _player = new Fighter(name);
                    break;
                case 3:
                    _player = new Paladin(name);
                    break;
                case 4:
                    _player = new Ninja(name);
                    break;
            }

        }
    }
}
