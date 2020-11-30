using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ütközés
{
    class Puppets
    {
        private int _rightDirection;
        private int _downDirection;
        private string _movementDirection;
        //oszlop index lesz
        public int RightDirection
        {
            get { return _rightDirection; }
            set { _rightDirection = value; }
        }
        //sor index lesz..
        public int DownDirection
        {
            get { return _downDirection; }
            set { _downDirection = value; }
        }


        public string MoveMentDirection
        {
            get { return _movementDirection; }
            set { _movementDirection = value; }
        }

        public Puppets(int downDirection_, int rightDirection_, string movementDirection_)
        {
            _downDirection = downDirection_;
            _rightDirection = rightDirection_;
            _movementDirection = movementDirection_;
        }
    }

}
