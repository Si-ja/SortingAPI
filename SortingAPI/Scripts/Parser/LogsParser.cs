namespace SortingAPI.Scripts.Parser
{
    public class LogsParser
    {
        /// <summary>
        /// A method that is ment to only parse logs
        /// that get saved with the current model.
        /// </summary>
        /// <param name="contents">Contents of the Log file that need to be parsed.
        /// Parsing as a rule happens on the semi-colon symbol ";". Any changes in how
        /// the logs are made, will have to be reflected in this method as well. </param>
        /// <returns></returns>
        public static string[] ParserLogs(string contents)
        {
            string[] usersData = contents.Split(";");
            return usersData;
        }
    }
}