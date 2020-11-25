using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rendezvény
{
    class EvenetManager
    {

        private Event[] _event;
        private Event[] _roomA;
        private Event[] _roomB;


        public void Selection()
        {
            bool isExist = WouldYouLikeToRead();
            if (isExist == false)
            {
                ReadEvent();
            }
            else
            {
                WriteEvent();
                ReadEvent();
            }
            Console.Clear();
            Console.WriteLine("Eredeti Igény Lista:");
            WriteEventsToConsole();
            Sorting();
            Console.WriteLine("Záró időpont szerinti rendezett lista:");
            WriteEventsToConsole();
            MinusOneAll();
            SelectsBestOptions();
            RemoveMinusOne(ref _roomA);
            RemoveMinusOne(ref _roomB);
            WriteFiles();

        }

        private bool WouldYouLikeToRead()
        {
            Console.WriteLine("Szia!\n");
            Console.Write("Jelenleg létezik egy RENDEZZ.BE.txt állomány, ammnyiben szeretnéd felülírni, nyomj le egy (I) betűt:");
            if (Console.ReadKey().KeyChar == 'I' || Console.ReadKey().KeyChar == 'i')
            {
                Console.WriteLine();
                return true;

            }
            else
            {
                Console.WriteLine();
                return false;
            }

        }
        private void ReadEvent()
        {

            StreamReader sr = new StreamReader("RENDEZ.BE.txt");
            int allEvent = int.Parse(sr.ReadLine());
            _event = new Event[allEvent];
            _roomA = new Event[allEvent];
            _roomB = new Event[allEvent];
            int x = 0;
            while (!sr.EndOfStream)
            {
                string[] oneLine = sr.ReadLine().Split(' ');
                Event event_ = new Event(x + 1, int.Parse(oneLine[0]), int.Parse(oneLine[1]));
                _event[x] = event_;
                x++;
            }
            sr.Close();
        }
        private void WriteEvent()
        {
            StreamWriter sw = new StreamWriter("RENDEZ.BE.txt");
            Console.Write("Hány előadásra tartasz igényt: ");
            int allEvent = int.Parse(Console.ReadLine());
            sw.WriteLine(allEvent);
            for (int i = 0; i < allEvent; i++)
            {
                Console.Write($"Adja meg a(z) {i + 1}. előadás kezdő időpontját: ");
                int startTime = int.Parse(Console.ReadLine());
                Console.Write($"Adja meg a(z) {i + 1}. előadás záró időpontját: ");
                int endTime = int.Parse(Console.ReadLine());

                sw.WriteLine(startTime + " " + endTime);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("RENDEZ.BE.txt álomány előállítva!");
            Console.ResetColor();
            sw.Close();
        }
        private void WriteEventsToConsole()
        {
            Console.WriteLine("{0,20} {1,16} {2,16}", "|  Előadás Indexe  |", "Kezdőidőpont |", " ZáróIdőpont |");
            for (int i = 0; i < _event.Length; i++)
            {
                Console.WriteLine("{0,11} {1,17} {2,16}", _event[i].IndxOfShow, _event[i].StartTime, _event[i].EndTime);
            }
        }
        private void Sorting()
        {
            for (int i = _event.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (_event[j].EndTime > _event[j + 1].EndTime)
                    {
                        int index = _event[j].IndxOfShow;
                        int start = _event[j].StartTime;
                        int end = _event[j].EndTime;

                        _event[j].IndxOfShow = _event[j + 1].IndxOfShow;
                        _event[j].StartTime = _event[j + 1].StartTime;
                        _event[j].EndTime = _event[j + 1].EndTime;

                        _event[j + 1].IndxOfShow = index;
                        _event[j + 1].StartTime = start;
                        _event[j + 1].EndTime = end;

                    }
                    //ha a j-edik és j+1 edig elem záró időpontja megegyezeik akkor összvetjük a j-edik kezdőjét.. ja a j-edik kezdője nagyobb, mint a j+1-edig vég, akkor cserélünk
                    else if (_event[j].EndTime == _event[j + 1].EndTime && _event[j].StartTime > _event[j + 1].EndTime)
                    {
                        int index = _event[j].IndxOfShow;
                        int start = _event[j].StartTime;
                        int end = _event[j].EndTime;

                        _event[j].IndxOfShow = _event[j + 1].IndxOfShow;
                        _event[j].StartTime = _event[j + 1].StartTime;
                        _event[j].EndTime = _event[j + 1].EndTime;

                        _event[j + 1].IndxOfShow = index;
                        _event[j + 1].StartTime = start;
                        _event[j + 1].EndTime = end;
                    }


                }
            }

        }
        private void MinusOneAll()
        {
            for (int i = 0; i < _roomA.Length; i++)
            {
                Event _event = new Event(-1, 0, 0);
                _roomA[i] = _event;
                _roomB[i] = _event;
            }
        }
        private void SelectsBestOptions()
        {
            //A és B-nek indexelésére, illetve a zaroidoPont ba a lokálisan legjobb választási lehetőség záróidőpontját tesszük bele.
            int counterA = 0;
            int counterB = 0;
            int endTimeA = -10;
            int endTimeB = -10;

            for (int i = 0; i < _event.Length; i++)
            {
                //ebben az esetben az A előadóterembe tesszük.. Ha az aktuális előadás kezdőértéke nagyobb, mint a legutóbbi tárolt A előadó terem záróidőpontja és ( a kezdő kisebb vagy egyenlő , mint a B zárója vagy ha az A záró nagyobb vagy egyenlő B záró időpontjával
                if (_event[i].StartTime > endTimeA && (_event[i].StartTime <= endTimeB || endTimeA >= endTimeB))
                {
                    Event event_ = new Event(_event[i].IndxOfShow, _event[i].StartTime, _event[i].EndTime);
                    _roomA[counterA] = event_;
                    counterA++;
                    endTimeA = _event[i].EndTime;
                }
                else if (_event[i].StartTime > endTimeB && (_event[i].StartTime <= endTimeA || endTimeB >= endTimeA))
                {
                    Event event_ = new Event(_event[i].IndxOfShow, _event[i].StartTime, _event[i].EndTime);
                    _roomB[counterB] = event_;
                    counterB++;
                    endTimeB = _event[i].EndTime;
                }

            }



        }
        private void RemoveMinusOne(ref Event[] room)
        {
            int db = 0;
            for (int i = 0; i < room.Length; i++)
            {
                if (room[i].IndxOfShow != -1)
                {
                    db++;
                }
            }
            Event[] newRoom = new Event[db];
            int counter = 0;
            for (int i = 0; i < room.Length; i++)
            {
                if (room[i].IndxOfShow != -1)
                {
                    Event e = new Event(room[i].IndxOfShow, room[i].StartTime, room[i].EndTime);
                    newRoom[counter] = e;
                    counter++;
                }

            }
            room = newRoom;

        }
        private void WriteFiles()
        {
            StreamWriter sw = new StreamWriter("RENDEZ.KI.txt");
            sw.WriteLine(_roomA.Length + " " + _roomB.Length);
            for (int i = 0; i < _roomA.Length; i++)
            {
                if (i == _roomA.Length - 1)
                {
                    sw.Write(_roomA[i].IndxOfShow);
                }
                else
                {
                    sw.Write(_roomA[i].IndxOfShow + " ");
                }
            }
            sw.WriteLine();
            for (int i = 0; i < _roomB.Length; i++)
            {
                if (i == _roomB.Length - 1)
                {
                    sw.Write(_roomB[i].IndxOfShow);
                }
                else
                {
                    sw.Write(_roomB[i].IndxOfShow + " ");
                }
            }
            sw.Close();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("RENDEZ.KI.txt állomány létrehozva!");
            Console.ResetColor();
        }

    }
}
