using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Alchemist : Villager
    {
        private List<Item> _items;

        public Alchemist()
            : base()
        {
            _items = new List<Item>();
            //Items that the alchemist can sell
            _items.Add(Potion.SimplePotion());
            _items.Add(Potion.SuperPotion());
            _items.Add(Potion.HyperPotion());
            _items.Add(Potion.PotionX());
            _items.Add(new Scroll());
        }

        /*
          Name : Talk
          Description : The alchemist sells consummable to the player
          Parameters :
              in out Player player
       */
        public override void Talk(Player player)
        {
            bool stay = true;
            while(stay)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue chez l'alchimiste");
                Console.WriteLine("Quels consommables voulez vous acheter ?");
                int nbitem = 1;
                foreach (Item item in _items)
                {
                    Console.WriteLine(nbitem + ": " + item.Name + " " + item.Price + "g");
                    nbitem++;
                }
                Console.WriteLine(_items.Count + 1 + ": Dire au revoir à l'alchimiste");

                Console.WriteLine("Vous avez " + player.Gold + " gold");

                int itemChosen = ChooseItem(player, _items);

                Console.Clear();
                //Doesn't leave the store
                if (itemChosen != _items.Count + 1)
                {
                    Console.WriteLine("Vous avez acheté " + _items.ElementAt(itemChosen - 1).Name);
                    // Buy the chosen item
                    player.Gold -= _items.ElementAt(itemChosen - 1).Price;
                    // Insert the chosen item in the inventory
                    player.Inventory.Add((Consumable)_items.ElementAt(itemChosen - 1).Clone());

                    Console.Clear();
                    Console.WriteLine("Voulez vous continuer à acheter ?");
                    Console.WriteLine("1: Oui");
                    Console.WriteLine("2: Non");
                    string choice;
                    do
                    {
                        choice = Console.ReadLine();
                    } while (choice != "1" && choice != "2");

                    if (choice=="2")
                    {
                        stay = false;
                    }
                }
                else
                {
                    stay = false;
                }
            }
            Console.WriteLine("Au revoir");

        }
    }
}
