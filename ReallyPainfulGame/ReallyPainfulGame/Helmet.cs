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

            set
            {
                _health = value;
            }
        }
        public Helmet(string name, int level, int health) : base(name,level)
        {
            _health = health;
        }
    }
}
