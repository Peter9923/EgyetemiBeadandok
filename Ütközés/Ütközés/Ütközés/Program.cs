using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ütközés
{
    class Program
    {
        static void Main(string[] args)
        {
            PuppetsManager pm = new PuppetsManager();
            pm.Collision();
            Console.ReadLine();

        }
    }
}
