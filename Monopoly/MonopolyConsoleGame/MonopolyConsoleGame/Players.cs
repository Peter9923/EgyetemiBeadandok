using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyConsoleGame
{
    class Players
    {
        private string _name;
        private int _money;
        private int _position;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Players(string name_, int money_, int position_)
        {
            _name = name_;
            _money = money_;
            _position = position_;
        }
    }
}
