using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Villager
    {
        public Villager(){

        }

        public abstract void Talk(Player player);
    }
}
