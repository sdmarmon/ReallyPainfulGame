using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    abstract class Entity
    {
        protected string _name;
        protected int _healthMax;
        protected int _health;
        protected int _manaMax;
        protected int _mana;
        protected int _level;
        protected int _golds;
        protected int _attack;
        protected int _defense;
        protected int _critical;
        protected int _speed;

        public Entity(string name, int level, int healthMax, int manaMax, int attack, int defense, int critical, int speed, int golds){
            _name = name;
            _healthMax = healthMax;
            _health = healthMax;
            _manaMax = manaMax;
            _mana = manaMax;
            _level = level;
            _golds = golds;
            _attack = attack;
            _defense = defense;
            _critical = critical;
            _speed = speed;
        }

    }
}
