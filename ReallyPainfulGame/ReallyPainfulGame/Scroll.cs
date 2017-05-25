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

        /*
          Name : Use
          Description : The scroll teleports the player to his respawn location
          Parameters :
              in out Player player
       */
        public override void Use(Player player)
        {
            player.Respawn();
        }
    }
}
