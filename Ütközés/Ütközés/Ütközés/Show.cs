using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ütközés
{
    static class Show
    {
        public static void DrawMap(string[,] _map)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] != " ")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(_map[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(_map[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DrawPuppets(Puppets[] _puppets)
        {
            for (int i = 0; i < _puppets.Length; i++)
            {
                Console.SetCursorPosition(_puppets[i].RightDirection, _puppets[i].DownDirection);
                Console.Write("P");
            }
        }

        public static void NewPosition(Puppets[] _puppets)
        {
            for (int i = 0; i < _puppets.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Bábu új poziciója: ({_puppets[i].DownDirection};{_puppets[i].RightDirection})");
            }
        }

        public static void Next()
        {
            Console.WriteLine("Nyomj entert a következő mozgatáshoz...");
            Console.ReadLine();
        }
    }
}
