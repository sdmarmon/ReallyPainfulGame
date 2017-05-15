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
            Console.WriteLine("Quels consommables voulez vous acheter : ");
            int nbitem = 1;
            foreach (Item item in _items)
            {
                Console.WriteLine(nbitem +": "+item.Name+" "+item.Price+"g");
                nbitem++;
            }
            
            int choice;
            do
            {   
                //Teste si c'est un nombre
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = 0;
                }
            } while (choice < 1 || choice > _items.Count);

            // Insert the chosen item in the inventory
            player.Inventory.Add((Consumable)_items.ElementAt(choice - 1).Clone());
            
            
        }
    }
}
