using CookiesCookBook.Ingredients;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CookiesCookBook.Files
{
    public class ReadFromFile
    {
        public void DisplayExistsingRecipes(string path, bool isDisplayOldRecipes)
        {
            ListOfIngredients listOfIngredients = new ListOfIngredients();

            List<Ingredient> ingredients = listOfIngredients.GetListOfIngredients();

            string? recipe;
            int recipeNumber = 0;
            List<string> strings = new List<string>();
            string fileFormat = "json";
            List<List<string>> lists = new List<List<string>>();

            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((recipe = streamReader.ReadLine()) != null)
                {
                    recipe = recipe.TrimStart().TrimEnd();

                    if (path.Contains(fileFormat))
                    {
                        recipe = recipe.Substring(recipe.IndexOf("[") + 1, recipe.LastIndexOf("]") - 1);

                        if (recipe.Contains("]"))
                        {
                            while (recipe.Contains("]"))
                            {
                                lists.Add((recipe.Substring(recipe.IndexOf("[") + 1, recipe.IndexOf("]") - 1)).Split(',').ToList());

                                try
                                {
                                    recipe = recipe.Substring(recipe.IndexOf("]") + 2);
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            lists.Add(recipe.Split(',').ToList());
                        }
                    }
                    else
                    {
                        lists.Clear();
                        lists.Add(recipe.Split(',').ToList());
                    }

                    if (isDisplayOldRecipes)
                    {
                        foreach (List<string> list in lists)
                        {
                            recipeNumber++;
                            Console.WriteLine($"***** {recipeNumber} *****");

                            foreach (string s in list)
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
                            Console.WriteLine();
                        }
                    }
                }
            }

            if (!isDisplayOldRecipes)
            {
                foreach (string s in lists[^1])
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