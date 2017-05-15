using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Alchemist :Villager
    {
        private List<Consumable> _items;
 
        public Alchemist()
            : base()
        {
            _items = new List<Consumable>();
            _items.Add(Potion.SimplePotion());
            _items.Add(Potion.SuperPotion());
            _items.Add(Potion.HyperPotion());
            _items.Add(Potion.PotionX());
            _items.Add(new Scroll());
        }

        public override void Talk(Player player)
        {
            Console.Clear();
            Console.WriteLine("Bienvenue chez l'alchimiste");
            Console.WriteLine("Quels consommables voulez vous acheter ?");
            int nbitem = 1;
            foreach (Item item in _items)
            {
                Console.WriteLine(nbitem +": "+item.Name+" "+item.Price+"g");
                nbitem++;
            }
            Console.WriteLine(_items.Count+1 + ": Dire aurevoir à l'achimiste");

            Console.WriteLine("Vous avez "+player.Gold+" gold");
            int choice ;
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
                    //Doesn't leave
                    if (choice != _items.Count + 1){
                       if (_items.ElementAt(choice - 1).Price > player.Gold)
                        {
                            Console.WriteLine("Vous n'avez pas assez d'argent");
                        }
                        else if(choice < 1 || choice > _items.Count + 1)
                        {
                            Console.WriteLine("Veuillez rentrer un nombre valide");
                        }
                    }
                }

            } while (choice != _items.Count+1 && (choice < 1 || choice > _items.Count + 1 || _items.ElementAt(choice - 1).Price > player.Gold));

            Console.Clear();
            if (choice != _items.Count + 1)
            {
                Console.WriteLine("Vous avez acheté " + _items.ElementAt(choice - 1).Name);
                // Insert the chosen item in the inventory
                player.Inventory.Add((Consumable)_items.ElementAt(choice - 1).Clone());
            }
            Console.WriteLine("Aurevoir");
            
        }
    }
}
