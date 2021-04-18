namespace SortingAPI.Scripts.Sorters
{
    public class BubbleSort
    {
        /// <summary>
        /// Use a standard BubbleSort to rearrange your
        /// data (array of integers) into a sequential
        /// data array.
        /// </summary>
        /// <param name="unsortedValues">Array of integers.</param>
        /// <returns></returns>
        public static int[] Sort(int[] unsortedValues)
        {
            // Establish what is the size of our array
            int len = unsortedValues.Length;
            // Go through the array swapping 2 numbers as we see them next to each other, if such move is required
            for (int i=0; i<=len-2; i++)
            {
                for(int j=0; j<=len-2; j++)
                {
                    // Perform a swap of 2 numbers if the following condition holds
                    if (unsortedValues[j]>unsortedValues[j + 1])
                    {
                        int temp = unsortedValues[j];
                        unsortedValues[j] = unsortedValues[j + 1];
                        unsortedValues[j + 1] = temp;
                    }
                }
            }
            // In reality the values shold be sorted by now. Poor naming might cause confusion :/
            return unsortedValues;
        }
    }
}