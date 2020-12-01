using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LáncKód
{
    class PictureManager
    {
        private string[,] _pictureMap;
        private string[,] _asistantArray;
        private Picture _picture;
        private int[] _results;

        public void BlackPatch()
        {
            ReadAndLoadFiles();
            Show.DrawMap(_pictureMap);
            bool _firstChechk = ChechIfFileHaveX();
            bool _secondchechkXisLonely = CheckIfXisLonely();




            if (_firstChechk == true && _secondchechkXisLonely == false)
            {
                //kezdő poziciót keress...
                FirstPosition();



                //Console.WriteLine(_picture.Sor + " " + _picture.Oszlop);
                //8 irányba lehet menni, órakörbejárási irányával..
                //4 x van, így 4 lépés lesz. az utolsó lépés mindig mikor a kezdőpontra lépünk vissza.
                for (int i = 0; i < _results.Length; i++)
                {
                    Console.SetCursorPosition(0, _pictureMap.GetLength(0) + 1);
                    Console.WriteLine("ENTER LEÜTÉSÉVEL MUTATOM A KÖVETKEZŐ LÉPÉST");
                    Console.ReadLine();
                    bool _movementOkay = false;
                    while (_movementOkay != true)
                    {
                        //Nézd meg ezekben azt , hogy van e már az assistantArrayben
                        _movementOkay = SecondCheck(i);
                        if (_movementOkay == false)
                        {
                            _movementOkay = ThirdCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = FourthCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = FiftCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = SixthCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = SeventhCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = EighthCheck(i);
                        }
                        if (_movementOkay == false)
                        {
                            _movementOkay = FirstCheck(i);
                        }
                    }
                }
                WriteResult();
            }
        }
        //---------



        private void WriteResult()
        {
            StreamWriter sw = new StreamWriter("FOLTx.KI.txt");
            sw.WriteLine(_picture.Sor + " " + _picture.Oszlop);
            for (int i = 0; i < _results.Length; i++)
            {
                sw.Write(_results[i]);
            }
            sw.Close();
        }


        private bool FirstCheck(int i)
        {
            //felfél nézzük a sort - OLNI kell
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _poisitonTop = _picture.Sor;
            _poisitonTop--;
            //ha nem a szélén van csak akkor kell nézni!, először a fentit nézzük, mivel óramutató irányába haladunk..
            if ((_poisitonTop) > 1)
            {
                if (_pictureMap[_poisitonTop, _positionLeft] == "X" && _asistantArray[_poisitonTop, _positionLeft] != "O")
                {
                    _picture.Sor = _poisitonTop--;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_poisitonTop, _positionLeft] = "O";
                    _results[i] = 1;
                    Show.ShowNextMovement(_poisitonTop, _positionLeft);
                    _result = true;
                }
            }

            return _result;
        }
        private bool SecondCheck(int i)
        {
            //FELfele jobbra átóba nézzük, sort - oljuk és az oszlop indexet +oljuk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _poisitonTop = _picture.Sor;
            _poisitonTop--;
            _positionLeft++;

            if (_poisitonTop > 1 && _positionLeft < _pictureMap.GetLength(1) - 2)
            {
                if (_pictureMap[_poisitonTop, _positionLeft] == "X" && _asistantArray[_poisitonTop, _positionLeft] != "O")
                {
                    _picture.Sor = _poisitonTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_poisitonTop, _positionLeft] = "O";
                    _results[i] = 8;
                    Show.ShowNextMovement(_poisitonTop, _positionLeft);
                    _result = true;
                }


            }

            return _result;
        }
        private bool ThirdCheck(int i)
        {
            //jobbra nézzük, oszlop indexet +oljuk
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft += 1;

            if (_positionLeft < _pictureMap.GetLength(1) - 2)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X" && _asistantArray[_positionTop, _positionLeft] != "O")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 7;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }



            return _result;
        }
        private bool FourthCheck(int i)
        {
            //lefele jobb átlóba nézzük, oszlopot +oljuk mivel jobbra megyünk, sort +oljuk, mert lefelé megyünk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft++;
            _positionTop++;

            if (_positionLeft < _pictureMap.GetLength(1) - 2 && _positionTop < _pictureMap.GetLength(0) - 2 && _asistantArray[_positionTop, _positionLeft] != "O")
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 6;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }


            return _result;
        }
        private bool FiftCheck(int i)
        {
            //lefele, sort +olunk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionTop++;

            if (_positionTop < _pictureMap.GetLength(0) - 2)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X" && _asistantArray[_positionTop, _positionLeft] != "O")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 5;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }


            return _result;
        }
        private bool SixthCheck(int i)
        {
            //- olunk, és lefele +olunk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft--;
            _positionTop++;

            if (_positionTop < _pictureMap.GetLength(0) - 2 && _positionLeft > 1)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X" && _asistantArray[_positionTop, _positionLeft] != "O")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 4;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }


            return _result;
        }
        private bool SeventhCheck(int i)
        {
            //csak balra megyünk..
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft--;

            if (_positionLeft > 1)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X" && _asistantArray[_positionTop, _positionLeft] != "O")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 3;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }


            return _result;
        }
        private bool EighthCheck(int i)
        {
            //balra és felfele megyünk
            //csak balra megyünk..
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft--;
            _positionTop--;

            if (_positionLeft > 1 && _positionTop > 1)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X" && _asistantArray[_positionTop, _positionLeft] != "O")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _asistantArray[_positionTop, _positionLeft] = "O";
                    _results[i] = 2;
                    Show.ShowNextMovement(_positionTop, _positionLeft);
                    _result = true;
                }
            }


            return _result;
        }


        private void ReadAndLoadFiles()
        {
            StreamReader sr = new StreamReader("FOLTx.BE.txt");
            string[] _splitedFirstLine = sr.ReadLine().Split(' ');
            _pictureMap = new string[int.Parse(_splitedFirstLine[0]) + 2, int.Parse(_splitedFirstLine[1]) + 2];


            int counter = 0;
            for (int i = 1; i < _pictureMap.GetLength(0) - 1; i++)
            {
                string _oneLine = sr.ReadLine();
                for (int j = 1; j < _pictureMap.GetLength(1) - 1; j++)
                {
                    _pictureMap[i, j] = _oneLine[j - 1].ToString();
                    if (_pictureMap[i, j] == "X")
                    {
                        counter++;
                    }
                }
            }
            _results = new int[counter];
            _asistantArray = new string[int.Parse(_splitedFirstLine[0]) + 2, int.Parse(_splitedFirstLine[1]) + 2];


            _pictureMap[0, 0] = "+";
            _pictureMap[0, _pictureMap.GetLength(1) - 1] = "+";
            _pictureMap[_pictureMap.GetLength(0) - 1, 0] = "+";
            _pictureMap[_pictureMap.GetLength(0) - 1, _pictureMap.GetLength(1) - 1] = "+";
            for (int i = 1; i < _pictureMap.GetLength(1) - 1; i++)
            {
                _pictureMap[0, i] = "-";
            }
            for (int i = 1; i < _pictureMap.GetLength(1) - 1; i++)
            {
                _pictureMap[_pictureMap.GetLength(0) - 1, i] = "-";
            }
            for (int i = 1; i < _pictureMap.GetLength(0) - 1; i++)
            {
                _pictureMap[i, 0] = "|";
            }

            for (int i = 1; i < _pictureMap.GetLength(0) - 1; i++)
            {
                _pictureMap[i, _pictureMap.GetLength(1) - 1] = "|";
            }
            sr.Close();
        }
        private bool ChechIfFileHaveX()
        {
            bool _haveX = false;

            for (int i = 1; i < _pictureMap.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _pictureMap.GetLength(1) - 1; j++)
                {
                    if (_pictureMap[i, j] == "X")
                    {
                        _haveX = true;
                    }
                }
            }

            if (_haveX == false)
            {
                WriteNoneX();
            }
            return _haveX;
        }
        private void WriteNoneX()
        {
            StreamWriter sw = new StreamWriter("FOLTx.KI.txt");
            sw.WriteLine("NINCS FOLT");
            sw.Close();
        }
        private bool CheckIfXisLonely()
        {
            bool _result = false;
            int counter = 0;
            for (int i = 1; i < _pictureMap.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _pictureMap.GetLength(1) - 1; j++)
                {
                    if (_pictureMap[i, j] == "x")
                    {
                        counter++;
                    }
                }
            }
            if (counter == 1)
            {
                _result = true;
                WriteLonelyX();
            }
            return _result;
        }
        private void WriteLonelyX()
        {
            StreamWriter sw = new StreamWriter("FOLTx.KI.txt");
            sw.WriteLine("Egyetlen foltod van csak...");
            sw.Close();
        }


        private void FirstPosition()
        {
            bool _findIt = false;
            int i = 1;
            while (_findIt != true && i != _pictureMap.GetLength(0) - 1)
            {
                int j = 1;
                while (_findIt != true && j != _pictureMap.GetLength(1) - 1)
                {

                    if (_pictureMap[i, j] == "X")
                    {
                        _picture = new Picture(i, j);
                        _findIt = true;
                    }

                    j++;
                }
                i++;
            }
        }
    }
}

