using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Consumable : Item
    {

        public Consumable(string name, int price) : base(name, price)
        {

        }

        /*
          Name : Use
          Description : The consumable is used by the player
          Parameters :
              in out Player player
       */
        public abstract void Use(Player player);

    }
}
