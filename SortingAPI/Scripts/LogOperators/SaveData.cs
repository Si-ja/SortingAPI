using System.IO;

namespace SortingAPI.Scripts.LogOperators
{
    public class SaveData
    {
        /// <summary>
        /// Save a string information to a file. We are dealing primarily only with .txt for now.
        /// </summary>
        /// <param name="filePath">Location where the file is with the extension.</param>
        /// <param name="contents">Contents that need to be written into the file.</param>
        public static void SaveDataToFile(string filePath, string contents)
        {
            File.WriteAllText(path: filePath, contents: contents);
        }
    }
}