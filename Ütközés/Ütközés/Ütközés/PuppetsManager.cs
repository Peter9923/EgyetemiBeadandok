using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ütközés
{
    class PuppetsManager
    {
        private string[,] _map { get; set; }
        private Puppets[] _puppets { get; set; }
        private int _timeLimit { get; set; }
        int[] _noneZone { get; set; }

        public void Collision()
        {
            ReadAndLoadFiles();
            int _timeNow = 0;
            bool _collision = false;

            do
            {
                Console.Title = _timeNow + "/" + _timeLimit;
                Console.Clear();
                Show.DrawMap(_map);
                Show.DrawPuppets(_puppets);
                _collision = HadCollision();

                Console.SetCursorPosition(0, _map.GetLength(0) + 2);
                Show.NewPosition(_puppets);
                MoveYourPuppets();
                Show.Next();
                _timeNow++;

            } while (_collision != true && _timeNow != _timeLimit);
            Console.Clear();
            Console.Title = _timeNow + "/" + _timeLimit;
            Show.DrawMap(_map);
            Show.DrawPuppets(_puppets);
            Console.SetCursorPosition(0, _map.GetLength(0) + 2);
            Show.NewPosition(_puppets);

            WriteFile(_collision, _timeNow);

        }

        private void WriteFile(bool _collision, int _time)
        {
            StreamWriter sw = new StreamWriter("tabla.ki.txt");

            if (_collision == true)
            {
                sw.WriteLine(_time);
                Console.WriteLine($"Ütközés történt a {_time}. időegységnél.");
            }
            else
            {
                sw.WriteLine("-1");
            }

            sw.Close();
        }

        private void ReadAndLoadFiles()
        {
            StreamReader sr = new StreamReader("tabla.be.txt");
            string[] _splitedFirstLine = sr.ReadLine().Split(' ');
            _map = new string[(int.Parse(_splitedFirstLine[0])) + 2, (int.Parse(_splitedFirstLine[1])) + 2];
            _puppets = new Puppets[int.Parse(_splitedFirstLine[2])];
            _timeLimit = int.Parse(_splitedFirstLine[3]);
            //első sor elintézve.. jöhet a többi..
            for (int i = 0; i < _puppets.Length; i++)
            {
                string[] _oneLIne = sr.ReadLine().Split(' ');
                Puppets _newPuppet = new Puppets(int.Parse(_oneLIne[0]), int.Parse(_oneLIne[1]), _oneLIne[2]);
                _puppets[i] = _newPuppet;
            }


            _map[0, 0] = "+";
            _map[0, _map.GetLength(1) - 1] = "+";
            _map[_map.GetLength(0) - 1, 0] = "+";
            _map[_map.GetLength(0) - 1, _map.GetLength(1) - 1] = "+";
            for (int i = 1; i < _map.GetLength(1) - 1; i++)
            {
                _map[0, i] = "-";
            }
            for (int i = 1; i < _map.GetLength(1) - 1; i++)
            {
                _map[_map.GetLength(0) - 1, i] = "-";
            }
            for (int i = 1; i < _map.GetLength(0) - 1; i++)
            {
                _map[i, 0] = "|";
            }

            for (int i = 1; i < _map.GetLength(0) - 1; i++)
            {
                _map[i, _map.GetLength(1) - 1] = "|";
            }
            for (int i = 1; i < _map.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _map.GetLength(1) - 1; j++)
                {
                    _map[i, j] = " ";
                }
            }

            _noneZone = new int[4];
            _noneZone[0] = 0; //erre a sor indexre nem léphet
            _noneZone[1] = _map.GetLength(0) - 1; //erre a sor indexre nem léphet

            _noneZone[2] = 0; //erre az oszlop indexre nem léphet!
            _noneZone[3] = _map.GetLength(1) - 1; //erre az oszlop indexre nem léphet;

            sr.Close();
        }

        private void MoveYourPuppets()
        {
            for (int i = 0; i < _puppets.Length; i++)
            {

                if (_puppets[i].MoveMentDirection == "J")
                {
                    //JOBBRA, oszlopindexet növelni, mivel csak jobbra megy ezért az utolsó oszlop indexre nem léphetsz, azt kell leellenőrizni.
                    if ((_puppets[i].RightDirection + 1) != _map.GetLength(1) - 1)
                    {
                        _puppets[i].RightDirection += 1;
                    }
                }
                else if (_puppets[i].MoveMentDirection == "B")
                {
                    //balra, oszlop indexet csökkents, nem lehet 0 az oszlop index!
                    if ((_puppets[i].RightDirection - 1) != 0)
                    {
                        _puppets[i].RightDirection -= 1;
                    }
                }
                else if (_puppets[i].MoveMentDirection == "L")
                {
                    //le, sor indexet növelj, nem lehet a max sor..
                    if ((_puppets[i].DownDirection + 1) != _map.GetLength(0) - 1)
                    {
                        _puppets[i].DownDirection += 1;
                    }
                }
                else
                {
                    //fel sor indexet csökkents, nem lehet 0 a sor..
                    if ((_puppets[i].DownDirection - 1) != 0)
                    {
                        _puppets[i].DownDirection -= 1;
                    }
                }
            }
        }

        private bool HadCollision()
        {
            bool _collision = false;
            //ütközés akkor van, ha ugyanazon a helyen vannak, vagy átléptek egymáson..
            int index = 0;
            while (_collision != true && index != _puppets.Length)
            {
                for (int i = 0; i < _puppets.Length; i++)
                {
                    //ha nem saját maga
                    if (index != i)
                    {
                        if (_puppets[index].DownDirection == _puppets[i].DownDirection && _puppets[index].RightDirection == _puppets[i].RightDirection)
                        {
                            _collision = true;
                        }
                    }
                }
                index++;
            }


            //ha nem volt ütközés azonos helyre lépésen, akkor megkell nézni, hogy áthaladtak-e egymáson..
            if (_collision == false)
            {
                //áthalad volt, ha az aktuális bábut elléptetjük az irányába és megegyezik valamelyik másik bábu indexével...
                _collision = SecondCollisionChechk();

            }



            return _collision;
        }

        private bool SecondCollisionChechk()
        {
            bool _collision = false;
            int index = 0;
            while (index != _puppets.Length && _collision != true)
            {

                for (int i = 0; i < _puppets.Length; i++)
                {
                    if (i != index)
                    {
                        //jobbra, +olod
                        if (_puppets[index].MoveMentDirection == "J" && _puppets[i].MoveMentDirection == "B" && _puppets[index].DownDirection == _puppets[i].DownDirection)
                        {
                            int _newRightDirection = _puppets[index].RightDirection;
                            _newRightDirection++;
                            if (_newRightDirection == _puppets[i].RightDirection)
                            {
                                _collision = true;
                            }
                        }
                        else if (_puppets[index].MoveMentDirection == "B" && _puppets[i].MoveMentDirection == "J" && _puppets[index].DownDirection == _puppets[i].DownDirection)
                        {
                            //balra -olod
                            int _newRightDirection = _puppets[index].RightDirection;
                            _newRightDirection--;
                            if (_newRightDirection == _puppets[i].RightDirection)
                            {
                                _collision = true;
                            }
                        }
                        else if (_puppets[index].MoveMentDirection == "L" && _puppets[i].MoveMentDirection == "F" && _puppets[index].RightDirection == _puppets[i].RightDirection)
                        {
                            //le +olod
                            int _newDownDirection = _puppets[index].DownDirection;
                            _newDownDirection++;
                            if (_newDownDirection == _puppets[i].DownDirection)
                            {
                                _collision = true;
                            }
                        }
                        else if (_puppets[index].MoveMentDirection == "F" && _puppets[i].MoveMentDirection == "L" && _puppets[index].RightDirection == _puppets[i].RightDirection)
                        {
                            //le -olod
                            int _newDownDirection = _puppets[index].DownDirection;
                            _newDownDirection--;
                            if (_newDownDirection == _puppets[i].DownDirection)
                            {
                                _collision = true;
                            }
                        }
                    }
                }


                index++;
            }
            return _collision;
        }


    }

}
