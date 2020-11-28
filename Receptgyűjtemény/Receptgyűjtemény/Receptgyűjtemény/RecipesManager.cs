using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Receptgyűjtemény
{
    class RecipesMananger
    {
        private Recipes[] _recipes;

        public RecipesMananger()
        {
            _recipes = new Recipes[0];
        }


        public void Recipe()
        {
            LoadAllRecipe();
            string _options = Menu();
            do
            {
                if (_options == "0")
                {
                    Console.WriteLine("Viszlát! Recepteket elmentjük..");
                    //recepteket majd ments el és lépj ki..
                }
                else if (_options == "1")
                {
                    //hozzákell adni!
                    NewRecipe();
                    WriteFileIfYouAddRecipe();
                    LoadAllRecipe();
                    Console.WriteLine("Recept hozzáadva, enter lonyomásával újra a menüben leszel..");
                }
                else if (_options == "2")
                {
                    //módosíts egy receptet!
                    ModifyRecipe();
                    LoadAllRecipe();
                }
                else if (_options == "3")
                {
                    //törölnöd kell
                    RemoveRecipe();
                    LoadAllRecipe();
                }
                else if (_options == "4")
                {
                    //keresni kell, név, hozzávaló vagy típus alapján
                    SearchMode();
                }
                else if (_options == "5")
                {
                    //listázd a recepteket!
                    Show.ListRecipe(_recipes);

                }

                Console.ReadLine();
                _options = Menu();

            } while (_options != "0");
            Console.WriteLine("Kilépéshez nyomjt entert..");
            Console.ReadLine();


        }

        //_____________________________________
        private void LoadAllRecipe()
        {
            StreamReader sr = new StreamReader("receptek.txt");

            _recipes = new Recipes[RecipeCount()];

            int counter = 0;
            while (!sr.EndOfStream)
            {
                string csillagTeszt = "";
                string _line = "";

                while (csillagTeszt != "***")
                {
                    string _line_ = sr.ReadLine();
                    if (_line_ != "***")
                    {
                        _line += _line_;
                    }
                    else
                    {
                        csillagTeszt = _line_;
                    }
                }
                string[] split = _line.Split('|');
                string[] split2 = split[2].Split('_');

                Recipes recipe_ = new Recipes(split[0], split[1], split2, split[3]);
                _recipes[counter] = recipe_;
                counter++;
            }
            sr.Close();

        }

        private int RecipeCount()
        {
            StreamReader sr = new StreamReader("receptek.txt");
            int counter = 0;
            while (!sr.EndOfStream)
            {
                string csillagTeszt = "";
                string _line = "";

                while (csillagTeszt != "***")
                {
                    string _line_ = sr.ReadLine();
                    if (_line_ != "***")
                    {
                        _line += _line_;
                    }
                    else
                    {
                        csillagTeszt = _line_;
                    }
                }
                counter++;
            }
            sr.Close();
            return counter;
        }

        private string Menu()
        {
            Console.Clear();
            return Show.ShowMenu();
        }


        //_____________________________________
        private void AddRecipe(Recipes recipe_)
        {
            //Ugyanarra a helyre mutatnak, referencia nem veszik el.
            Recipes[] tmp = _recipes;
            _recipes = new Recipes[tmp.Length + 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                _recipes[i] = tmp[i];
            }
            _recipes[_recipes.Length - 1] = recipe_;
        }
        private void NewRecipe()
        {
            Recipes recipe_ = Show.AddANewRecipe();
            AddRecipe(recipe_);
        }
        private void WriteFileIfYouAddRecipe()
        {
            StreamWriter sw = new StreamWriter("receptek.txt", false);

            for (int i = 0; i < _recipes.Length; i++)
            {
                sw.WriteLine(_recipes[i].Name + "|");
                sw.WriteLine(_recipes[i].Type + "|");
                for (int j = 0; j < _recipes[i].Ingredient.Length; j++)
                {
                    if (j == _recipes[i].Ingredient.Length - 1)
                    {
                        sw.WriteLine(_recipes[i].Ingredient[j]);
                    }
                    else
                    {
                        sw.WriteLine(_recipes[i].Ingredient[j] + "_");
                    }
                }
                sw.WriteLine("|" + _recipes[i].Preparation);
                sw.WriteLine("***");
            }
            sw.Close();
        }


        //_____________________________________

        private void SearchMode()
        {
            Console.Clear();
            string _optinSearch = Show.SearchOPtions();

            if (_optinSearch == "1")
            {
                //név alapján
                NameSerch();

            }
            else if (_optinSearch == "2")
            {
                //típus
                TypeSearch();
            }
            else
            {
                //hozzávaló
                IngredientSearch();
            }
            Console.WriteLine("Nyomjt entert, hogy újra a menüben találd magad :D..");
        }
        private void NameSerch()
        {
            int[] allIndex = new int[_recipes.Length];
            AllMinusOne(ref allIndex);


            Console.Write("Kérlek add meg a nevet, amin keresel: ");
            string _recipeName = Console.ReadLine();
            StreamReader sr = new StreamReader("receptek.txt");

            int counter = 0;

            while (!sr.EndOfStream)
            {
                string csillagTeszt = "";
                string _line = "";

                while (csillagTeszt != "***")
                {
                    string _line_ = sr.ReadLine();
                    if (_line_ != "***")
                    {
                        _line += _line_;
                    }
                    else
                    {
                        csillagTeszt = _line_;
                    }
                }
                string[] split = _line.Split('|');

                //a 0-as a név
                if (_recipeName == split[0])
                {
                    allIndex[counter] = counter;
                }
                counter++;
            }
            sr.Close();
            WriteRecipesAtConsoleWhatYouSearched(allIndex);

        }
        private void TypeSearch()
        {
            int[] allIndex = new int[_recipes.Length];
            AllMinusOne(ref allIndex);
            Console.Write("Kérlek add meg az étel fajtáját: ");
            string _recipeType = Console.ReadLine();
            StreamReader sr = new StreamReader("receptek.txt");

            int counter = 0;

            while (!sr.EndOfStream)
            {
                string csillagTeszt = "";
                string _line = "";

                while (csillagTeszt != "***")
                {
                    string _line_ = sr.ReadLine();
                    if (_line_ != "***")
                    {
                        _line += _line_;
                    }
                    else
                    {
                        csillagTeszt = _line_;
                    }
                }
                string[] split = _line.Split('|');

                //a 1-as a típus
                if (_recipeType == split[1])
                {
                    allIndex[counter] = counter;
                }
                counter++;
            }
            sr.Close();
            WriteRecipesAtConsoleWhatYouSearched(allIndex);
        }
        private void IngredientSearch()
        {
            int[] allIndex = new int[_recipes.Length];
            AllMinusOne(ref allIndex);


            Console.Write("Kérlek add meg a hozzávlókat(ha több is van, akkor vesszővel tagold!!), amin keresel: ");
            string _ingredientsWhatyouwillsplit = Console.ReadLine();
            string[] _ingredients = _ingredientsWhatyouwillsplit.Split(',');

            StreamReader sr = new StreamReader("receptek.txt");
            int counter = 0;
            while (!sr.EndOfStream)
            {
                string csillagTeszt = "";
                string _line = "";

                while (csillagTeszt != "***")
                {
                    string _line_ = sr.ReadLine();
                    if (_line_ != "***")
                    {
                        _line += _line_;
                    }
                    else
                    {
                        csillagTeszt = _line_;
                    }
                }
                string[] split = _line.Split('|');
                string[] split2 = split[2].Split('_');
                //a 2-es a hozzávalók
                if (HelpSearchIngredient(_ingredients, split2))
                {
                    allIndex[counter] = counter;
                }
                counter++;
            }
            sr.Close();
            WriteRecipesAtConsoleWhatYouSearched(allIndex);
        }
        private bool HelpSearchIngredient(string[] yourSearchThat_, string[] _actual)
        {
            bool findIt = true;

            for (int i = 0; i < yourSearchThat_.Length; i++)
            {

                bool findOne = false;
                for (int j = 0; j < _actual.Length; j++)
                {
                    if (_actual[j].ToUpper().Contains(yourSearchThat_[i].ToUpper()))
                    {
                        findOne = true;
                    }


                }
                //ha valamelyik keresett hozzávaló nincsen benne az aktuális recept hozzávalóiban, akkor az nem jó!
                if (findOne != true)
                {
                    findIt = false;
                }

            }
            return findIt;
        }


        private void WriteRecipesAtConsoleWhatYouSearched(int[] allIndex)
        {
            for (int i = 0; i < allIndex.Length; i++)
            {
                if (allIndex[i] != -1)
                {
                    Console.WriteLine("Recept neve: " + _recipes[i].Name);
                    Console.WriteLine("Recept típusa: " + _recipes[i].Type);
                    Console.WriteLine("Hozzávalók: ");
                    for (int j = 0; j < _recipes[i].Ingredient.Length; j++)
                    {
                        Console.WriteLine($"{j + 1}. : {_recipes[i].Ingredient[j]}");
                    }
                    Console.WriteLine("Elkészítési mód: " + _recipes[i].Preparation);
                }
            }
        }
        private void AllMinusOne(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
        }
        //_____________________________________

        private void ModifyRecipe()
        {
            int _options = Show.ChooseWhatYouWouldLikeToModify(_recipes);
            Recipes newRecipe = Show.HelpToModify(_options, _recipes);
            WriteModifyRecipe(_options, newRecipe);
            Console.WriteLine("Recpteded módosítottad, enter leütésével visszamehetsz a menübe!");
        }
        private void WriteModifyRecipe(int index, Recipes newrecipe)
        {
            StreamWriter sw = new StreamWriter("receptek.txt", false);

            for (int i = 0; i < _recipes.Length; i++)
            {
                if (i != index)
                {
                    sw.WriteLine(_recipes[i].Name + "|");
                    sw.WriteLine(_recipes[i].Type + "|");
                    for (int j = 0; j < _recipes[i].Ingredient.Length; j++)
                    {
                        if (j == _recipes[i].Ingredient.Length - 1)
                        {
                            sw.WriteLine(_recipes[i].Ingredient[j]);
                        }
                        else
                        {
                            sw.WriteLine(_recipes[i].Ingredient[j] + "_");
                        }
                    }
                    sw.WriteLine("|" + _recipes[i].Preparation);
                    sw.WriteLine("***");
                }
            }

            sw.WriteLine(newrecipe.Name + "|");
            sw.WriteLine(newrecipe.Type + "|");
            for (int j = 0; j < newrecipe.Ingredient.Length; j++)
            {
                if (j == newrecipe.Ingredient.Length - 1)
                {
                    sw.WriteLine(newrecipe.Ingredient[j]);
                }
                else
                {
                    sw.WriteLine(newrecipe.Ingredient[j] + "_");
                }
            }
            sw.WriteLine("|" + newrecipe.Preparation);
            sw.WriteLine("***");
            sw.Close();
        }

        //_____________________________________

        private void RemoveRecipe()
        {
            int _options = Show.ChooseWhatYouWouldLikeToRemove(_recipes);
            //megvan az index, amit törölni szeretnének, annyi a dolgunk, hogy kiíratjuk enélkül az index nélkül..
            RemoveThisRecipe(_options);
            Console.WriteLine("Választott receptedet töröltük, a menübe téréshez kérlek nyomj entert");
        }
        private void RemoveThisRecipe(int index)
        {
            StreamWriter sw = new StreamWriter("receptek.txt", false);

            for (int i = 0; i < _recipes.Length; i++)
            {
                if (i != index)
                {
                    sw.WriteLine(_recipes[i].Name + "|");
                    sw.WriteLine(_recipes[i].Type + "|");
                    for (int j = 0; j < _recipes[i].Ingredient.Length; j++)
                    {
                        if (j == _recipes[i].Ingredient.Length - 1)
                        {
                            sw.WriteLine(_recipes[i].Ingredient[j]);
                        }
                        else
                        {
                            sw.WriteLine(_recipes[i].Ingredient[j] + "_");
                        }
                    }
                    sw.WriteLine("|" + _recipes[i].Preparation);
                    sw.WriteLine("***");
                }
            }

            sw.Close();
        }


        //_____________________________________
    }

}
