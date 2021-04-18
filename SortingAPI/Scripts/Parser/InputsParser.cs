using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SortingAPI.Scripts.Parser
{
    public class InputsParser
    {
        private readonly string _originalData;
        private int[] _parsedValues;

        /// <summary>
        /// Create through a constructor a storage in which the data is being held
        /// and parse it right away. The user can chose to get either the original
        /// data they have inputted or get the parsed data, based on their preferences.
        /// </summary>
        /// <param name="originalData">Simply a string of numbers. The original excercise
        /// seems to consider we will be working only with integers, so that is what we
        /// will stick with in this case. Anything not an integer, well...won't make the cut.</param>
        public InputsParser(string originalData)
        {
            this._originalData = originalData;

            // Check if the data that we have in our string is even present
            if (string.IsNullOrEmpty(this._originalData))
            {
                this._parsedValues = new int[] { };
                return;
            }

            this._originalData = this._originalData.Trim();
            // Split the user entered values based on spaces they used
            string[] tokens;
            tokens = originalData.Split(" ");

            // Further check each token entered by the user and only accept values to the point 
            // Where they meet the expected criteria of being numbers. If there is a symbol like
            // . just ignore everything afterwards. 

            // Iterate through the values that have been saved seperatelly
            // Maybe doing through for loops would have been easier to manage, but I noticed it was harder to read
            string notNumber = "NotNumber";
            int idx = -1;
            foreach (string token in tokens)
            {
                // Iterate through each tokens characters keeping track where we are in the iteration
                idx++;
                string tempStorage = "";
                int tokenLength = token.Length;
                int currentPosition = 0;
                foreach (char character in token)
                {                    
                    // Validate on several conditions whether our inputed values make sense to be worked with
                    currentPosition++;
                    // If a value is a number in the range 0-9 then keep track of it and continue our jorney
                    if (Regex.IsMatch(character.ToString(), @"\d") & currentPosition != tokenLength)
                    {
                        tempStorage += character.ToString();
                    }
                    // If the value is a number in the range 0-9 but we are at the end of the phrase - save it and move to the next token
                    else if (Regex.IsMatch(character.ToString(), @"\d") & currentPosition == tokenLength)
                    {
                        tempStorage += character.ToString();
                        tokens[idx] = tempStorage;
                        break;
                    }
                    // If a value we are dealing is not a number, it's in the first position, but is a dash, it could be a negative number
                    else if (!Regex.IsMatch(character.ToString(), @"\d") & character == '-' & currentPosition == 1)
                    {
                        tempStorage += "-";
                    }
                    // If the value is not a number and a dash and we are just starting - make a note that we are dealing with Not a Number
                    else if (!Regex.IsMatch(character.ToString(), @"\d") & character != '-' & currentPosition == 1)
                    {
                        tokens[idx] = notNumber;
                        break;
                    }
                    // Any other case just break the check and move to the next token
                    else
                    {
                        tokens[idx] = tempStorage;
                        break;
                    }
                }
            }
            // Simplify our array and remove everything we consider to not be a number
            tokens = tokens.Where(val => val != notNumber & val != "").ToArray();

            // Because we are sure that whatever is left is an integer, we can now try to convert string to real integers
            // Do considering that some values might not be appropriate for conversion as they are just too large
            List<int> convertedItem = new();
            foreach (string value in tokens)
            {
                int number;
                bool success = Int32.TryParse(value, out number);
                if (success)
                {
                    convertedItem.Add(number);
                }
            }

            int[] convertedItemFinal = convertedItem.ToArray();

            // And finally update our object with a new set of data
            this._parsedValues = convertedItemFinal;
        }

        /// <summary>
        /// Return original inputted values to the user.
        /// </summary>
        /// <returns></returns>
        public string GetOriginalValues()
        {
            return this._originalData;
        }

        /// <summary>
        /// Return parsed values into an integer array.
        /// </summary>
        /// <returns></returns>
        public int[] GetParsedValues()
        {
            return this._parsedValues;
        }
    }
}