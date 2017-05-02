using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    class Player : Entity
    {
        protected const int _xpMax = 100;
        protected int _experience;

        public Player(string name, int attack, int defense, int critical, int speed) : base(name, 1, 100, 100, attack, defense, critical, speed, 0)
        {
            _experience = 0;
        }


        public void battle(ref Enemy enemy)
        {
            
        }

       
    }

}
