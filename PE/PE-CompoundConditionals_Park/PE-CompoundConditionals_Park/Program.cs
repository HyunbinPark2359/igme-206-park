/*
 * Hyunbin Park
 * PE - Compound Conditionals
 * https://docs.google.com/document/d/1nCnicUXiAxf5fovWYw3YQWSp0wyHOC4m8SyKupbSl8A/edit?usp=sharing
 */

namespace PE_CompoundConditionals_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /****************************************************************************
            * Problem # 1
            ****************************************************************************/
            int population;
            int superHeroes;
            int aliens;
            
            // Print the header
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n** Problem #1 **");

            // Prompt for input and parse the data
            Console.Write("What is the current population of Earth? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            population = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How many superheroes are alive and working? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            superHeroes = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("How many aliens have invaded Earth? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            aliens = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.

            // DOOMED
            if (aliens > population && superHeroes <= 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The world is doomed!");
            }

            // Otherwise, there's hope!
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("There's hope for the world!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            
            /****************************************************************************
            * Problem # 2
            ****************************************************************************/
            // Constants to make the if conditions more readable
            const int BiggerThanBreadbox = 1;
            const int SmallerThanBreadbox = 2;
            const int Animal = 1;
            const int Fruit = 2;
            const int Mineral = 3;

            // Variables you'll need
            int answer1;
            int answer2;

            // Print the header
            Console.WriteLine("\n\n** Problem #2 **");

            // Prompt for input and parse the data
            Console.WriteLine("Let's play 20 questions! Well... 2 questions.");
            Console.WriteLine("Think of any object and I will tell you what it is.");

            Console.Write(" - Question 1. Is it animal(1), fruit(2), or mineral(3)? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer1 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" - Question 2. Is it bigger than a breadbox? yes(1), or no(2)? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            answer2 = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.
            Console.ForegroundColor = ConsoleColor.Green;

            // WOLF
            if (answer1 == Animal && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a wolf!");
            }

            // SQUIRREL
            else if (answer1 == Animal && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a squirrel!");
            }

            // WATERMELON
            else if (answer1 == Fruit && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a watermelon!");
            }

            // KIWI
            else if (answer1 == Fruit && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a kiwi!");
            }

            // CAR
            else if (answer1 == Mineral && answer2 == BiggerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a car!");
            }

            // PAPERCLIP
            else if (answer1 == Mineral && answer2 == SmallerThanBreadbox)
            {
                Console.WriteLine("I guess you are thinking of a paperclip!");
            }

            // Anything else...
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice given");
            }
            Console.ForegroundColor = ConsoleColor.White;

            /****************************************************************************
            * Problem # 3
            ****************************************************************************/
            string month;
            int day;

            // Print the header
            Console.WriteLine("\n\n** Problem #3 **");

            // Prompt for input and parse the data
            Console.Write("What is your birth month? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            month = Console.ReadLine().Trim().ToLower();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("On which day were you born? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            day = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            // Use compound conditionals and an appropriate if-else statement to
            // determine the correct response.
            Console.ForegroundColor = ConsoleColor.Green;

            if (month == "january" && day >= 1 && day <= 19)
            {
                Console.WriteLine("Your sign is Capricorn.");
            }

            else if ((month == "january" && day >= 20 && day <= 31) || (month == "february" && day >= 1 && day <= 18))
            {
                Console.WriteLine("Your sign is Aquarius.");
            }

            else if (month == "february" && day >= 19 && day <= 29)
            {
                Console.WriteLine("Your sign is Pisces.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid birthdate!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
