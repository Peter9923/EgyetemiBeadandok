using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyConsoleGame
{
    class Map
    {
        private int _owner;
        private int _price;

        public int Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Map(int owner_, int price_)
        {
            _owner = owner_;
            _price = price_;
        }
    }
}
