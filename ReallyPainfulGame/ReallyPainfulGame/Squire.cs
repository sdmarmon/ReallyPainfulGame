using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Squire : Player
    {
        public Squire(string name): base(name, 11, 11, 10, 11)
        {

        }

        public override void spell(Enemy enemy)
        {
            int damages = Attack;

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

            enemy.Health -= (int)(((2 * damages - enemy.Defense) / 2) * Math.Pow(damages, 1 / 3) / Math.Sqrt(enemy.Defense));
        }
    }
}
