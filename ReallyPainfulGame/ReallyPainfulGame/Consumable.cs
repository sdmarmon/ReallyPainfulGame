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

        public abstract void Use(Player player);

    }
}
