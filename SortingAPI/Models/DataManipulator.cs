using System.Diagnostics;
using SortingAPI.Scripts.Parser;
using SortingAPI.Scripts.Sorters;

namespace SortingAPI.Models
{
    public class DataManipulator
    {
        public string OriginalData { get; set; }

        // Data that will be used for returning info to the user
        public string OutputData { get; set; }
        public double ElapsedTime { get; set; }
        public string SortingMethod { get; set; }

        // Data that will help keep internal consistency for certain operations to work
        // This will not be seen by the user
        private readonly int[] _originalValues;
        private int[] _sortedValues;
        

        /// <summary>
        /// Initiate the constructor and prepare all the data
        /// that we will work with further on.
        /// </summary>
        /// <param name="originalData">Original data entered by the user.
        /// InputsParser will take care of verifiying whether the data is
        /// clean and how to work with it further.</param>
        public DataManipulator(string originalData)
        {
            this.OriginalData = originalData;
            InputsParser inputsParser = new(originalData);
            this._originalValues = inputsParser.GetParsedValues();
        }

        /// <summary>
        /// Convert an array of integers into a readable string.
        /// For this case specifically a conversion happens of user
        /// inputs, that have already been sorted out.
        /// </summary>
        private void ArrayToString()
        {
            this.OutputData = string.Join(" ", this._sortedValues);
        }

        /// <summary>
        /// Sort values inputted by the user.
        /// Select from the list of methods ment for sorting
        /// a type to use. The values processed
        /// are saved within the object, and can be reused
        /// to populate data in another object that will present
        /// the outputs to the user in an API call.
        /// </summary>
        /// <param name="method">A list of methods to chose from which
        /// you would like to pick how the data should be sorted.
        /// Options: ["BubbleSort", "SelectionSort"]. If nothing from the
        /// given list will be selected, by default the Selection Sort will
        /// be used.</param>
        public void SortValues(string method)
        {
            // We allso want to keep track of how long certain executions/sortings take place
            Stopwatch stopwatch = new();
            switch (method)
            {
                case "BubbleSort":
                    this.SortingMethod = "Bubble Sort";
                    stopwatch.Start();
                    this._sortedValues = BubbleSort.Sort(unsortedValues: this._originalValues);
                    stopwatch.Stop();
                    this.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

                    // Make sure we have a string representation of the sorted values as well
                    this.ArrayToString();
                    break;

                case "SelectionSort":
                    this.SortingMethod = "Selection Sort";
                    stopwatch.Start();
                    this._sortedValues = SelectionSort.Sort(unsortedValues: this._originalValues);
                    stopwatch.Stop();
                    this.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

                    // Make sure we have a string representation of the sorted values as well
                    this.ArrayToString();
                    break;

                default:
                    this.SortingMethod = "Selection Sort";
                    stopwatch.Start();
                    this._sortedValues = SelectionSort.Sort(unsortedValues: this._originalValues);
                    stopwatch.Stop();
                    this.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

                    // Make sure we have a string representation of the sorted values as well
                    this.ArrayToString();
                    break;
            }
        }
    }
}