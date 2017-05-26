using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Ninja : Player
    {
        public Ninja(string name, Room spawn) : base(name, 10, 10, 10, 13, spawn)
        {
            _spellManaCost = 15;
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
                int damages = Attack;
                Mana -= _spellManaCost;
                if (Weapon != null)
                {
                    damages += Weapon.Attack;
                }

                /* True damages */
                Random rnd = new Random();
                int chance = rnd.Next(100);
                if (chance <= (10 + Critical / 2))
                {
                    enemy.Health -= damages;
                    Console.WriteLine("Vous lancez Attaque Furtive");
                    Console.WriteLine("Vous attaquez " + enemy.Name + " ! Votre sort lui retire " + damages + "PV.\n");
                }
                else
                {
                    enemy.Health -= GetDamages(damages, enemy.Defense);
                    Console.WriteLine("Echec du sort !");
                    Console.WriteLine("Vous attaquez " + enemy.Name + " ! Votre attaque lui retire " + GetDamages(damages, enemy.Defense) + "PV.\n");
                }
            }
            else
            {
                Console.WriteLine("Désolé, vous n'avez pas assez de Mana !");
                HitEnemy(enemy);
            }
        }

    }
}
