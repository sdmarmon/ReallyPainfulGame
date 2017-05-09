using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Entity
    {
        private string _name;
        private int _healthMax;
        private int _health;
        private int _manaMax;
        private int _mana;
        private int _level;
        private int _golds;
        private int _attack;
        private int _defense;
        private int _critical;
        private int _speed;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public int HealthMax
        {
            get
            {
                return _healthMax;
            }

            set
            {
                _healthMax = value;
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }
        public int ManaMax
        {
            get
            {
                return _manaMax;
            }

            set
            {
                _manaMax = value;
            }
        }
        public int Mana
        {
            get
            {
                return _mana;
            }

            set
            {
                _mana = value;
            }
        }
        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }
        public int Golds
        {
            get
            {
                return _golds;
            }

            set
            {
                _golds = value;
            }
        }
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
        public int Defense
        {
            get
            {
                return _defense;
            }

            set
            {
                _defense = value;
            }
        }
        public int Critical
        {
            get
            {
                return _critical;
            }

            set
            {
                _critical = value;
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public Entity(string name, int level, int healthMax, int manaMax, int attack, int defense, int critical, int speed, int golds){
            Name = name;
            HealthMax = healthMax;     
            ManaMax = manaMax;
            Level = level;
            Golds = golds;
            Attack = attack;
            Defense = defense;
            Critical = critical;
            Speed = speed;
            Regeneration();
        }

        public void Regeneration()
        {
            Health = HealthMax;
            Mana = ManaMax;
        }

    }
}
