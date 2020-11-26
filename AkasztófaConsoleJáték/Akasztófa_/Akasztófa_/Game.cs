using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akasztófa_
{
    class Game
    {
        private int _mistakeCounter { get; set; }
        private string _findIt { get; set; }
        private string _findItEmpty { get; set; }

        public void Play()
        {
            Console.ResetColor();
            _mistakeCounter = 0;
            string mayTip = "ÖÜÓQWERTZUIOPŐÚASDFGHJKLÉÁŰÍYXCVBNM";
            string wasTip = "";
            int left = 0;
            Show.ChoiceCategory();
            Console.SetCursorPosition(70, 0);
            string category = Console.ReadLine();
            _findIt = FilesReadWrite.ChoiceWord(category);
            _findIt = _findIt.ToUpper();
            FINDITEMPTRY();
            Console.Clear();

            Console.SetCursorPosition(15, 2);
            Console.WriteLine(_findItEmpty);
            Show.BasicDraw();

            Console.SetCursorPosition(0, 19);
            Console.WriteLine("Tippelt Betük: ");
            do
            {
                Console.SetCursorPosition(left, 20);
                string _letter = Console.ReadKey().KeyChar.ToString();
                _letter = _letter.ToUpper();

                bool _letterIsCorrect = mayTip.Contains(_letter);

                if (_letterIsCorrect == true)
                {
                    bool _chekItWas = wasTip.Contains(_letter);

                    if (_chekItWas == false)
                    {
                        left += 3;

                        bool _letterIsInTheWord = _findIt.Contains(_letter);

                        if (_letterIsInTheWord == true)
                        {
                            YouFindOne(_letter);
                            Console.SetCursorPosition(15, 2);
                            Console.WriteLine(_findItEmpty);

                        }
                        else
                        {
                            _mistakeCounter++;
                            Show.Mistake(_mistakeCounter);

                        }

                        wasTip += _letter;
                    }
                }




            } while (_findIt != _findItEmpty && _mistakeCounter != 12);

            WInCheck();



        }

        private void FINDITEMPTRY()
        {
            string newWord = "";
            for (int i = 0; i < _findIt.Length; i++)
            {
                if (_findIt[i].ToString() == " ")
                {
                    newWord += " ";
                }
                else
                {
                    newWord += "_";
                }
            }

            _findItEmpty = newWord;
        }
        private void YouFindOne(string tip)
        {
            string newWord = "";
            for (int i = 0; i < _findIt.Length; i++)
            {
                if (_findIt[i].ToString() == tip)
                {
                    newWord += tip;
                }
                else
                {
                    newWord += _findItEmpty[i].ToString();
                }
            }

            _findItEmpty = newWord;
        }
        private void WInCheck()
        {
            if (_findIt == _findItEmpty)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("GRATULÁLOK KITALÁLTAD A SZÓT! Szeretnél újra járszani  (i)/(n): ");
                Console.ResetColor();
                string beolvas = Console.ReadKey().KeyChar.ToString();
                beolvas = beolvas.ToUpper();
                if (beolvas == "I")
                {
                    Console.Clear();
                    Play();
                }
                else
                {
                    Exit();
                }
            }
        }
        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Köszi a játékot, Enter leütéssel kiléphetsz!");
            Console.ReadLine();
        }



    }
}
