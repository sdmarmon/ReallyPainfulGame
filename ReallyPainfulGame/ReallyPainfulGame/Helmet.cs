using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Helmet : Equipment
    {
        private int _health;

        public int Health
        {
            get
            {
                return _health;
            }
        }
        public Helmet(string name, int level, int health,int price) : base(name,level,price)
        {
            _health = health;
        }

        /* Construct different types of Helmets */
        public static Helmet FeatherMelon()
        {
            return new Helmet("Melon plume", 1, 10,10);
        }
        public static Helmet RomanHelmet()
        {
            return new Helmet("Casque romain", 2, 20,50);
        }
        public static Helmet IronHelmet()
        {
            return new Helmet("Casque de fer", 3, 30,150);
        }
        public static Helmet GenjiHelmet()
        {
            return new Helmet("Casque genji", 4, 40,400);
        }
        public static Helmet DiamondHelmet()
        {
            return new Helmet("Casque diamant", 5, 50,1000);
        }
        public static Helmet VangaadHelmet()
        {
            return new Helmet("Casque vangaa", 6, 75,1001);
        }

        public override string ToString()
        {
            return (base.ToString() + ", " + Health + "PV");
        }
    }
}
