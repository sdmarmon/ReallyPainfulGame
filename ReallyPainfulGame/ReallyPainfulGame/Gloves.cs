using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Gloves : Equipment
    {
        private int _critical;

        public int Critical
        {
            get
            {
                return _critical;
            }

            set
            {
                _critical = value;
            }
        }

        public Gloves(string name,int level, int critical) : base(name, level)
        {
            _critical = critical;
        }

        public static Gloves Gauntlet()
        {
            return new Gloves("Gantelet", 1, 10);
        }
        public static Gloves IvoryGloves()
        {
            return new Gloves("Gants ivoire", 2, 20);
        }
        public static Gloves Bracers()
        {
            return new Gloves("Bracers", 3, 30);
        }
        public static Gloves GenjiGloves()
        {
            return new Gloves("Gants genji", 4, 40);
        }
        public static Gloves FireMittens()
        {
            return new Gloves("Mitaines de feu", 5, 50);
        }
        public static Gloves MogGloves()
        {
            return new Gloves("Gants mog", 6, 75);
        }
    }
}
