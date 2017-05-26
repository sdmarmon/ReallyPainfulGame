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

        /*
         Name : Spell
         Description : Cast a spell on the enemy
         Parameters :
             in out Enemy enemy
       */
        public override void Spell(Enemy enemy)
        {
            Mana -= _spellManaCost;
        }

        public override string ToString()
        {
            return ("------------------\nNinja niveau " + Level + "\n" + base.ToString());
        }
    }
}
