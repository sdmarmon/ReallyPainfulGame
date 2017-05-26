using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Equipment : Item
    {
        private int _level;

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }
        public Equipment(string name, int level, int price)
            : base(name, price)
        {
            _level = level;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
