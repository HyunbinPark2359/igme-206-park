/* 
 * Hyunbin Park
 * HW 3 - Gradebook
 * https://docs.google.com/document/d/1CRdgLx-tmPCrJD4Lz4gKxuINPltc_18wgmnESYKsGXA/edit?usp=sharing
 */

namespace HW_Gradebook_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ================================================================

            // Activity 1: Getting the Data

            // Declare variables
            int numberOfGrades = -1;    // Total number of possible grades
            string[] assignmentNames;   // Array for the set of assignment names
            double[] assignmentGrades;  // Array for the set of assignment grades


            // Prompt to enter the number of assignments
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How many assignments are you saving? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            bool success = int.TryParse(Console.ReadLine(), out numberOfGrades);
            Console.ForegroundColor = ConsoleColor.White;

            // Prompt again until user enters valid input
            while (numberOfGrades < 1 || !success)
            {
                Console.Write("That is not a valid number. Enter the number of assignments: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                success = int.TryParse(Console.ReadLine(), out numberOfGrades);
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Remind user's input
            Console.WriteLine("You are saving {0} assignments.", numberOfGrades);
            Console.WriteLine();


            // Initialize the size of arrays using the data retrieved from user
            assignmentNames = new string[numberOfGrades];
            assignmentGrades = new double[numberOfGrades];


            // Prompt to enter the name and grade of each assignment
            // until it reaches the total number of assignments
            for (int i = 0; i < numberOfGrades; i++)
            {
                // Name of assignment
                Console.Write("Enter the name for assignment #{0}: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                assignmentNames[i] = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;

                // Received grade of that assignment
                Console.Write("Enter the grade for {0}: ", assignmentNames[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                success = double.TryParse(Console.ReadLine(), out assignmentGrades[i]);
                Console.ForegroundColor = ConsoleColor.White;

                // Prompt again until user enters valid input for grades
                while (assignmentGrades[i] < 0 || assignmentGrades[i] > 100 || !success)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    success = double.TryParse(Console.ReadLine(), out assignmentGrades[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

            Console.WriteLine("All grades are entered!");
            Console.WriteLine();



            // ================================================================

            // Activity 2: Grade Average

            // Declare variables
            double totalAverage = 0;    // The total average of all entered grades


            // Print a listing of assignments with grades
            // and sum the grades beforehand for later calculation
            Console.WriteLine("Grade Report:");
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i + 1, assignmentNames[i], assignmentGrades[i]);
                totalAverage += assignmentGrades[i];
            }

            Console.WriteLine("----------------------------------");

            // Find and print the average grade
            totalAverage /= numberOfGrades;
            Console.WriteLine("Average: {0:F}", totalAverage);
            Console.WriteLine();



            // ================================================================

            // Activity 3: Grade Replacement

            int userData;   // Store the number of index that user wants to work with

            // Prompt to enter which grade to replace
            // and re-prompt if unvalid index is given
            do
            {
                Console.Write("Which number grade do you want to replace? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                success = int.TryParse(Console.ReadLine(), out userData);
                Console.ForegroundColor = ConsoleColor.White;

                if (userData < 1 || userData > numberOfGrades || !success)
                {
                    Console.WriteLine("Index must be a number between 1 and {0}. Try again.", numberOfGrades);
                }
            }
            while (userData < 1 || userData > numberOfGrades || !success);
            Console.WriteLine();


            // Prompt to enter new grade
            Console.Write("What is the new grade for {0}? ", assignmentNames[userData - 1]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            success = double.TryParse(Console.ReadLine(), out assignmentGrades[userData - 1]);
            Console.ForegroundColor = ConsoleColor.White;

            // Prompt again until user enters valid input for grades
            while (assignmentGrades[userData - 1] < 0 || assignmentGrades[userData - 1] > 100 || !success)
            {
                Console.Write("Grade must be between 0 and 100. Enter grade: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                success = double.TryParse(Console.ReadLine(), out assignmentGrades[userData - 1]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

            // Remind user's input
            Console.WriteLine("Replacing the grade at index {0} with {1}", userData, assignmentGrades[userData - 1]);
            Console.WriteLine();



            // ================================================================

            // Activity 4 : Print Fianl Summary

            // Reset the value of total average
            totalAverage = 0;

            // Print a listing of assignments with grades
            // and sum the grades beforehand for later calculation
            Console.WriteLine("Final Grade Report:");
            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("  {0}. {1}: {2}", i + 1, assignmentNames[i], assignmentGrades[i]);
                totalAverage += assignmentGrades[i];
            }

            Console.WriteLine("----------------------------------");

            // Find and print the average grade
            totalAverage /= numberOfGrades;
            Console.WriteLine("Fianl average: {0:F}", totalAverage);
            Console.WriteLine();



            // ================================================================

            // Activity 5: Anaylize and Report!

            // Declare variables
            int aboveAverage = 0;       // How many grades are above the calculated average
            double highestGrade = 0;    // The lowest value in the array
            double lowestGrade = 100;   // The highest value in the array
            bool duplicate = false;     // Whether there are any duplicated grades in the array


            // Iterate through the grades array
            for (int i = 0; i < numberOfGrades; i++)
            {
                // Figure out if the grade in current index is above the average
                if (assignmentGrades[i] > totalAverage)
                {
                    aboveAverage++;
                }

                // Figure out if the grade in current index is the greatest
                if (assignmentGrades[i] > highestGrade)
                {
                    highestGrade = assignmentGrades[i];
                }

                // Figure out if the grade in current index is the lowest
                if (assignmentGrades[i] < lowestGrade)
                {
                    lowestGrade = assignmentGrades[i];
                }

                // Get into nested loop if duplicate is not found yet
                if (!duplicate)
                {
                    for (int j = 0; j < numberOfGrades; j++)
                    {
                        // Figure out if the grade in index 'i' has same value as one in index 'j'
                        // Automatically skips if 'i' and 'j' are in same index
                        if (i != j)
                        {
                            duplicate = assignmentGrades[i] == assignmentGrades[j];
                        }

                        // End the loop early if duplicate is found
                        if (duplicate)
                        {
                            break;
                        }
                    }
                }
            }


            // Report the analysis
            Console.WriteLine("{0} grades are above average." +
                              "\n\nThe highest grade is {1}." +
                              "\nThe lowest grade is {2}.", aboveAverage, highestGrade, lowestGrade);

            if (duplicate)
            {
                Console.WriteLine("\nA grade appears more than once in this set of grades.");
            }
            else
            {
                Console.WriteLine("\nAll grades are unique.");
            }
            Console.WriteLine();
        }
    }
}
