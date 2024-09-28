/*
 * Hyunbin Park
 * PE - 2D Arrays
 * https://docs.google.com/document/d/1sHTLdpL9oFUDTzCVaOG38gYA_nSnDhd7MVY6IYx2P4A/edit?usp=sharing
 */

namespace PE_2DArrays_Park
{
    internal class Program
    {
        // Initialize a 2D array with sequential values
        public static void Fill2DArray(int[,] array, int startNum)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    array[row, col] = startNum;
                    startNum++;
                }
            }
        }

        // Print values in the array
        public static void Print2DArray(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                Console.Write("\tCol {0}", col + 1);
            }

            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.Write("\nRow {0}: ", row + 1);

                for (int col = 0;col < array.GetLength(1); col++)
                {
                    Console.Write("\t" + array[row,col]);
                }
            }
        }

        static void Main(string[] args)
        {
            // Define and initialize a 2D array
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values in the array
            Print2DArray(integerArray);
        }
    }
}
