using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LáncKód
{
    class Picture
    {
        private int _sor;
        private int _oszlop;

        public int Sor
        {
            get { return _sor; }
            set { _sor = value; }
        }
        public int Oszlop
        {
            get { return _oszlop; }
            set { _oszlop = value; }
        }

        public Picture(int sor_, int oszlop_)
        {
            _sor = sor_;
            _oszlop = oszlop_;
        }

    }
}
