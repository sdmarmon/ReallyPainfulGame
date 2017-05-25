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
                        if (_items.ElementAt(choice - 1).Price > player.Gold)
                        {
                            Console.WriteLine("Vous n'avez pas assez d'argent");
                        }
                        else if (choice < 1 || choice > _items.Count + 1)
                        {
                            Console.WriteLine("Veuillez rentrer un nombre valide");
                        }
                    }
                }

            } while (choice != _items.Count + 1 && (choice < 1 || choice > _items.Count + 1 || _items.ElementAt(choice - 1).Price > player.Gold));

            return choice;
        }
    }
}
