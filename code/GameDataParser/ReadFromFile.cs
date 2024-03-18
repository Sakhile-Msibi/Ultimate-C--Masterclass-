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
                    try
                    {
                        list.Add(games.Substring(games.IndexOf("{") + 1, games.IndexOf("}") - 5));
                    }
                    catch { }

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
                Console.WriteLine("\nLoaded games are:");

                foreach (string s in list)
                {
                    string[] strings = s.Split(',');
                    int year = -1;
                    string rating = "";
                    string movieName = "";

                    for (int i = 0; i < strings.Length; i++)
                    {
                        int value;
                        string str = strings[i].Substring(strings[i].IndexOf(":") + 1);
                        str = str.Trim();
                        
                        if (int.TryParse(str, out value))
                        {
                            year = value;
                        }
                        else
                        {

                            try
                            {
                                str = str.Substring(str.IndexOf("\"") + 1, str.LastIndexOf("\"") - 1);
                                movieName = str;
                            }
                            catch
                            {
                                rating = str;
                            }
                        }
                    }

                    Console.WriteLine($"{movieName}, released in {year}, rating: {rating}");
                }
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