using System.Xml.Linq;

namespace GameDataParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            App();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        public static void App()
        {
            FileValidation fileValidation = new FileValidation();
            ReadFromFile readFromFile = new ReadFromFile();

            bool isNameValid = false;
            bool isFileDataValid = false;
            string filePath = string.Empty;

            do
            {
                Console.WriteLine("Enter the name of the file you want to read:");

                string? fileNameEnteredByAUser = Console.ReadLine();

                if (!string.IsNullOrEmpty(fileNameEnteredByAUser))
                {
                    filePath = $".\\{fileNameEnteredByAUser}";

                    isNameValid = fileValidation.DoesFileExist(filePath);

                    if (isNameValid)
                    {
                        isFileDataValid = fileValidation.IsFileDataValid(filePath);
                    }
                    else
                    {
                        Console.WriteLine("File not found");
                        isNameValid = false;
                        continue;
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
                    continue;
                }

                if (isFileDataValid)
                {
                    readFromFile.LoadGames(filePath);
                }
                else
                {
                    PrintInvalidFormatMessage(fileNameEnteredByAUser);
                }

            } while (!isNameValid);
        }

        public static void PrintInvalidFormatMessage(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in the {fileName}  was not in a valid format. JSON body:\n");
            Console.WriteLine(File.ReadAllText(fileName));
            Console.WriteLine("\nSorry! The application has experienced an unexpected error and will have to be closed.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}