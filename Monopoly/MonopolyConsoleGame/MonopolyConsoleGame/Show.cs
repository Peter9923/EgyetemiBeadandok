using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyConsoleGame
{
    static class Show
    {

        public static void DrawMap(Map[] _map, Players[] _players)
        {
            DrawPlayers(_players);
            Console.SetCursorPosition(8, 7);

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {

                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| "+ "STR" + " |");
                }
                else if (_map[i].Owner == -1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
            }
            Console.SetCursorPosition(8,11);
            for (int i = 10; i > 6; i--)
            {
                if (_map[i].Owner == -1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
            }
            Console.SetCursorPosition(8, 8);
            for (int i = 13; i > 10; i--)
            {

                if (i == 12)
                {
                    Console.SetCursorPosition(8, 9);
                }
                if (i == 11)
                {
                    Console.SetCursorPosition(8, 10);
                }


                if (_map[i].Owner == -1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
            }
            Console.SetCursorPosition(29, 8);
            for (int i = 4; i < 7; i++)
            {

                if (i == 5)
                {
                    Console.SetCursorPosition(29, 9);
                }
                if (i == 6)
                {
                    Console.SetCursorPosition(29, 10);
                }

                if (_map[i].Owner == -1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else if (_map[i].Owner == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("| " + _map[i].Price + " |");
                }

            }
            Console.ResetColor();

            DrawMapNumbers();

            Console.SetCursorPosition(0,14);

        }

        private static void DrawMapNumbers()
        {
            
            int left = 11;
            int top = 6;
            
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left += 7;
            }
            left = 11;
            top = 12;
            for (int i = 10; i > 6; i--)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left += 7;
            }
            left = 5;
            top = 8;
            for (int i = 13; i > 10; i--)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left = 5;
                top++;
            }
            left = 36;
            top = 8;
            for (int i = 4; i < 7; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left = 36;
                top++;
            }


        }
        public static void DrawPlayers(Players[] _players)
        {
            Console.Clear();
            for (int i = 0; i < _players.Length; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{_players[i].Name} ; position: {_players[i].Position} ; money: {_players[i].Money}");
                    Console.ResetColor();
                }
                else if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"{_players[i].Name} ; position: {_players[i].Position} ; money: {_players[i].Money}");
                    Console.ResetColor();
                }
                else if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"{_players[i].Name} ; position: {_players[i].Position} ; money: {_players[i].Money}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"{_players[i].Name} ; position: {_players[i].Position} ; money: {_players[i].Money}");
                    Console.ResetColor();
                }
            }


        }

      

        public static void YouBoughtOneBuild(int index, Players[] _players)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{_players[index].Name} bought {_players[index].Position} this..");
            Console.ResetColor();
        }

        public static void YouPayAnotherPlayer(int index, Players[] _players, Map[] _map)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{_players[index].Name} paid {_players[_map[_players[index].Position].Owner].Name} ; {_map[_players[index].Position].Price}");
            Console.ResetColor();
        }

        public static int Throwing(int index, Players[] _players)
        {
            Console.Write($"{_players[index].Name} plese write your threw value(1-6):");
            int number = int.Parse(Console.ReadLine());
            while (number != 1 && number != 2 && number != 3 && number != 4 && number != 5 && number != 6)
            {
                Console.WriteLine();
                Console.Write($"{_players[index].Name} plese write your threw value(1-6):");
                number = int.Parse(Console.ReadLine());
            }

            return number;
        }

        public static void HeSheLost(int index, Players[] _players)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{_players[index].Name} lost, last money: {_players[index].Money}");
            Console.ResetColor();
        }
    }
}
