using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class BlackSmith : Villager
    {
        private int _level;
        private List<Item> _items;

        public BlackSmith(int level) : base()
        {
            _level = level;
            _items = new List<Item>();

            // Set the equipments that the Blacksmith can sell according to his level
            switch (_level)
            {
                default:
                    _items.Add(Armor.Cuirass());
                    _items.Add(Boots.StuddedBoots());
                    _items.Add(Gloves.Gauntlet());
                    _items.Add(Helmet.FeatherMelon());
                    _items.Add(Weapon.ShortSword());
                    break;
                case 2:
                    _items.Add(Armor.IronCoat());
                    _items.Add(Boots.FightingBoots());
                    _items.Add(Gloves.IvoryGloves());
                    _items.Add(Helmet.RomanHelmet());
                    _items.Add(Weapon.Cutlass());
                    break;
                case 3:
                    _items.Add(Armor.Caparison());
                    _items.Add(Boots.FeatherBoots());
                    _items.Add(Gloves.Bracers());
                    _items.Add(Helmet.IronHelmet());
                    _items.Add(Weapon.Ragnarok());
                    break;
                case 4:
                    _items.Add(Armor.GoldCoat());
                    _items.Add(Boots.Caligula());
                    _items.Add(Gloves.GenjiGloves());
                    _items.Add(Helmet.GenjiHelmet());
                    _items.Add(Weapon.Claymore());
                    break;
                case 5:
                    _items.Add(Armor.DiamondChestpiece());
                    _items.Add(Boots.NinjaTabi());
                    _items.Add(Gloves.FireMittens());
                    _items.Add(Helmet.DiamondHelmet());
                    _items.Add(Weapon.Masamune());
                    break;
            }
        }

        /*
          Name : Talk
          Description : The blacksmith sells equipments to the player
          Parameters :
              in out Player player
       */
        public override void Talk(Player player)
        {
            bool stay = true;
            while (stay)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue chez le forgeron");
                Console.WriteLine("Quels équipements voulez vous acheter ?");
                int nbitem = 1;
                foreach (Item item in _items)
                {
                    Console.WriteLine(nbitem + ": " + item.Name + " " + item.Price + "g");
                    nbitem++;
                }
                Console.WriteLine(_items.Count + 1 + ": Dire aurevoir au forgeron");

                Console.WriteLine("Vous avez " + player.Gold + " gold");

                int itemChosen = ChooseItem(player, _items);

                Console.Clear();
                //Doesn't leave the store
                if (itemChosen != _items.Count + 1)
                {
                    Console.WriteLine("Vous avez acheté " + _items.ElementAt(itemChosen - 1).Name);
                    // Buy the chosen item
                    player.Gold -= _items.ElementAt(itemChosen - 1).Price;
                    // Sell the current equipment and equip the chosen item
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

                    if (choice == "2")
                    {
                        stay = false;
                    }
                }
                else
                {
                    stay = false;
                }
            }
            Console.WriteLine("Aurevoir");
        }
    }
}
