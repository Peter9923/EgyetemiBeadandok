using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Akasztófa_
{
    static class FilesReadWrite
    {
        private static Random _rnd;


        public static string[] CategoryFromTxt()
        {
            StreamReader sr = new StreamReader("szavak.txt");
            int length_ = FileLength();
            string[] categories = new string[length_];

            //0. index szavak száma,   1. index kategória,  2. index összes szó..
            int i = 0;
            while (!sr.EndOfStream)
            {
                string[] split_ = sr.ReadLine().Split('_');
                categories[i] = split_[1];
                i++;
            }

            return categories;
        }
        public static int FileLength()
        {
            StreamReader sr = new StreamReader("szavak.txt");
            int j = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                j++;
            }
            return j;
        }


        public static string ChoiceWord(string category)
        {
            string word = "";
            StreamReader sr = new StreamReader("szavak.txt");


            string[] words = new string[CategoryesWords(category)];
            while (!sr.EndOfStream)
            {
                string[] darabolt = sr.ReadLine().Split('_');
                if (darabolt[1] == category)
                {
                    string[] megegyszerDarabol = darabolt[2].Split(';');
                    for (int i = 0; i < megegyszerDarabol.Length; i++)
                    {
                        words[i] = megegyszerDarabol[i].ToLower();
                    }


                }

            }
            _rnd = new Random();
            int index = _rnd.Next(0, words.Length);
            word = words[index];

            return word;
        }

        public static int CategoryesWords(string category)
        {
            int length_ = 0;
            StreamReader sr = new StreamReader("szavak.txt");
            while (!sr.EndOfStream)
            {
                string[] darabolt = sr.ReadLine().Split('_');
                if (darabolt[1] == category)
                {
                    length_ = int.Parse(darabolt[0]);
                }
            }

            return length_;
        }



    }
}
