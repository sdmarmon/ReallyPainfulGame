using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Scroll : Consumable
    {
        public Scroll(string name): base(name)
        {

        }

        public override void use(Player player)
        {
            player.respawn();
        }
    }
}
