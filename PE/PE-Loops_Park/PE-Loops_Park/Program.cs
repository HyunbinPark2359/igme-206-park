/*
 * Hyunbin Park
 * PE - Loops
 * https://docs.google.com/document/d/1BFxvyQRAT6S3IS4F8xWYHjsIJ-0Gz_nqseCfAGFf-SU/edit?usp=sharing
 */

namespace PE_Loops_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Try the Loops

            // while loop
            // Print numbers from 0 to 5
            int i = 0;
            while (i <= 5)
            {
                Console.WriteLine(i);
                i++;
            }
            Console.WriteLine();

            // do/while loop
            // Print numbers from 100 to 95
            int j = 100;
            do
            {
                Console.WriteLine(j);
                j--;
            }
            while (j >= 95);
            Console.WriteLine();

            // for loop
            // Print 0 and multiples of 5 from 5 to 25
            for (int k = 0; k <= 25; k += 5)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();



            // Part 2: ASCII Art

            // Declare integer variables width and height
            int width;
            int height;

            // Prompt to input values of variables
            Console.Write("Enter a width: ");
            width = int.Parse(Console.ReadLine());

            Console.Write("Enter a height: ");
            height = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Print a solid rectangle
            for (int m = 0; m < height; m++)
            {
                for (int n = 0; n < width; n++)
                {
                    Console.Write("O");
                    // Go to next column
                }
                Console.WriteLine();
                // Go to next row
            }
            Console.WriteLine();

            // Print just the border of rectangle
            for (int m = 0; m < height; m++)
            {
                for (int n = 0; n < width; n++)
                {
                    // Check if the character is on the edge
                    if (m == 0 || m == height - 1 || n == 0 || n == width - 1)
                    {
                        Console.Write("O");
                    }

                    else
                    {
                        Console.Write(" ");
                    }
                    // Go to next column
                }
                Console.WriteLine();
                // Go to next row
            }
            Console.WriteLine();
        }
    }
}
