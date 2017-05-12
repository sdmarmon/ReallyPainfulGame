using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public class Weapon : Equipment
    {
        private int _attack;

        public int Attack
        {
            get
            {
                return _attack;
            }

            set
            {
                _attack = value;
            }
        }
        public Weapon(string name, int level, int attack) : base(name,level)
        {
            _attack = attack;
        }

        public static Weapon ShortSword()
        {
            return new Weapon("Epée courte", 1, 10);
        }

        public static Weapon Cutlass()
        {
            return new Weapon("Sabre vicié", 2, 20);
        }

        public static Weapon Ragnarok()
        {
            return new Weapon("Ragnarok", 3, 30);
        }

        public static Weapon Claymore()
        {
            return new Weapon("Claymore", 4, 40);
        }

        public static Weapon Masamune()
        {
            return new Weapon("Masamune", 5, 50);
        }

        public static Weapon Excalibur()
        {
            return new Weapon("Excalibur", 6, 75);
        }
    }
}
