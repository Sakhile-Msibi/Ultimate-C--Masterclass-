using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameDataParser
{
    public class FileValidation
    {
        public bool DoesFileExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }

        public bool IsFileDataValid(string fileName)
        {
            Logger logger = new Logger();

            if (string.IsNullOrWhiteSpace(fileName)) { return false; }
            fileName = fileName.Trim();
            if ((fileName.StartsWith("{") && fileName.EndsWith("}")) || //For object
                (fileName.StartsWith("[") && fileName.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(fileName);
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