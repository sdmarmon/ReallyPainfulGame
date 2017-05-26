using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Squire : Player
    {
        public Squire(string name, Room spawn) : base(name, 11, 11, 10, 11, spawn)
        {
            _spellManaCost = 10;
        }

        /*
         Name : Spell
         Description : Cast a spell on the enemy
         Parameters :
             in out Enemy enemy
       */
        public override void Spell(Enemy enemy)
        {
            if (Mana - _spellManaCost >= 0)
            {
                int damages = EffectiveAttack;
                Mana -= _spellManaCost;

                /* Extra damages from the spell */
                Random rnd = new Random();
                int chance = rnd.Next(100);
                if (chance <= (5 + EffectiveCritical))
                {
                    damages += EffectiveCritical;
                    Console.WriteLine("Vous lancez Gloire du Juste : vous infligez des dégats supplémentaires");
                }
                else
                {
                    Console.WriteLine("Echec du sort !");
                }
                enemy.Health -= GetDamages(damages, enemy.Defense);
                Console.WriteLine("Vous attaquez " + enemy.Name + " ! Votre attaque lui retire " + GetDamages(damages, enemy.Defense) + "PV.\n");
            }
            else
            {
                Console.WriteLine("Désolé, vous n'avez pas assez de Mana !");
                HitEnemy(enemy);
            }
        }

        public override string ToString()
        {
            return ("------------------\n" + Name + " : Ecuyer niveau " + Level + "\n" + base.ToString());
        }
    }
}
