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
                int damages = Attack;
                Mana -= _spellManaCost;
                if (Weapon != null)
                {
                    damages += Weapon.Attack;
                }

                /* Heal */
                Random rnd = new Random();
                int chance = rnd.Next(100);
                if (chance <= (10 + Critical / 2))
                {
                    int heal = GetDamages(damages, enemy.Defense);
                    if (Health + heal >= HealthMax)
                    {
                        Health = HealthMax;
                    }
                    else
                    {
                        Health += heal;
                    }
                    Console.WriteLine("Vous lancez Drain : vous vous soignez des dégats ingligés");
                    Console.WriteLine("Drain vous soigne de " + GetDamages(damages, enemy.Defense) + "PV.");
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
            return ("------------------\nPaladin niveau " + Level + "\n" + base.ToString());
        }
    }
}
