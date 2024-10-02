/*
 * Hyunbin Park
 * PE - Magic 8 Ball
 * https://docs.google.com/document/d/13OBHKxRLnRKNiYijs119CSW9Y7kW77oRCd1uovYR-Hs/edit?usp=sharing
 */

namespace PE_Magic8Ball_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Store user's input
            string userData;


            // Prompt for the name of the ball's owner
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Welcome to Magic 8 Ball Simulator!" + 
                          "\n  > Who owns this ball?  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            userData = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Instantiate a MagicEightBall object
            MagicEightBall magicEightBall = new MagicEightBall(userData);


            // Ask the user what they'd like to do with the ball
            // until user manually quits
            do
            {
                Console.Write("\nWhat would you like to do?" +
                              "\nYou can 'shake' the ball, get a 'report', or 'quit':  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                userData = Console.ReadLine().ToLower().Trim();
                Console.ForegroundColor = ConsoleColor.White;

                // Perform the corresponding action
                switch (userData)
                {
                    // Prompt for question and shake the ball
                    // Print the response of the ball
                    case "shake":
                        Console.Write("  > What is your question? ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("  > The Magic 8 Ball says: {0}", 
                                          magicEightBall.ShakeBall());
                        break;

                    // Print the report
                    case "report":
                        Console.WriteLine("  > {0}", magicEightBall.Report());
                        break;

                    // Say goodbye and exit the loop
                    case "quit":
                        Console.WriteLine("  > Goodbye!");
                        break;

                    // Anything else
                    default:
                        Console.WriteLine("  > I do not recognize that response.");
                        break;
                }
            }
            while (userData != "quit");
        }
    }
}
