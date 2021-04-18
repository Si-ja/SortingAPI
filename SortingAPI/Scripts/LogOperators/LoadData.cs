using System.IO;

namespace SortingAPI.Scripts.LogOperators
{
    public class LoadData
    {
        /// <summary>
        /// Load data from a file. We are dealing primarily only with .txt for now.
        /// </summary>
        /// <param name="filePath">Location where the file is, with extension.</param>
        /// <returns>Contents of the file loaded</returns>
        public static string LoadDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // If the file doesn't exist we will load to the variable contents
                // That we would save if the file never existed.
                string contents = "Nothing Entered Yet;Nothing Entered Yet";
                return contents;
            }
            else
            {
                // If the file however exists - try to load data from it
                string contents = File.ReadAllText(filePath);
                return contents;
            }
        }
    }
}