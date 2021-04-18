namespace SortingAPI.Scripts.Sorters
{
    public class SelectionSort
    {
        /// <summary>
        /// Use a standard Selection Sort to rearrange your
        /// data (array of integers) into a sequential
        /// data array.
        /// </summary>
        /// <param name="unsortedValues">Array of integers.</param>
        /// <returns></returns>
        public static int[] Sort(int[] unsortedValues)
        {
            // Initiate a variable which will keep track of what is our smallest value in the array
            // For reference, this is not the value itself, but the indexed position in the array of the smallest value
            int smallest;
            // Establish what is the size of our array
            int len = unsortedValues.Length;

            // Iterate through the values in the array looking for the smallest and replacing it position wise
            for(int i=0; i < len-1; i++)
            {
                smallest = i;

                // Evaluate whether the "smallest" value needs to be replaced with other values
                for (int j=i+1; j<len; j++)
                {
                    if(unsortedValues[j] < unsortedValues[smallest])
                    {
                        smallest = j;
                    }
                }
                // Swap the first (or one we are dealing with) value with the smallest found in the array
                // after the value we are dealing with
                int temp = unsortedValues[i];
                unsortedValues[i] = unsortedValues[smallest];
                unsortedValues[smallest] = temp;
            }
            // In reality the values shold be sorted by now. Poor naming might cause confusion :/
            return unsortedValues;
        }
    }
}