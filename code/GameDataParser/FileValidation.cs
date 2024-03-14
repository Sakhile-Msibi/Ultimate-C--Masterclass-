using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameDataParser
{
    public class FileValidation
    {
        public bool DoesFileExist(string filepath)
        {
            if (File.Exists(filepath))
            {
                return true;
            }

            return false;
        }

        public bool IsFileDataValid(string fileName)
        {
            Logger logger = new Logger();

            string fileContent = "";

            using (StreamReader reader = new StreamReader(fileName))
            {
                fileContent = reader.ReadToEnd();
            }

                if (string.IsNullOrWhiteSpace(fileContent)) { return false; }
            fileContent = fileContent.Trim();
            if ((fileContent.StartsWith("{") && fileContent.EndsWith("}")) || //For object
                (fileContent.StartsWith("[") && fileContent.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(fileContent);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    logger.LogException(jex);

                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    logger.LogException(ex);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}