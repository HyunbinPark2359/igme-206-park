/*
 * Hyunbin Park
 * PE - Input & Strings
 * https://docs.google.com/document/d/1jY5NojS8rVRq7ZhxB_5E4hoRj30y40zFMzAa1X0sBN0/edit?usp=sharing
 */

namespace PE_InputStrings_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declares four string variables
            string userName;
            string color;
            string petName;
            string band;



            // Takes input from user and stores it into existing variable
            // Console.ForegroundColor is used just to match my output with sample run in docs
            // User's name
            Console.Write("What is your name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome " + userName + "!");

            // User's favorite color
            Console.Write("What is your favorite color? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            color = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // The name of user's pet
            Console.Write("What is your pet's name? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            petName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // User's favorite band
            Console.Write("What is your favorite band? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            band = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;



            // Prints four statements that uses string methods
            // Prints the length of user's name using string.Length
            Console.WriteLine("\nYour name is " + userName.Length + " letters long");
            // and calculates how much longer it is than the length of pet's name
            Console.WriteLine("and " + (userName.Length - petName.Length) + " letters longer than " + 
                              petName + "'s name.");

            // Prints a statement using string.ToUpper()
            Console.WriteLine("\nI wonder if " + petName.ToUpper() + " and " + band.ToUpper() + 
                              " like " + color.ToUpper() + " as much as you do.");

            // Prints a 7 characters long made-up name using .ToUpper(), .ToLower(), and .Substring()
            Console.WriteLine("\nMaybe I should just call you " + userName.ToUpper()[0] + 
                              color.ToLower().Substring(0, 2) + petName.ToLower().Substring(0, 2) + 
                              band.ToLower().Substring(0, 2) + "?");
        }
    }
}
