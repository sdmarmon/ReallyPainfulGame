using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Fighter : Player
    {
        public Fighter(string name, Room spawn) : base(name, 13, 10, 10, 10,spawn) 
        {
            _spellManaCost = 100;
        }

        public override void Spell(Enemy enemy)
        {
            int damages = Attack;
            Mana -= _spellManaCost;
            if (Weapon != null)
            {
                damages += Weapon.Attack;
            }

            /* Double damages */
            Random rnd = new Random();
            int chance = rnd.Next(100);
            if (chance <= (10 + Critical/2))
            {
                damages *= 2;
            }

            enemy.Health -= enemy.Health -= GetDamages(damages, enemy.Defense);
        }
    }
}
