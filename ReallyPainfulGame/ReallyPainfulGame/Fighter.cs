using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Fighter : Player
    {
        public Fighter(string name, Room spawn) : base(name, 13, 10, 10, 10, spawn)
        {
            _spellManaCost = 20;
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

                /* Double damages */
                Random rnd = new Random();
                int chance = rnd.Next(100);
                if (chance <= (10 + Critical / 2))
                {
                    damages *= 2;
                    Console.WriteLine("Vous lancez Coups Critiques : vos dégats sont doublés");
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
            return ("------------------\nSpadassin niveau " + Level + "\n" + base.ToString());
        }
    }
}
