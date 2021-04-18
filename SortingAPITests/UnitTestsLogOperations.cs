using SortingAPI.Scripts.LogOperators;
using SortingAPI.Scripts.Parser;
using SortingAPI.Scripts.Sorters;
using System;
using Xunit;

namespace SortingAPITests
{
    /// <summary>
    /// A lot of methods and functions do not have additional guardrails
    /// on them, which is because of how the original code was structured,
    /// where it the user's data inputs stage it is made sure, that no matter
    /// what the user enters - there won't be any errors. Hence, a lot of 
    /// checks are not implemented further. This is one of such cases.
    /// </summary>
    public class UnitTestsLogOperations
    {
        [Fact]
        public void TestSaveDataReloadIt()
        {
            // A bit of a werid test, that checks whether saving an reloading of files works
            // We know our file should save anywhere if even the log files don't exist yet, let's try saving something
            string savingPath = "logs.txt";
            string contentsToSave = "Test;Test";

            SaveData.SaveDataToFile(filePath: savingPath, contents: contentsToSave);
            string newContents = LoadData.LoadDataFromFile(filePath: savingPath);

            Assert.Equal(expected: contentsToSave, actual: newContents);
        }

        [Fact]
        public void TestSaveEmptyDataReloadIt()
        {
            // A bit of a werid test, that checks whether saving an reloading of files works
            // We know our file should save anywhere if even the log files don't exist yet, let's try saving something
            // In this case save nothing, just an empty string
            string savingPath = "logs.txt";
            string contentsToSave = "";

            SaveData.SaveDataToFile(filePath: savingPath, contents: contentsToSave);
            string newContents = LoadData.LoadDataFromFile(filePath: savingPath);

            Assert.Equal(expected: contentsToSave, actual: newContents);
        }
    }

    public class UnitTestsSortingOperations
    {
        [Fact]
        public void TestBubbleSortNoNegativeValues()
        {
            // Set the conditions to have unsorted values and sort them
            int[] valuesToSort = { 1, 3, 5, 999, 0, 2, 6 };
            int[] trueSortedValues = { 0, 1, 2, 3, 5, 6, 999 };
            int[] sortedValues = BubbleSort.Sort(unsortedValues: valuesToSort);

            // Check if the sorting worked
            Assert.Equal(expected: trueSortedValues, actual: sortedValues);
        }

        [Fact]
        public void TestBubbleSortWithNegativeValues()
        {
            // Set the conditions to have unsorted values and sort them
            int[] valuesToSort = { 1, -3, 5, -999, 0, 2, -6 };
            int[] trueSortedValues = { -999, -6, -3, 0, 1, 2, 5 };
            int[] sortedValues = BubbleSort.Sort(unsortedValues: valuesToSort);

            // Check if the sorting worked
            Assert.Equal(expected: trueSortedValues, actual: sortedValues);
        }

        [Fact]
        public void TestSelectionSortNoNegativeValues()
        {
            // Set the conditions to have unsorted values and sort them
            int[] valuesToSort = { 1, 3, 5, 999, 0, 2, 6 };
            int[] trueSortedValues = { 0, 1, 2, 3, 5, 6, 999 };
            int[] sortedValues = SelectionSort.Sort(unsortedValues: valuesToSort);

            // Check if the sorting worked
            Assert.Equal(expected: trueSortedValues, actual: sortedValues);
        }

        [Fact]
        public void TestSelectionSortWithNegativeValues()
        {
            // Set the conditions to have unsorted values and sort them
            int[] valuesToSort = { 1, -3, 5, -999, 0, 2, -6 };
            int[] trueSortedValues = { -999, -6, -3, 0, 1, 2, 5 };
            int[] sortedValues = SelectionSort.Sort(unsortedValues: valuesToSort);

            // Check if the sorting worked
            Assert.Equal(expected: trueSortedValues, actual: sortedValues);
        }
    }

    public class UnitTestsParsers
    {
        [Fact]
        public void TestLogsParserSingleSeparator()
        {
            string contents = "Hello;Goodbye";
            string[] expectedContents = { "Hello", "Goodbye" };

            string[] actualContents = LogsParser.ParserLogs(contents: contents);

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsParserMultipleSeparator()
        {
            string contents = "Hello;Goodbye;Welcome Back;C#";
            string[] expectedContents = { "Hello", "Goodbye", "Welcome Back", "C#" };

            string[] actualContents = LogsParser.ParserLogs(contents: contents);

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsParserNoSeparator()
        {
            string contents = "Hello";
            string[] expectedContents = { "Hello" };

            string[] actualContents = LogsParser.ParserLogs(contents: contents);

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsCleanInputsParser()
        {
            string contents = "1 2 3 67 90 -13 0";
            int[] expectedContents = { 1, 2, 3, 67, 90, -13, 0 };

            InputsParser inputsParser = new(originalData: contents);
            int[] actualContents = inputsParser.GetParsedValues();

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsMessyInputsParser()
        {
            string contents = "1 2 3 67,12 asd90 -13 0%^";
            int[] expectedContents = { 1, 2, 3, 67, -13, 0 };

            InputsParser inputsParser = new(originalData: contents);
            int[] actualContents = inputsParser.GetParsedValues();

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsTooLargeInputsParser()
        {
            string contents = "1 2 3 67,12 asd90 -13 0%^ 1234567890987654321";
            int[] expectedContents = { 1, 2, 3, 67, -13, 0 };

            InputsParser inputsParser = new(originalData: contents);
            int[] actualContents = inputsParser.GetParsedValues();

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsEmptySpacesInputsParser()
        {
            string contents = "        1 2 3 67,12 asd90 -13 0%^ 1234567890987654321        ";
            int[] expectedContents = { 1, 2, 3, 67, -13, 0 };

            InputsParser inputsParser = new(originalData: contents);
            int[] actualContents = inputsParser.GetParsedValues();

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }

        [Fact]
        public void TestLogsEmptyInputsParser()
        {
            string contents = "   ";
            int[] expectedContents = Array.Empty<int>();

            InputsParser inputsParser = new(originalData: contents);
            int[] actualContents = inputsParser.GetParsedValues();

            Assert.Equal(expected: expectedContents, actual: actualContents);
        }
    }
}
