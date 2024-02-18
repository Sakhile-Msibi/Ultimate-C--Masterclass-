using CookiesCookBook.Ingredients;
using System.IO;

namespace CookiesCookBook.Files
{
    public class ReadFromFile
    {
        public void DisplayExistsingRecipes(string path)
        {
            ListOfIngredients listOfIngredients = new ListOfIngredients();

            List<Ingredient> ingredients = listOfIngredients.GetListOfIngredients();

            string recipe = File.ReadAllText(path);

            string[] strings = recipe.Split(',');

            foreach (string s in strings)
            {
                foreach (Ingredient ingredient1 in ingredients)
                {
                    if (Convert.ToInt32(s) == ingredient1.ID)
                    {
                        Console.WriteLine(ingredient1.Name + "." + ingredient1.PreparationInstructions);
                        break;
                    }
                }
            }
        }

        public void DisplaySavedIngredients()
        {
            ListOfIngredients listOfIngredients = new ListOfIngredients();

            List<Ingredient> ingredients = listOfIngredients.GetListOfIngredients();

            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

            foreach (Ingredient ingredient1 in ingredients)
            {
                Console.WriteLine(ingredient1.ID + ". " + ingredient1.Name);
            }
        }

        public bool DoesrecipeExists()
        {
            string txtPath = @".\recipes.txt";
            string jsonPath = @".\recipes.json";

            if (File.Exists(txtPath))
            {
                string fileContent = File.ReadAllText(txtPath);

                return fileContent.Length > 0;
            }

            if (File.Exists(jsonPath))
            {
                string fileContent = File.ReadAllText(jsonPath);

                return fileContent.Length > 0;
            }

            return false;
        }
    }
}