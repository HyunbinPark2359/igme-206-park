/*
 * Hyunbin Park
 * PE - Guessing Game
 * https://docs.google.com/document/d/1_VNlxiE2SSDOxhRLTJtHTYpb7oMC5IXzam2HrVY9XHk/edit?usp=sharing
 */

namespace PE_GuessingGame_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define variables
            Random rng = new Random();
            int randomNumber = rng.Next(101);   // Random number between 0 and 100 (inclusive)
            int userNumber = -1;                // User's input
            int min = 0;                        // Minimum value 0
            int max = 100;                      // Maximum value 100
            int turn = 0;

            // Print the value of random number first
            Console.WriteLine(randomNumber);
            Console.WriteLine();

            // Loop until eighth turn or user enters correct answer
            do
            {
                // Prompt for input
                Console.Write("\nTurn #{0}: Guess a number between {1} and {2} (inclusive): ", turn + 1, min, max);
                bool success = int.TryParse(Console.ReadLine(), out userNumber);

                // Loop until user enters viable input
                while (userNumber < min || userNumber > max || !success)
                {
                    Console.WriteLine("Invalid guess - try again.");
                    Console.Write("\nTurn #{0}: Guess a number between {1} and {2} (inclusive): ", turn + 1, min, max);
                    success = int.TryParse(Console.ReadLine(), out userNumber);
                }

                // Inform user if input number is greater than the correct answer
                if (userNumber > randomNumber)
                {
                    Console.WriteLine("Too high");
                }

                // Inform user if input number is less than the correct answer
                else if (userNumber < randomNumber)
                {
                    Console.WriteLine("Too low");
                }

                // Otherwise, input number is correct and ends the program
                else
                {
                    Console.WriteLine("\nCorrect! You won in {0} turns.", turn + 1);

                    return;
                }

                turn++;
            }
            while (userNumber != randomNumber && turn < 8);

            Console.WriteLine("\nYou ran out of turns. The number was {0}.", randomNumber);
        }
    }
}
