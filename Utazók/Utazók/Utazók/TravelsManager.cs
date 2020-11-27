using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utazók
{
    class TravelsManager
    {
        private Travels[] First { get; set; }
        private Travels[] Second { get; set; }


        public void Meet()
        {
            ArrayInitialization();
            LoadCitiesAtTravelsArray();
            string[] theyMeetHere = new string[0];
            WhereCouldTheyMeet(ref theyMeetHere);
            RemoveElements(ref theyMeetHere);
            WriteFile(theyMeetHere);
        }

        private void ArrayInitialization()
        {
            StreamReader sr = new StreamReader("UTAZO.BE.txt");
            int _firstTravel = int.Parse(sr.ReadLine());
            int _firstTravelLastNum = 0;
            for (int i = 0; i < _firstTravel; i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                _firstTravelLastNum = int.Parse(split[1]);
            }
            int _secondTravel = int.Parse(sr.ReadLine());
            int _secondTravelLastNum = 0;
            for (int i = 0; i < _secondTravel; i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                _secondTravelLastNum = int.Parse(split[1]);
            }

            //mivel van 25. nap is, és az a tömbben a 25. indexre mutatna, ezért megkell növelni eggyel , hogy lehessen 25. index is! Ezt lehetne közbeni -olással is, csak így átláthatóbb.
            //lényegében egy  _firstTravelLastNum++ és egy _secondTravelLastNum++  napos tömböt hozunk létre, ahol a 0. index a 0. nap, az 1. az 1. nap és így tovább
            _firstTravelLastNum++;
            _secondTravelLastNum++;

            First = new Travels[_firstTravelLastNum];
            for (int i = 0; i < First.Length; i++)
            {
                First[i] = new Travels(string.Empty);
            }
            Second = new Travels[_secondTravelLastNum];
            for (int i = 0; i < Second.Length; i++)
            {
                Second[i] = new Travels(string.Empty);
            }
            sr.Close();

        }

        private void LoadCitiesAtTravelsArray()
        {
            StreamReader sr = new StreamReader("UTAZO.BE.txt");
            int _firtsTravel = int.Parse(sr.ReadLine());
            for (int i = 0; i < _firtsTravel; i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                for (int j = int.Parse(split[0]); j <= int.Parse(split[1]); j++)
                {
                    Travels IamHere = new Travels(split[2]);
                    First[j] = IamHere;
                }
            }
            int _secondTravel = int.Parse(sr.ReadLine());
            for (int i = 0; i < _secondTravel; i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                for (int j = int.Parse(split[0]); j <= int.Parse(split[1]); j++)
                {
                    Travels IamHere = new Travels(split[2]);
                    Second[j] = IamHere;
                }


            }


            sr.Close();
        }

        private void WhereCouldTheyMeet(ref string[] meetHere)
        {
            //megkell nézni, hogy melyik a kisebb
            //amelyik a kisebb az alapján megyünk, mert neki az utazása előbb ért véget, így utána már nem találkozhattak..
            if (First.Length <= Second.Length)
            {

                meetHere = new string[First.Length]; // a felesleget majd a végén töröljük!
                for (int i = 0; i < First.Length; i++)
                {
                    if (First[i].City == Second[i].City)
                    {
                        meetHere[i] = First[i].City;
                    }
                    else
                    {
                        meetHere[i] = string.Empty;
                    }
                }
            }
            else
            {

                meetHere = new string[Second.Length]; // a felesleget majd a végén töröljük!
                for (int i = 0; i < Second.Length; i++)
                {
                    if (Second[i].City == First[i].City)
                    {
                        meetHere[i] = Second[i].City;

                    }
                    else
                    {
                        meetHere[i] = string.Empty;
                    }
                }
            }


        }

        private void RemoveElements(ref string[] meetHere)
        {
            int counter = 0;
            string ezekvoltak = "";
            for (int i = 0; i < meetHere.Length; i++)
            {
                if (meetHere[i] != string.Empty)
                {
                    if (!ezekvoltak.Contains(meetHere[i]))
                    {
                        ezekvoltak += meetHere[i];
                        counter++;
                    }
                }
            }

            ezekvoltak = "";
            string[] newArray = new string[counter];
            counter = 0;
            for (int i = 0; i < meetHere.Length; i++)
            {
                if (meetHere[i] != string.Empty)
                {
                    if (!ezekvoltak.Contains(meetHere[i]))
                    {
                        newArray[counter] = meetHere[i];
                        ezekvoltak += meetHere[i];
                        counter++;
                    }
                }
            }

            meetHere = newArray;

        }

        private void WriteFile(string[] meet)
        {
            Console.WriteLine("UTAZO.KI.txt  tartalma: ");
            StreamWriter sw = new StreamWriter("UTAZO.KI.txt");
            sw.WriteLine(meet.Length);
            Console.WriteLine(meet.Length);
            for (int i = 0; i < meet.Length; i++)
            {
                sw.WriteLine(meet[i]);
                Console.WriteLine(meet[i]);
            }

            sw.Close();
        }
    }
}
