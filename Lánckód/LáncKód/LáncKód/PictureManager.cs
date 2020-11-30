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

                int _actualDirection = 8;
                int l = _picture.Sor;
                int k = _picture.Oszlop;
                int counter = 0;

                bool _move = false;
                while (counter < _results.Length || (_picture.Sor != l || _picture.Oszlop != k))
                {
                    _move = SecondCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = ThirdCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = FourthCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = FiftCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = SixthCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = SeventhCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                        counter++;
                    }
                    _actualDirection--;

                    //_____

                    _move = EighthCheck();
                    if (_move && counter < _results.Length)
                    {
                        _results[counter] = _actualDirection;
                    }
                    _actualDirection--;

                    //_____

                    if (_actualDirection == 1)
                    {
                        _actualDirection = 8;
                    }
                    l = _picture.Sor;
                    k = _picture.Oszlop;
                }
                WriteResult();
            }
        }
        //---------



        private void WriteResult()
        {
            StreamWriter sw = new StreamWriter("FOLTx.KI.txt");
            sw.WriteLine(_picture.Oszlop + " " + _picture.Sor);
            for (int i = 0; i < _results.Length; i++)
            {
                sw.Write(_results[i]);
            }
            sw.Close();
        }


        private bool FirstCheck()
        {
            //felfél nézzük a sort - OLNI kell
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _poisitonTop = _picture.Sor;
            _poisitonTop--;
            //ha nem a szélén van csak akkor kell nézni!, először a fentit nézzük, mivel óramutató irányába haladunk..
            if ((_poisitonTop) > 1)
            {
                if (_pictureMap[_poisitonTop, _positionLeft] == "X")
                {
                    _picture.Sor = _poisitonTop--;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }

            return _result;
        }
        private bool SecondCheck()
        {
            //FELfele jobbra átóba nézzük, sort - oljuk és az oszlop indexet +oljuk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _poisitonTop = _picture.Sor;
            _poisitonTop--;
            _positionLeft++;

            if (_poisitonTop > 1 && _positionLeft < _pictureMap.GetLength(1) - 2)
            {
                if (_pictureMap[_poisitonTop, _positionLeft] == "X")
                {
                    _picture.Sor = _poisitonTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }


            }

            return _result;
        }
        private bool ThirdCheck()
        {
            //jobbra nézzük, oszlop indexet +oljuk
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft += 1;

            if (_positionLeft < _pictureMap.GetLength(1) - 2)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }



            return _result;
        }
        private bool FourthCheck()
        {
            //lefele jobb átlóba nézzük, oszlopot +oljuk mivel jobbra megyünk, sort +oljuk, mert lefelé megyünk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft++;
            _positionTop++;

            if (_positionLeft < _pictureMap.GetLength(1) - 2 && _positionTop < _pictureMap.GetLength(0) - 2)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }


            return _result;
        }
        private bool FiftCheck()
        {
            //lefele, sort +olunk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionTop++;

            if (_positionTop < _pictureMap.GetLength(0) - 2)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }


            return _result;
        }
        private bool SixthCheck()
        {
            //- olunk, és lefele +olunk.
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft--;
            _positionTop++;

            if (_positionTop < _pictureMap.GetLength(0) - 2 && _positionLeft > 1)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }


            return _result;
        }
        private bool SeventhCheck()
        {
            //csak balra megyünk..
            bool _result = false;
            int _positionLeft = _picture.Oszlop;
            int _positionTop = _picture.Sor;
            _positionLeft--;

            if (_positionLeft > 1)
            {
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
                    _result = true;
                }
            }


            return _result;
        }
        private bool EighthCheck()
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
                if (_pictureMap[_positionTop, _positionLeft] == "X")
                {
                    _picture.Sor = _positionTop;
                    _picture.Oszlop = _positionLeft;
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
