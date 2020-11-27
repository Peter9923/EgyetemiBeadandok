using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utazók
{
    class Travels
    {
        private string city;

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public Travels(string city_)
        {
            city = city_;
        }
    }
}
