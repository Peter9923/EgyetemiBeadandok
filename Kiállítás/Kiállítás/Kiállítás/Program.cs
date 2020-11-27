using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kiállítás
{
    class Exhibition
    {
        private int arriveTime;
        private int endTime;


        public int ArriveTime
        {
            get { return arriveTime; }
            set { arriveTime = value; }
        }
        public int EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public Exhibition(int arriveTime_, int endTime_)
        {
            arriveTime = arriveTime_;
            endTime = endTime_;
        }

    }

    class ExhibitionManager
    {
        private Exhibition[] exhibition;


        public void CallThis()
        {
            ReadFile(ref exhibition);

            Sorting(ref exhibition);

            Intervallums();
            
        }
        private void ReadFile(ref Exhibition[] _exhibition)
        {
            StreamReader sr = new StreamReader("KIALLIT.BE.txt");
            int _fullShow = int.Parse(sr.ReadLine());
            exhibition = new Exhibition[_fullShow];
            for (int i = 0; i < _fullShow; i++)
            {
                string[] split_ = sr.ReadLine().Split(' ');
                Exhibition oneShow = new Exhibition(int.Parse(split_[0]), int.Parse(split_[1]));
                exhibition[i] = oneShow;
            }
            sr.Close();
        }
        private void Sorting(ref Exhibition[] _exhibition)
        {

            for (int i = _exhibition.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (_exhibition[j].EndTime > _exhibition[j + 1].EndTime)
                    {
                        int start = _exhibition[j].ArriveTime;
                        int end = _exhibition[j].EndTime;

                        _exhibition[j].ArriveTime = _exhibition[j + 1].ArriveTime;
                        _exhibition[j].EndTime = _exhibition[j + 1].EndTime;

                        _exhibition[j + 1].ArriveTime = start;
                        _exhibition[j + 1].EndTime = end;

                    }
                    //ha a j-edik és j+1 edig elem záró időpontja megegyezeik akkor összvetjük a j-edik kezdőjét.. ja a j-edik kezdője nagyobb, mint a j+1-edig vég, akkor cserélünk
                    else if (_exhibition[j].EndTime == _exhibition[j + 1].EndTime && _exhibition[j].ArriveTime > _exhibition[j + 1].ArriveTime)
                    {
                        int start = _exhibition[j].ArriveTime;
                        int end = _exhibition[j].EndTime;

                        _exhibition[j].ArriveTime = _exhibition[j + 1].ArriveTime;
                        _exhibition[j].EndTime = _exhibition[j + 1].EndTime;

                        _exhibition[j + 1].ArriveTime = start;
                        _exhibition[j + 1].EndTime = end;
                    }


                }
            }

        }

        private int ArrayLength(Exhibition[] _exhibition)
        {
           
            int max = int.MinValue;
            for (int i = 0; i < _exhibition.Length; i++)
            {
               
                if (_exhibition[i].EndTime > max)
                {
                    max = _exhibition[i].EndTime;
                }

            }
           
            return max;
        }

        private int[] AllTime()
        {
            
            int[] allTime = new int[ArrayLength(exhibition)];
            for (int i = 0; i < exhibition.Length; i++)
            {
                for (int j = exhibition[i].ArriveTime; j <= exhibition[i].EndTime; j++)
                {
                    allTime[j-1] = j;
                }
            }
            return allTime;
        }
        public void Intervallums()
        {
            int[] allTime_ = AllTime();
            int index = 0;
            int min = 0;
            int max = 0;
            int counter = 0;
            while (index != allTime_.Length)
            {

                if (allTime_[index] == 0)
                {
                    while (allTime_[index] == 0)
                    {
                        index++;
                    }
                    counter++;
                    index--;
                }
                index++;
            }
            //ahány 0 van annyi vágás volt benne, tehát counter +1 időintervallumra bontható, mivel ha pld egy almába két szeletet vágunk, akkor 3 szelet jön létre.
            counter++;
            int[,] intervallums = new int[counter, 2];
            index = 0;
            counter = 0;
            int minus = 0;
            while (index != allTime_.Length)
            {
                if (allTime_[index] == 0)
                {
                    //mivel az indexedik 0-ás..
                    max = allTime_[index - 1];
                    if (counter == 0)
                    {
                        min = allTime_[max - index];
                        intervallums[counter, 0] = min;
                    }
                    intervallums[counter, 1] = max;

                    while (allTime_[index] == 0)
                    {
                        index++;
                        minus++;
                    }
                    counter++;
                    if (counter > 0)
                    {
                        min = allTime_[index];
                        intervallums[counter, 0] = min;
                    }

                    index--;
                }

                index++;
            }

            intervallums[2, 1] = allTime_[allTime_.Length-1];

            WriteFile(intervallums);

        }

        private void WriteFile(int[,] intervallums)
        {
            Console.WriteLine("KIALLIT.KI.txt  tartalma:");
            StreamWriter sw = new StreamWriter("KIALLIT.KI.txt");
            sw.WriteLine(intervallums.Length / 2);
            Console.WriteLine(intervallums.Length/2);

            for (int i = 0; i < intervallums.GetLength(0); i++)
            {
                sw.WriteLine(intervallums[i,0] + " " + intervallums[i,1]);
                Console.WriteLine(intervallums[i, 0] + " " + intervallums[i, 1]);
            }

            sw.Close();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            ExhibitionManager em = new ExhibitionManager();
            em.CallThis();

            Console.ReadKey();
        }
    }
}
