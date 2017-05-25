using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Squire : Player
    {
        public Squire(string name, Room spawn) : base(name, 11, 11, 10, 11,spawn)
        {
            _spellManaCost = 100;
        }

        /*
         Name : Spell
         Description : Cast a spell on the enemy
         Parameters :
             in out Enemy enemy
       */
        public override void Spell(Enemy enemy)
        {
            int damages = Attack;
            Mana -= _spellManaCost;
            /* Extra damages from the spell */
            Random rnd = new Random();
            int chance = rnd.Next(100);
            if (chance <= (5 + Critical))
            {
                damages += Critical;
            }
            
            if (Weapon != null)
            {
                damages += Weapon.Attack;
            }

            enemy.Health -= enemy.Health -= GetDamages(damages, enemy.Defense);
        }
    }
}
