/*
 * Hyunbin Park
 * PE - Input & Parsing
 * https://docs.google.com/document/d/1-cwu4r6ES1Cg5RujrKAKU8aGUKaWGBjv5wgFe6IvKmk/edit?usp=sharing
 */

namespace PE_InputParsing_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declares and initializes total 11 variables:
            // one string for player's name
            string playerName;

            // five whole numbers
            int playedTime;
            int xValueOfPointOne;
            int yValueOfPointOne;
            int xValueOfPointTwo;
            int yValueOfPointTwo;

            // four floating-point numbers
            double numberA;
            double numberB;
            double degrees;
            double radians;

            // lastly, a string to hold user's input before it's parsed
            string userData;



            // Calculations and Outputs
            // Addition, Parsing, & Explicit Casting
            Console.WriteLine("--- ADDITION ---");

            // Retrieves an input from the user, parses it to appropriate data type, and stores it in appropriate variable
            Console.Write("What is the first number? ");
            userData = Console.ReadLine();
            numberA = double.Parse(userData);
            Console.Write("What is the second number? ");
            userData = Console.ReadLine();
            numberB = double.Parse(userData);

            // Adds the numbers
            Console.WriteLine(numberA + " + " + numberB + " = " + (numberA + numberB));
            Console.WriteLine("Now I'll just add the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + ((int)numberA + (int)numberB));



            // Division, Parsing, & Modulus
            Console.WriteLine("\n--- DIVISION and MODULUS ---");

            // Retrieves an input from the user
            Console.Write("What is that player's name? ");
            playerName = Console.ReadLine();
            Console.Write("How many hours have they logged? ");
            userData = Console.ReadLine();
            playedTime = int.Parse(userData);

            // Outputs information retrieved from the user in different words
            Console.WriteLine(playerName + " has played a game for " + playedTime + " hours.");
            Console.WriteLine("They have played for " + (playedTime / 24) + " days and " + (playedTime % 24) + " hours.");



            // Sine & Cosine
            Console.WriteLine("\n--- SINE and COSINE ---");

            // Retrieves an angle from the user
            Console.Write("Enter an angle in degrees: ");
            userData = Console.ReadLine();
            degrees = double.Parse(userData);

            // Outputs radians
            radians = degrees * Math.PI / 180;
            Console.WriteLine(degrees + " degrees is " + radians + " radians.");

            // Outputs sine and cosine of radians. We need radians, NOT degrees.
            Console.WriteLine("The sine is " + (Math.Sin(radians)));
            Console.WriteLine("The cosine is " + (Math.Cos(radians)));



            // Distance & Rounding
            Console.WriteLine("\n--- DISTANCE and ROUNDING ---");

            // Retrieves X and Y coordinates of two points from the user
            Console.Write("Enter Point 1 X: ");
            userData = Console.ReadLine();
            xValueOfPointOne = int.Parse(userData);
            Console.Write("Enter Point 1 Y: ");
            userData = Console.ReadLine();
            yValueOfPointOne = int.Parse(userData);
            Console.Write("Enter Point 2 X: ");
            userData = Console.ReadLine();
            xValueOfPointTwo = int.Parse(userData);
            Console.Write("Enter Point 2 Y: ");
            userData = Console.ReadLine();
            yValueOfPointTwo = int.Parse(userData);
            Console.WriteLine("Point One: (" + xValueOfPointOne + ", " + yValueOfPointOne + ")");
            Console.WriteLine("Point Two: (" + xValueOfPointTwo + ", " + yValueOfPointTwo + ")");

            // Outputs a distance between  two points using pythagorean theorem
            double distance = Math.Sqrt(Math.Pow((xValueOfPointTwo - xValueOfPointOne), 2)
                                           + Math.Pow((yValueOfPointTwo - yValueOfPointOne), 2));
            Console.WriteLine("The distance between these points is " + distance);

            // Rounds a distance to a whole number and to the thousandths place
            Console.WriteLine("The distance is " + distance + ", which is approximately "
                              + Math.Round(distance) + " units, or "
                              + Math.Round(distance, 3) + " to be more precise.");
        }
    }
}
