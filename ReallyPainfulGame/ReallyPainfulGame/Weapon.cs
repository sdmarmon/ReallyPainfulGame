using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Weapon : Equipment
    {
        private int _attack;

        public int Attack
        {
            get
            {
                return _attack;
            }

            set
            {
                _attack = value;
            }
        }

        public Weapon(string name, int attack) : base(name)
        {
            _attack = attack;
        }
    }
}
