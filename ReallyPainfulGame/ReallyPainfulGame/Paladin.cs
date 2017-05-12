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

        public override void Spell(Enemy enemy)
        {
            Mana -= _spellManaCost;
        }
    }
}
