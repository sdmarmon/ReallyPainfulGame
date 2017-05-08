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
        }

        public override void spell(Enemy enemy)
        {
            int damages = Attack;

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

            enemy.Health -= (int)(((2 * damages - enemy.Defense) / 2) * Math.Pow(damages, 1 / 3) / Math.Sqrt(enemy.Defense));
        }
    }
}
