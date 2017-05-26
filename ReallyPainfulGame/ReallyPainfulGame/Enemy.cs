using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Enemy : Entity
    {
        private static Random _rnd = new Random();
        private Equipment _loot;
        public Equipment Loot
        {
            get
            {
                return _loot;
            }

            set
            {
                _loot = value;
            }
        }

        public Enemy(string name, int level, int healthMax, int manaMax, int attack, int defense, int critical, int speed, int golds, Equipment loot) : 
            base(name, level, healthMax, manaMax, attack, defense, critical, speed, golds)
        {
            Loot = loot;
        }

        /*
       Name : HitPlayer
       Description : An enemy deals damages to the player
       Parameters :
           in out Player player
        */
        public void HitPlayer(Player player)
        {
            player.Health -= GetDamages(Attack, player.EffectiveDefense);
            Console.WriteLine(this.Name + " vous attaque ! Il vous retire " + GetDamages(Attack, player.EffectiveDefense) + "PV.\n");
        }

        public static Enemy Gobelin()
        {
            Equipment loot = null;
            int randomNumber = _rnd.Next(1,6);
            switch (randomNumber)
            {
                case 1:
                    loot = Weapon.ShortSword();
                    break;
                case 2:
                    loot = Armor.Cuirass();
                    break;
                case 3:
                    loot = Boots.StuddedBoots();
                    break;
                case 4:
                    loot = Gloves.Gauntlet();
                    break;
                case 5:
                    loot = Helmet.FeatherMelon();
                    break;
            }

            return new Enemy("Gobelin", 1, 10, 100, 10, 5, 2, 10, 10, loot);
        }
        public static Enemy Troll()
        {
            Equipment loot = null;
            int randomNumber = _rnd.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    loot = Weapon.Cutlass();
                    break;
                case 2:
                    loot = Armor.IronCoat();
                    break;
                case 3:
                    loot = Boots.FightingBoots();
                    break;
                case 4:
                    loot = Gloves.IvoryGloves();
                    break;
                case 5:
                    loot = Helmet.RomanHelmet();
                    break;
            }
            return new Enemy("Troll", 1, 10, 100, 10, 5, 2, 10, 10, loot);
        }
        public static Enemy Centaur()
        {
            Equipment loot = null;
            int randomNumber = _rnd.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    loot = Weapon.Ragnarok();
                    break;
                case 2:
                    loot = Armor.Caparison();
                    break;
                case 3:
                    loot = Boots.FeatherBoots();
                    break;
                case 4:
                    loot = Gloves.Bracers();
                    break;
                case 5:
                    loot = Helmet.IronHelmet();
                    break;
            }
            return new Enemy("Centaure", 1, 10, 100, 10, 5, 2, 10, 10, loot);
        }
        public static Enemy Orc()
        {
            Equipment loot = null;
            int randomNumber = _rnd.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    loot = Weapon.Claymore();
                    break;
                case 2:
                    loot = Armor.GoldCoat();
                    break;
                case 3:
                    loot = Boots.Caligula();
                    break;
                case 4:
                    loot = Gloves.GenjiGloves();
                    break;
                case 5:
                    loot = Helmet.GenjiHelmet();
                    break;
            }
            return new Enemy("Orc", 1, 10, 100, 10, 5, 2, 10, 10, loot);
        }
        public static Enemy Dragon()
        {
            Equipment loot = null;
            int randomNumber = _rnd.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    loot = Weapon.Masamune();
                    break;
                case 2:
                    loot = Armor.DiamondChestpiece();
                    break;
                case 3:
                    loot = Boots.NinjaTabi();
                    break;
                case 4:
                    loot = Gloves.FireMittens();
                    break;
                case 5:
                    loot = Helmet.DiamondHelmet();
                    break;
            }
            return new Enemy("Dragon", 1, 10, 100, 10, 5, 2, 10, 10, loot);
        }
        public static Enemy BossGobelin()
        {
            return new Enemy("Boss Gobelin", 1, 10, 100, 10, 5, 2, 10, 10, Armor.Maximillien());
        }
        public static Enemy BossTroll()
        {
            return new Enemy("Boss Troll", 1, 10, 100, 10, 5, 2, 10, 10, Boots.SevenLeagueBoots());
        }
        public static Enemy BossCentaur()
        {
            return new Enemy("Boss Centaur", 1, 10, 100, 10, 5, 2, 10, 10, Gloves.MogGloves());
        }
        public static Enemy BossOrc()
        {
            return new Enemy("Boss Orc", 1, 10, 100, 10, 5, 2, 10, 10, Helmet.VangaadHelmet());
        }
        public static Enemy BossDragon()
        {
            return new Enemy("Boss Dragon", 1, 10, 100, 10, 5, 2, 10, 10, Weapon.Excalibur());
        }
    }
}
