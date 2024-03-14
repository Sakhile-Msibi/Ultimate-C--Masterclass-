namespace GameDataParser
{
    public class ReadFromFile
    {
        public void LoadGames(string path)
        {
            string? games = ReadToFile(path); ;
            List<string> list = new List<string>();


            games = games.TrimStart().TrimEnd();

            games = games.Substring(games.IndexOf("[") + 1, games.LastIndexOf("]") - 1);

            if (games.Contains("}"))
            {
                while (games.Contains("}"))
                {
                    list.Add(games.Substring(games.IndexOf("{") + 1, games.IndexOf("}") - 5));

                    try
                    {
                        games = games.Substring(games.IndexOf("}") + 2);
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            if (list.Count > 0)
            {
                foreach (string s in list)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No games are present in the input file.");
            }
        }

        public string ReadToFile(string path)
        {
            string fileContent = "";

            using (StreamReader reader = new StreamReader(path))
            {
                fileContent = reader.ReadToEnd();
            }

            return fileContent;
        }
    }
}