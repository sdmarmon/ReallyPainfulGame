using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Boots : Equipment
    {
        private int _speed;

        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public Boots(string name, int level, int speed,int price) : base(name,level,price)
        {
            _speed = speed;
        }

        public static Boots StuddedBoots()
        {
            return new Boots("Bottes cloutées", 1, 10,10);
        }
        public static Boots FightingBoots()
        {
            return new Boots("Bottes de combat", 2, 20,20);
        }
        public static Boots FeatherBoots()
        {
            return new Boots("Bottes en plume", 3, 30,30);
        }
        public static Boots Caligula()
        {
            return new Boots("Caligula", 4, 40,40);
        }
        public static Boots NinjaTabi()
        {
            return new Boots("Tabi ninja", 5, 50,50);
        }
        public static Boots SevenLeagueBoots()
        {
            return new Boots("Bottes de 7 lieues", 6, 75,75);
        }

    }
}
