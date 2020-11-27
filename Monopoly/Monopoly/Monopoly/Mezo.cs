using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Mezo
    {
        private int _kiVanRajta;
        private int _Erteke;

        public int RajtaVan
        {
            get { return _kiVanRajta; }
            set { _kiVanRajta = value; }
        }
        public int Erteke
        {
            get { return _Erteke; }
            set { _Erteke = value; }
        }
        public Mezo(int rajtaVan_, int erteke_)
        {
            _kiVanRajta = rajtaVan_;
            _Erteke = erteke_;
        }
    }
}
