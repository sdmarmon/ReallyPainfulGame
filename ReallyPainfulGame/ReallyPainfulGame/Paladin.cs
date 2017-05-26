using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Paladin : Player
    {
        public Paladin(string name, Room spawn) : base(name, 10, 13, 10, 10, spawn)
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
            return ("------------------\nPaladin niveau " + Level + "\n" + base.ToString());
        }
    }
}
