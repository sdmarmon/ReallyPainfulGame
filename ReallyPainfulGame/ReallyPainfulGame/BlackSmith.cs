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
                    Console.WriteLine(nbitem + ": " + item);
                    nbitem++;
                }
                Console.WriteLine(_items.Count + 1 + ": Dire au revoir au forgeron");

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
                    Equipment boughtItem = (Equipment)(_items.ElementAt(itemChosen - 1));

                    switch (boughtItem.GetType().Name)
                    {
                        case "Armor":
                            if (player.Armor != null)
                            {
                                if (boughtItem.Level > player.Armor.Level)
                                {
                                    player.Armor = boughtItem as Armor;
                                    player.EffectiveDefense = player.Defense + player.Armor.Defense;
                                }
                            }
                            else
                            {
                                player.Armor = boughtItem as Armor;
                                player.EffectiveDefense = player.Defense + player.Armor.Defense;
                            }
                            break;
                        case "Boots":
                            if (player.Boots != null)
                            {
                                if (boughtItem.Level > player.Boots.Level)
                                {
                                    player.Boots = boughtItem as Boots;
                                    player.EffectiveSpeed = player.Speed + player.Boots.Speed;
                                }
                            }
                            else
                            {
                                player.Boots = boughtItem as Boots;
                                player.EffectiveSpeed = player.Speed + player.Boots.Speed;
                            }
                            break;
                        case "Gloves":
                            if (player.Gloves != null)
                            {
                                if (boughtItem.Level > player.Gloves.Level)
                                {
                                    player.Gloves = boughtItem as Gloves;
                                    player.EffectiveCritical = player.EffectiveCritical + player.Gloves.Critical;
                                }
                            }
                            else
                            {
                                player.Gloves = boughtItem as Gloves;
                                player.EffectiveCritical = player.EffectiveCritical + player.Gloves.Critical;
                            }
                            break;
                        case "Helmet":
                            if (player.Helmet != null)
                            {
                                if (boughtItem.Level > player.Helmet.Level)
                                {
                                    player.Helmet = boughtItem as Helmet;
                                    player.EffectiveHealth = player.HealthMax + player.Helmet.Health;
                                }
                            }
                            else
                            {
                                player.Helmet = boughtItem as Helmet;
                                player.EffectiveHealth = player.HealthMax + player.Helmet.Health;
                            }
                            break;
                        case "Weapon":
                            if (player.Weapon != null)
                            {
                                if (boughtItem.Level > player.Weapon.Level)
                                {
                                    player.Weapon = boughtItem as Weapon;
                                    player.EffectiveAttack = player.EffectiveAttack + player.Weapon.Attack;
                                }
                            }
                            else
                            {
                                player.Weapon = boughtItem as Weapon;
                                player.EffectiveAttack = player.EffectiveAttack + player.Weapon.Attack;
                            }

                            break;
                    }
                    // Equips the purchased item

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
            Console.WriteLine("Au revoir");
        }
    }
}
