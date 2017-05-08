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
    }
}
