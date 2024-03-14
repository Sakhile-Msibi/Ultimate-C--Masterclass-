namespace GameDataParser
{
    public class Logger
    {
        public void LogException(Exception Ex)
        {
            FileValidation fileValidation = new FileValidation();

            DateTime dateTime = DateTime.Now;
            string msg = Ex.Message.ToString();
            string stackTrace = Ex.StackTrace.ToString();
            string fileName = $".\\log.txt";
            string fileContent = string.Empty;

            if (fileValidation.DoesFileExist(fileName))
            {
                fileContent = File.ReadAllText(fileName) + "\n";

                fileContent += $"--------------------------------*Start*------------------------------------------\n";
                fileContent += $"[{dateTime}]\n\n";
                fileContent += $"Exception message:\n {msg}\n\n";
                fileContent += $"Stack trace:\n {stackTrace}\n";
                fileContent += $"--------------------------------*End*--------------------------------------------";

                File.WriteAllText(fileName, fileContent);
            }
            else
            {
                fileContent += $"--------------------------------*Start*------------------------------------------\n";
                fileContent += $"[{dateTime}]\n\n";
                fileContent += $"Exception message:\n {msg}\n\n";
                fileContent += $"Stack trace:\n {stackTrace}\n";
                fileContent += $"--------------------------------*End*--------------------------------------------";

                File.WriteAllText(fileName, fileContent);
            }
        }
    }
}