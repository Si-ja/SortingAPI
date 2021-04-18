using Microsoft.AspNetCore.Mvc;
using SortingAPI.Models;
using SortingAPI.Scripts.LogOperators;
using SortingAPI.Scripts.Parser;
using System.Collections.Generic;
using System.Linq;

namespace SortingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController : ControllerBase
    {

        private readonly string pathToLogs = "UserLogs\\log.txt";


        // A path to retrieve the last user inputs that were given to the API
        [HttpGet]
        public Logs Get()
        {
            // Load the data that we last operated with
            string contents = LoadData.LoadDataFromFile(filePath: pathToLogs);

            // The data has to be partially parsed
            // The first value is always the original user's input; second is the sorted values
            string[] parsedContents = LogsParser.ParserLogs(contents: contents);

            // Create an object that will be returned with all the logs
            Logs logs = new();
            logs.OriginalInput = parsedContents[0];
            logs.SortedOutput = parsedContents[1];

            return logs;
        }

        // Get a string of hopefully values from the user and pass it to the classes that can sort them
        [HttpGet("{values}")]
        public IEnumerable<SortingAnswers> Get(string values)
        {
            // Prepare the initial conditions for what data is being stored and what algorithms we will use to sort it
            // We will also want to save the sorted information, but only once, no matter from which called algorithm.
            DataManipulator dataHolder = new(values);
            string[] sorters = new string[] { "BubbleSort", "SelectionSort" };
            bool savedOnce = false;

            // Iterate through the sorters we want to apply and collect data from transformations we can make with them
            AnswersCollector answersCollector = new();
            for (int i = 0; i < sorters.Length; i++)
            {
                SortingAnswers sortingAnswers = new();
                // Sort the data, populate the sortingAnswers object and save it in the answersCollector object
                dataHolder.SortValues(method: sorters[i]);

                // Check if we have already saved the contents of the sorted information - if so, just move one
                if (!savedOnce)
                {
                    // If we haven't saved the contents, let's save them.
                    string currentContents = $"{dataHolder.OriginalData};{dataHolder.OutputData}";
                    SaveData.SaveDataToFile(filePath: this.pathToLogs, contents: currentContents);
                    savedOnce = true;
                }

                sortingAnswers.Data = values;
                sortingAnswers.Sorted = dataHolder.OutputData;
                sortingAnswers.Algorithm = dataHolder.SortingMethod;
                sortingAnswers.Time = dataHolder.ElapsedTime;

                answersCollector.AnswersCollection.Add(item: sortingAnswers);
            }

            // Now that we have all of our data prepared, we can display it to the user
            // From the AnswersCollection we can pull each object with its own unique values
            // These values can be displayed to the user. 
            return Enumerable.Range(1, sorters.Length).Select(index => new SortingAnswers
            {
                Data = answersCollector.AnswersCollection[index - 1].Data,
                Sorted = answersCollector.AnswersCollection[index - 1].Sorted,
                Algorithm = answersCollector.AnswersCollection[index - 1].Algorithm,
                Time = answersCollector.AnswersCollection[index - 1].Time
            })
            .ToArray();
        }
    }
}