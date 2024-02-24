using CookiesCookBook.Files;
using CookiesCookBook.Ingredients;
using System.Collections.Generic;
using System.IO;

namespace CookiesCookBook
{
    public class CookiesCookBookProgram
    {
        public void DisplayAvailableIngredients()
        {
            ListOfIngredients listOfIngredients = new ListOfIngredients();

            List<Ingredient> ingredients = listOfIngredients.GetListOfIngredients();

            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

            foreach (Ingredient ingredient1 in ingredients)
            {
                Console.WriteLine(ingredient1.ID + ". " + ingredient1.Name);
            }
        }

        public void DisplayAddIngredientMessage()
        {
            Console.WriteLine("Add an ingredient by it's ID or type anything else if finished.");
        }

        static void Main(string[] args)
        {
            CookiesCookBookProgram cookiesCookBookProgram = new CookiesCookBookProgram();
            ListOfIngredients listOfIngredients = new ListOfIngredients();
            ReadFromFile readFromFile = new ReadFromFile();
            SaveToFile saveToFile = new SaveToFile();
            const string FILENAME = "recipes";
            const FILEFORMAT Format = FILEFORMAT.txt;

            List<int> listOfRecipeIDs = listOfIngredients.GetListOfIngredientIDs(listOfIngredients.GetListOfIngredients());
            int recipeID = -1;
            bool isRecipeIDValid = false;
            List<int> listOfRecipeIDsToBeSaved = new List<int>();
            string fileName = $".\\{FILENAME}.{Format}";
            bool isDisplayOldRecipes = false;

            if (readFromFile.DoesrecipeExists())
            {
                isDisplayOldRecipes = true;

                Console.WriteLine("Existsing recipes are: ");
                Console.WriteLine();

                readFromFile.DisplayExistsingRecipes(fileName, isDisplayOldRecipes);
                Console.WriteLine();
            }

            cookiesCookBookProgram.DisplayAvailableIngredients();

            do
            {
                cookiesCookBookProgram.DisplayAddIngredientMessage();

                isRecipeIDValid = int.TryParse(Console.ReadLine(), out recipeID);

                
                if (isRecipeIDValid && listOfRecipeIDs.Contains(recipeID))
                {
                    listOfRecipeIDsToBeSaved.Add(recipeID);
                }
            } while (isRecipeIDValid);

            if (listOfRecipeIDsToBeSaved.Count > 0)
            {
                isDisplayOldRecipes = false;

                saveToFile.AddRecipeToAFile(listOfRecipeIDsToBeSaved, FILENAME, Format);

                Console.WriteLine("Recipe added:");

                readFromFile.DisplayExistsingRecipes(fileName, isDisplayOldRecipes);
            }
            else
            {
                Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}