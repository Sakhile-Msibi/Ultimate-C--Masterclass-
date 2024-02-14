using CookiesCookBook.Files;
using CookiesCookBook.Ingredients;
using System.Collections.Generic;

namespace CookiesCookBook
{
    public class CookiesCookBookProgram
    {
        public void DisplayExistsingRecipes()
        {
            

        }

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

            List<int> listOfRecipeIDs = listOfIngredients.GetListOfIngredientIDs(listOfIngredients.GetListOfIngredients());
            int recipeID = -1;
            bool isRecipeIDValid = false;

            do
            {
                if (readFromFile.DoesrecipeExists())
                {
                    Console.WriteLine("Existsing recipes are: ");

                    Console.WriteLine("***** {reciprNumber} *****");

                    cookiesCookBookProgram.DisplayExistsingRecipes();
                }

                cookiesCookBookProgram.DisplayAvailableIngredients();

                do
                {
                    cookiesCookBookProgram.DisplayAddIngredientMessage();

                    isRecipeIDValid = int.TryParse(Console.ReadLine(), out recipeID);

                    if (isRecipeIDValid && listOfRecipeIDs.Contains(recipeID))
                    {
                        AddRecipeToAFile();
                    }
                } while (isRecipeIDValid && listOfRecipeIDs.Contains(recipeID));

                if (readFromFile.DoesrecipeExists())
                {
                    Console.WriteLine("Recipe added:");

                    cookiesCookBookProgram.DisplayExistsingRecipes();
                }

            } while ();


            Console.ReadKey();
        }
    }
}