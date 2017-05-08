using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Ninja : Player
    {
        public Ninja(string name, Room spawn) : base(name, 10, 10, 10, 13,spawn)
        {
        }

        public override void spell(Enemy enemy)
        {
            
        }

    }
}
