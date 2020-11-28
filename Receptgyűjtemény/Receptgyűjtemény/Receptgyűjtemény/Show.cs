using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receptgyűjtemény
{
    static class Show
    {
        public static string ShowMenu()
        {
            Console.WriteLine("(0) - Kilépés a programból");
            Console.WriteLine("(1) - Recept hozzáadása");
            Console.WriteLine("(2) - Recept módosítása");
            Console.WriteLine("(3) - Recept törlése");
            Console.WriteLine("(4) - Keresés a receptek között.");
            Console.WriteLine("(5) - Receptek listázása..");
            Console.Write("Kérlek írd be a választott opciót: ");
            string options = Console.ReadLine();
            while (options != "0" && options != "1" && options != "2" && options != "3" && options != "4" && options != "5")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Hibás bemenet, add meg újra a választott opciót a listából:");
                Console.ResetColor();
                options = Console.ReadLine();
            }
            return options;
        }
        public static Recipes AddANewRecipe()
        {
            Console.Clear();
            Console.WriteLine("Az 1-es opciót választottad, kérlek az alábbi bemeneteket add meg enterrel elválasztva: ");
            Console.Write("Recept neve: ");
            string _name = Console.ReadLine();
            Console.Write("Recept típuse(leves, főzelék, deszert, főétel, előétel): ");
            string _type = Console.ReadLine();
            Console.Write("Hozzávalók száma: ");
            int _ingredientNum = int.Parse(Console.ReadLine());
            Console.Write("Hozzávalók: \n");
            string[] _ingredients = new string[_ingredientNum];
            for (int i = 0; i < _ingredientNum; i++)
            {
                Console.Write($"{i + 1}. :");
                _ingredients[i] = Console.ReadLine();
            }
            Console.Write("Elékszítés módja: ");
            string _prepataion = Console.ReadLine();


            Recipes recipe_ = new Recipes(_name, _type, _ingredients, _prepataion);

            return recipe_;
        }
        public static string SearchOPtions()
        {
            Console.WriteLine("(1) - Név alapján keresés");
            Console.WriteLine("(2) - Típus alapján keresés");
            Console.WriteLine("(3) - Hozzávaló alapján keresés");
            Console.Write("Kérlek írd be a választott opciót: ");
            string options = Console.ReadLine();
            while (options != "1" && options != "2" && options != "3")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Hibás bemenet, add meg újra a választott opciót a listából:");
                Console.ResetColor();
                options = Console.ReadLine();
            }
            return options;
        }

        public static int ChooseWhatYouWouldLikeToModify(Recipes[] recipes_)
        {
            Console.Clear();
            Console.WriteLine("A módosítást választottad\nListázom a tárolt recepteket, kérlek add meg annak az indexét amelyiket módosítani szeretnéd.");

            for (int i = 0; i < recipes_.Length; i++)
            {
                Console.WriteLine($"{i}\t-{recipes_[i].Name}");
            }
            Console.Write("\nÍrd be a választott recept indexét: ");
            return int.Parse(Console.ReadLine());
        }
        public static Recipes HelpToModify(int index, Recipes[] recipes_)
        {
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("A recept régi neve " + recipes_[index].Name);
            Console.Write("Add meg a recept új nevét: ");
            string newName = Console.ReadLine();

            Console.WriteLine("_________________________________________________________");

            Console.WriteLine("A recept régi kategóriája " + recipes_[index].Type);
            Console.Write("Add meg a recept új kategóriáját / típusát: ");
            string newType = Console.ReadLine();

            Console.WriteLine("_________________________________________________________");

            Console.WriteLine("A recept régebbi hozzávalói: ");
            for (int i = 0; i < recipes_[index].Ingredient.Length; i++)
            {
                Console.WriteLine($"{i + 1}. :{recipes_[index].Ingredient[i]}");
            }
            Console.Write("Módosított hozzávalók új mennyisége:");
            int ingredientCount = int.Parse(Console.ReadLine());
            string[] _newIngredients = new string[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"{i + 1}. : ");
                _newIngredients[i] = Console.ReadLine();
            }
            Console.WriteLine("_________________________________________________________");

            Console.WriteLine("A recept régi leírása: ");
            Console.WriteLine(recipes_[index].Preparation);

            Console.WriteLine("Add meg a recept új leírását: ");
            string newPreparation = Console.ReadLine();

            Recipes newRecipe = new Recipes(newName, newType, _newIngredients, newPreparation);
            return newRecipe;
        }

        public static int ChooseWhatYouWouldLikeToRemove(Recipes[] recipes_)
        {
            Console.Clear();
            Console.WriteLine("A törlést választottad\nListázom a tárolt recepteket, kérlek add meg annak az indexét amelyiket törölni szeretnéd.");

            for (int i = 0; i < recipes_.Length; i++)
            {
                Console.WriteLine($"{i}\t-{recipes_[i].Name}");
            }
            Console.Write("\nÍrd be a választott recept indexét: ");
            return int.Parse(Console.ReadLine());
        }


        public static void ListRecipe(Recipes[] _recipes)
        {
            int youAreOnThisPage = 1;
            for (int i = 0; i < _recipes.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("Receptek listázását választottad, enterrel tovább haladhatsz..");
                Console.WriteLine($"Jelenlegi oldal: {youAreOnThisPage} / {_recipes.Length}");

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(_recipes[i].Name);
                Console.WriteLine(_recipes[i].Type);
                Console.WriteLine("Hozzávalók:");
                for (int j = 0; j < _recipes[i].Ingredient.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. : {_recipes[i].Ingredient[j]}");
                }
                Console.WriteLine("Elékszítés módja:");
                Console.WriteLine(_recipes[i].Preparation);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.ReadLine();
                youAreOnThisPage++;
            }
            Console.WriteLine("Enter lenyomásával újra a menüben leszel..");
        }

    }

}
