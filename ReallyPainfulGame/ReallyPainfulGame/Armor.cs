using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Armor : Equipment
    {
        private int _defense;

        public int Defense
        {
            get
            {
                return _defense;
            }
        }

        public Armor(string name, int level, int defense, int price) : base(name,level,price)
        {
            _defense = defense;
        }

        /* Construct different types of Armors */
        public static Armor Cuirass()
        {
            return new Armor("Cuirasse", 1, 10, 10);
        }
        public static Armor IronCoat()
        {
            return new Armor("Cotte de fer", 2, 20,20);
        }
        public static Armor Caparison()
        {
            return new Armor("Caparaçon", 3, 30,30);
        }
        public static Armor GoldCoat()
        {
            return new Armor("Côte d’or", 4, 40,40);
        }
        public static Armor DiamondChestpiece()
        {
            return new Armor("Plastron diamant", 5, 50,50);
        }
        public static Armor Maximillien()
        {
            return new Armor("Maximillien", 6, 75,75);
        }
    }
}
