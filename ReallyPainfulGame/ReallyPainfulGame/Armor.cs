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

            set
            {
                _defense = value;
            }
        }

        public Armor(string name, int level, int defense) : base(name,level)
        {
            _defense = defense;
        }
    }
}
