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

        public Boots(string name, int speed) : base(name)
        {
            _speed = speed;
        }
    }
}
