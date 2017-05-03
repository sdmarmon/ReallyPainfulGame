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

        public Gloves(string name, int critical) : base(name)
        {
            _critical = critical;
        }
    }
}
