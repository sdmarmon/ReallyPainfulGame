using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Item
    {
        private string _name;

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
        public Item(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return("-- " + _name + " --\n");
        }
    }
}
