using System.Text.Json;
using System.Xml;

namespace CookiesCookBook.Files
{
    public class SaveToFile
    {
        public void AddRecipeToAFile(List<int> recipes, string FILENAME, FILEFORMAT Format)
        {
            ReadFromFile readFromFile = new ReadFromFile();

            string fileName = $".\\{FILENAME}.{Format}";
            string recipe = "";

            if (readFromFile.DoesrecipeExists())
            {
                recipe = File.ReadAllText(fileName) + "\n";
            }

            if (Format == FILEFORMAT.json)
            {
                List<int> recipeList = new List<int>();
                List<List<int>> lists = new List<List<int>>();

                if (readFromFile.DoesrecipeExists())
                {
                    lists = convertstringsToIntList(recipe);
                    lists.Add(recipes);

                    File.WriteAllText(fileName, JsonSerializer.Serialize(lists));
                }
                else
                {
                    File.WriteAllText(fileName, JsonSerializer.Serialize(recipes));
                }
            }
            else if (Format == FILEFORMAT.txt) 
            {
                recipe += string.Join(',', recipes);

                File.WriteAllText(fileName, recipe);
            }
        }

        public List<List<int>> convertstringsToIntList(string file)
        {
            List<string> strings = new List<string>();
            List<List<int>> lists = new List<List<int>>();


            file = file.Substring(file.IndexOf("[") + 1, file.LastIndexOf("]") - 1);

            if (file.Contains("]"))
            {
                while (file.Contains("]"))
                {
                    List<int> recipeList = new List<int>();
                    strings = (file.Substring(file.IndexOf("[") + 1, file.IndexOf("]") - 1)).Split(',').ToList();

                    foreach (string s in strings)
                    {
                        recipeList.Add(Convert.ToInt32(s));
                    }

                    lists.Add(recipeList);

                    try
                    {
                        file = file.Substring(file.IndexOf("]") + 2);
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            else
            {
                List<int> recipeList = new List<int>();

                strings = file.Split(',').ToList();

                foreach (string s in strings)
                {
                    recipeList.Add(Convert.ToInt32(s));
                }

                lists.Add(recipeList);
            }

            return lists;
        }
    }
}