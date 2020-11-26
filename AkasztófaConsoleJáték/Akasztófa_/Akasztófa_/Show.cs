using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akasztófa_
{
    static class Show
    {
        public static void BasicDraw()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(10, 16);
            for (int i = 0; i < 23; i++)
            {
                Console.Write("-");
            }
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(14, 15 - i);
                Console.Write("|");
            }
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("/");
            Console.SetCursorPosition(16, 7);
            Console.WriteLine("/");
            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(14 + i, 6);
                Console.Write("_");
            }
            Console.SetCursorPosition(24, 7);
            Console.Write("|");
            Console.SetCursorPosition(24, 8);
            Console.Write("|");
            Console.SetCursorPosition(24, 9);
            Console.Write("O");
            Console.SetCursorPosition(24, 10);
            Console.Write("|");
            Console.SetCursorPosition(24, 11);
            Console.Write("|");
            Console.SetCursorPosition(23, 10);
            char karakter = (char)92;
            Console.Write(karakter);
            Console.SetCursorPosition(25, 10);
            Console.Write("/");
            Console.SetCursorPosition(23, 12);
            Console.Write("/");
            Console.SetCursorPosition(25, 12);
            Console.Write(karakter);
            Console.ResetColor();

        }

        //Hiba esetén.."
        public static void Mistake(int mistake_)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (mistake_ == 1)
            {
                Console.SetCursorPosition(10, 16);
                for (int i = 0; i < 23; i++)
                {
                    Console.Write("-");
                }


            }
            else if (mistake_ == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(14, 15 - i);
                    Console.Write("|");
                }
            }
            else if (mistake_ == 3)
            {
                Console.SetCursorPosition(15, 8);
                Console.WriteLine("/");
                Console.SetCursorPosition(16, 7);
                Console.WriteLine("/");
            }
            else if (mistake_ == 4)
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.SetCursorPosition(14 + i, 6);
                    Console.Write("_");
                }

            }
            else if (mistake_ == 5)
            {
                Console.SetCursorPosition(24, 7);
                Console.Write("|");
                Console.SetCursorPosition(24, 8);
                Console.Write("|");
            }
            else if (mistake_ == 6)
            {
                Console.SetCursorPosition(24, 9);
                Console.Write("O");
            }
            else if (mistake_ == 7)
            {
                Console.SetCursorPosition(24, 10);
                Console.Write("|");
            }
            else if (mistake_ == 8)
            {
                Console.SetCursorPosition(24, 11);
                Console.Write("|");
            }
            else if (mistake_ == 9)
            {
                Console.SetCursorPosition(23, 10);
                char karakter = (char)92;
                Console.Write(karakter);
            }
            else if (mistake_ == 10)
            {
                Console.SetCursorPosition(25, 10);
                Console.Write("/");
            }
            else if (mistake_ == 11)
            {
                Console.SetCursorPosition(23, 12);
                Console.Write("/");
            }
            else if (mistake_ == 12)
            {
                Console.SetCursorPosition(25, 12);
                char karakter = (char)92;
                Console.Write(karakter);

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sajnos akasztva lettél! \nSZeretnél mégegyet játszani? (i/n)");
                string choice_ = Console.ReadKey().KeyChar.ToString();
                choice_ = choice_.ToUpper();
                if (choice_ == "I")
                {
                    //NYISS MAJD ÚJ JÁTÉKOT!
                    Console.Clear();
                    Game game = new Game();
                    game.Play();
                }
                else
                {
                    Game game = new Game();
                    game.Exit();
                }
            }

            Console.ResetColor();

        }
        //.......

        public static void ChoiceCategory()
        {
            Console.WriteLine("Válassz kategóriát az alábbiak közül: (Ügyelj a karakteregyezésre!):");
            string[] categories = FilesReadWrite.CategoryFromTxt();
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine(categories[i]);
            }

        }





    }
}
