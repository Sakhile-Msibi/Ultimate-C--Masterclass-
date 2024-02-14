namespace CookiesCookBook
{
    public class ReadFromFile
    {
        public string ReadFile(string path) => File.ReadAllText(path);

        public bool DoesrecipeExists()
        {
            string txtPath = @".\recipes.txt";
            string jsonPath = @".\recipes.json";

            if (File.Exists(txtPath))
            {
                string fileContent = File.ReadAllText(txtPath);

                return (fileContent.Length > 0);
            }

            if (File.Exists(jsonPath))
            {
                string fileContent = File.ReadAllText(jsonPath);

                return (fileContent.Length > 0);
            }

            return false;
        }
    }
}