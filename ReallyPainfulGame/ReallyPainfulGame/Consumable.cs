using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Consumable : Item
    {

        public Consumable(string name) : base(name)
        {

        }

        public abstract void use(Player player);
    }
}
