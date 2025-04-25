namespace UtilitiesLib
{
    public static class GeneralHelpers
    {
        /// <summary>
        /// Converts string to integer
        /// </summary>
        /// <param name="str">Input string to parse into number</param>
        /// <param name="result">Integer out param</param>
        /// <returns>True if Parsed</returns>
        public static bool ConvertStringToInteger(string str, out int result)
        {

            if (str == null) { result = 0; return false; }
            string cleanedString = "";
            for (int i = 0; i < str.Length; i++) if (char.IsNumber(str[i])) cleanedString += str[i];
            return Int32.TryParse(cleanedString, out result);
        }

        /// <summary>
        /// Converts string to integer and checks if it between two values
        /// </summary>
        /// <param name="str">Input string to parse into number</param>
        /// <param name="lowLimit">Min value</param>
        /// <param name="highLimit">Max value</param>
        /// <param name="returnValue">Integer out param</param>
        /// <returns>True if returned integer value is between low limit and high limit</returns>
        public static bool ConvertStringToInteger(string str, int lowLimit, int highLimit, out int returnValue)
        {
            ConvertStringToInteger(str, out int n);
            try
            {
                if (n > lowLimit && n < highLimit) { returnValue = n; return true; }
                else { returnValue = n; return false; }
            }
            catch { returnValue = 0; return false; }

        }

        /// <summary>
        /// Converts string to float value
        /// </summary>
        /// <param name="str">Input string to parse into float</param>
        /// <param name="result">Float out value</param>
        /// <returns>True if parse performed successfully</returns>
        public static bool ConvertStringToFloat(string str, out float result)
        {
            if (str == null) { result = 0; return false; }
            string cleanedString = "";
            for (int i = 0; i < str.Length; i++) if (!char.IsLetter(str[i])) cleanedString += str[i];
            return float.TryParse(cleanedString, Thread.CurrentThread.CurrentCulture, out result);

        }

        /// <summary>
        /// Converts string to float value and checks if returned value is between two values
        /// </summary>
        /// <param name="str">Input string to parse into float</param>
        /// <param name="lowLimit">Min value</param>
        /// <param name="highLimit">Max value</param>
        /// <param name="returnValue">Float out param</param>
        /// <returns>True if parsed value is between low and high</returns>
        public static bool ConvertStringToFloat(string str, int lowLimit, int highLimit, out float returnValue)
        {
            ConvertStringToFloat(str, out float n);
            try
            {
                if (n > lowLimit && n < highLimit) { returnValue = n; return true; }
                else { returnValue = n; return false; }
            }
            catch { returnValue = 0; return false; }
        }

        /// <summary>
        /// Merge sort items of a list in O(n log n) operations
        /// </summary>
        /// <param name="input">Items to be sorted</param>
        /// <param name="reverse">Set to true to return a descending list</param>
        /// <returns>A list of sorted integers</returns>
        public static List<int> MergeSort(List<int> input, bool reverse)
        {
            List<int> left = [];
            List<int> right = [];
            List<int> output = [];
            int leftIndex = 0, rightIndex = 0;
            //Split list in halves, then sort the halves until the halves are single elements
            //return sorted halves recursively
            for (int i = 0; i < input.Count; i++)
            {
                if (i < input.Count / 2) { left.Add(input[i]); }
                else { right.Add(input[i]); }
            }
            if (left.Count > 1) left = MergeSort(left, false);
            if (right.Count > 1) right = MergeSort(right, false);
            //Compare values and add the lowest
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    output.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    output.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            //Add remaining elements when one of the lists has reached its max
            if (leftIndex < left.Count) output.AddRange(left.Skip(leftIndex).Take(left.Count - leftIndex));
            if (rightIndex < right.Count) output.AddRange(right.Skip(rightIndex).Take(right.Count - rightIndex));

            if (reverse) output.Reverse();
            return output;
        }

        /// <summary>
        /// Sorts a list in best O(n) avg O(n^2) worst O(n^2)
        /// </summary>
        /// <param name="input">Items to be sorted</param>
        /// <param name="reverse">Set to true to return a descending list</param>
        /// <returns>A list of sorted integers</returns>
        public static List<int> InsertionSort(List<int> input, bool reverse)
        {
            List<int> output = new(input);
            for (int i = 1; i < output.Count; i++)
            {
                int key = output[i];
                int j = i - 1;
                while (j >= 0 && output[j] > key)
                {
                    output[j + 1] = output[j];
                    j--;
                }
                output[j] = key;
            }
            if (reverse) output.Reverse();
            return output;
        }

        /// <summary>
        /// Merge sort items of a list in O(n log n) operations
        /// </summary>
        /// <param name="input">Items to be sorted</param>
        /// <param name="blockSize">Size of blocks to divide input list into for sorting recommended the sq root of input length</param>
        /// <param name="reverse">Set to true to return a descending list</param>
        /// <returns>A list of sorted integers</returns>
        public static List<int> BlockSort(List<int> inputs, int blockSize, bool reverse)
        {
            List<List<int>> blocks = [];
            //Divide into chunks that are sorted by a comparison sort
            for (int i = 0; i < inputs.Count; i += blockSize)
            {
                List<int> block = inputs.Slice(i, i + blockSize);
                blocks.Add(MergeSort(block, false));
            }

            //Sort blocks per weight
            List<int> result = [];
            while (blocks.Count > 0)
            {
                List<int> minBlock = blocks[0];
                int minIndex = 0;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if (blocks[i][0] < minBlock[0])
                    {
                        minBlock = blocks[i];
                        minIndex = i;
                    }
                }
                result.Add(minBlock[0]);
                minBlock.Remove(0);
                if (minBlock.Count > 0)
                {
                    blocks[minIndex] = minBlock;
                }
                else blocks.RemoveAt(minIndex);
            }
            if (reverse) result.Reverse();
            return result;
        }
    }
}
