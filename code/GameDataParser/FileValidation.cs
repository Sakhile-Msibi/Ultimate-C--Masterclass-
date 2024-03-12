namespace GameDataParser
{
    public class FileValidation
    {
        public static bool DoesFileExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }
    }
}