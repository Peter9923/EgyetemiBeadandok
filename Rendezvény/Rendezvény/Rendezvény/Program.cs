using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendezvény
{
    class Program
    {
        static void Main(string[] args)
        {

            EvenetManager manager = new EvenetManager();
            manager.Selection();
            Console.ReadLine();

        }
    }
}
