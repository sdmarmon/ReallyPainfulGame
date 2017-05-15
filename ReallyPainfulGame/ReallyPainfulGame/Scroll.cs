using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Scroll : Consumable
    {
        public Scroll(): base("Parchemin", 10)
        {

        }

        public override void Use(Player player)
        {
            player.Respawn();
        }
    }
}
