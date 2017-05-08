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
        public Equipment(string name, int level) : base(name)
        {
            _level = level;
        }

        public override string ToString()
        {
            string text = base.ToString();
            text += "";
            return text;
        }

    }
}
