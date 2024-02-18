using System.Text.Json;

namespace CookiesCookBook.Files
{
    public class SaveToFile
    {
        public void AddRecipeToAFile(List<int> recipes, string FILENAME, FILEFORMAT Format)
        {
            ReadFromFile readFromFile = new ReadFromFile();

            string recipe = "";

            string fileName = $".\\{FILENAME}.{Format}";

            if (readFromFile.DoesrecipeExists())
            {
                recipe = File.ReadAllText(fileName) + "\n";
            }

            if (Format == FILEFORMAT.json)
            {
                File.WriteAllText(fileName, JsonSerializer.Serialize(recipes));

                recipe += File.ReadAllText(fileName);
            }
            else if (Format == FILEFORMAT.txt) 
            {
                recipe += string.Join(',', recipes);
                File.WriteAllText(fileName, recipe);
            }
        }
    }
}