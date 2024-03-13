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

                fileContent += $"--------------------------------*Start*------------------------------------------";
                fileContent += $"[{dateTime}]\n";
                fileContent += $"Exception message: {msg}\n";
                fileContent += $"Stack trace: {stackTrace}";
                fileContent += $"--------------------------------*End*--------------------------------------------";

                File.WriteAllText(fileName, fileContent);
            }
            else
            {
                fileContent += $"--------------------------------*Start*------------------------------------------";
                fileContent += $"[{dateTime}]\n";
                fileContent += $"Exception message: {msg}\n";
                fileContent += $"Stack trace: {stackTrace}";
                fileContent += $"--------------------------------*End*--------------------------------------------";

                File.WriteAllText(fileName, fileContent);
            }
        }
    }
}