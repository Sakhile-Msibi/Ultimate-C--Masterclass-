using System.Xml.Linq;

namespace GameDataParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            App();

            Console.ReadKey();
        }

        public static void App()
        {
            bool isNameValid = false;
            bool isFileDataValid = false;
            bool isJsonFileNotEmpty = false;
            do
            {
                Console.WriteLine("Enter the name of the file you want to read:");

                string? fileNameEnteredByAUser = Console.ReadLine();

                if (!string.IsNullOrEmpty(fileNameEnteredByAUser))
                {
                    isNameValid = DoesFileExist(fileNameEnteredByAUser);

                    if (isNameValid)
                    {
                        isFileDataValid = IsFileDataValid();
                    }
                    else
                    {
                        Console.WriteLine("File not found");
                        isNameValid = false;
                        break;
                    }
                }
                else
                {
                    if (fileNameEnteredByAUser == "")
                    {
                        Console.WriteLine("File name cannot be empty.");
                    }
                    else if (fileNameEnteredByAUser == null)
                    {
                        Console.WriteLine("File name cannot be null.");
                    }

                    isNameValid = false;
                    break;
                }

                if (isFileDataValid)
                {
                    isJsonFileNotEmpty = IsJsonFileNotEmpty();

                    if (isJsonFileNotEmpty)
                    {
                        LoadGames();
                    }
                    else
                    {
                        Console.WriteLine("No games are present in the input file.");
                    }
                }
                else
                {
                    PrintInvalidFormatMessage();
                }

            } while (!isNameValid);
        }
    }
}