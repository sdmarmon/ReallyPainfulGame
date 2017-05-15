using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class BlackSmith : Villager
    {
        private int _level;

        public BlackSmith(int level) : base(){
            _level = level;
        }

        public override void Talk(Player player)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue chez le forgeron");
            Console.WriteLine("Quels équipements voulez vous acheter : ");
            Console.WriteLine("1: Epée courte");
            Console.WriteLine("2: Armure légère ");
            Console.WriteLine("3: Bottes");

            string[] choices = new string[] { "1", "2", "3"};
            string choice = "";
            do
            {
                choice = Console.ReadLine();
            } while (!choices.Contains(choice));

            switch (choice)
            {
                case "1":
                    // Si le joueur a assez d'or pour acheter l'equipement
                    break;
                case "2":

                    break;
                case "3":

                    break;
            }
        }
    }
}
