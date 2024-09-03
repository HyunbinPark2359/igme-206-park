/*
 * Bin Park
 * PE - Statements & Expressions
 * https://docs.google.com/document/d/1vl8WUygXAinknNA2v_4nWTg9IuH8rUOCzFjw5Y7y4tU/edit#heading=h.b7kmeozfqsrv
 */
namespace PE_StatementsExpressions_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Name of the character
            Console.WriteLine("Name: Bin Park");
            // Extra spacing
            Console.WriteLine();

            // The first stat equal to 20% of the total points
            Console.WriteLine((50 * (20.0 / 100)) + " Strength");
            // The second stat equal to half of the first stat
            Console.WriteLine(((50 * (20.0 / 100)) / 2) + " Dexterity");
            // The third stat is exactly 7 points
            Console.WriteLine(7 + " Intelligence");
            // The fourth stat equal to the sum of second and third stats, minus 2 points
            Console.WriteLine((((50 * (20.0 / 100)) / 2) + 7 - 2) + " Health");
            // The fifth stat is the leftover points
            Console.WriteLine((50 - 
               ((50 * (20.0 / 100)) + 
                ((50 * (20.0 / 100)) / 2) + 
                7 + 
                (((50 * (20.0 / 100)) / 2) + 7 - 2))) + " Charisma");

            // Extra spacing
            Console.WriteLine();
            // Total number of stat points
            Console.WriteLine("TOTAL: " + 50);
        }
    }
}
