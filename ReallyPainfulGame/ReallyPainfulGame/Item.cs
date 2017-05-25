using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyPainfulGame
{
    public abstract class Item
    {
        private string _name;
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

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

        public Item(string name,int price)
        {
            _name = name;
            _price = price;
        }

        public override string ToString()
        {
            return("-- " + _name + " --\n");
        }

        /*
          Name : Clone
          Description : Clone the current object 
          Parameters :
              out object this
        */
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
