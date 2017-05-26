using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Villager
    {
        public Villager(){

        }

        /*
         Name : Talk
         Description : The player and the villager speak together
         Parameters :
             in out Player player
       */
        public abstract void Talk(Player player);

        protected int ChooseItem(Player player, List<Item> _items)
        {
            int choice;
            do
            {
                //Choice is a number ?
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                //Is not a number
                if (choice == -1)
                {
                    Console.WriteLine("Veuillez rentrer un nombre");
                }
                else
                {
                    //Doesn't leave the store
                    if (choice != _items.Count + 1)
                    {
                        if (choice < 1 || choice > _items.Count + 1)
                        {
                            Console.WriteLine("Veuillez rentrer un nombre valide");
                        }
                        else if (_items.ElementAt(choice - 1).Price > player.Gold)
                        {
                            Console.WriteLine("Vous n'avez pas assez d'argent");
                        }
                    }
                }

            } while (choice != _items.Count + 1 && (choice < 1 || choice > _items.Count + 1 || _items.ElementAt(choice - 1).Price > player.Gold));

            return choice;
        }
    }
}
