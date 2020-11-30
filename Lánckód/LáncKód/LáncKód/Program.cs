using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LáncKód
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureManager pm = new PictureManager();
            pm.BlackPatch();
            Console.ReadLine();
        }
    }
}
