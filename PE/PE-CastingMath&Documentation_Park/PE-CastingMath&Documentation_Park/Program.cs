/*
 * Hyunbin Park
 * PE - Casting, Math & Documentation
 * https://docs.google.com/document/d/1ibDROBK1nO4bHIbmaB10vAJ66pUrSGBGLV_ziIb1EAM/edit?usp=sharing
 */

namespace PE_CastingMath_Documentation_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring and initializing total 10 variables
            // one string for player's name
            string playerName = "Victor Wembanyama";
            // five whole numbers
            int playedTime = 274;
            int xValueOfPointOne = -13;
            int yValueOfPointOne = 51;
            int xValueOfPointTwo = 17;
            int yValueOfPointTwo = 28;
            // four floating-point numbers
            double numberA = 7.9;
            double numberB = 2.25;
            double sixtyDegrees = 60;
            // Using Math.PI to convert degrees to radians
            double sixtyRadians = sixtyDegrees * Math.PI / 180;


            // Calculations and Outputs
            // Addition % Explicit Casting
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + numberA);
            Console.WriteLine("Number B: " + numberB);
            // Declaring a new variable to save the sum of numbers
            double sumOfDoubles = numberA + numberB;
            Console.WriteLine(numberA + " + " + numberB + " = " + sumOfDoubles);
            Console.WriteLine("Now I'll add just the whole number parts.");
            // Casting existing floating-point numbers to whole numbers
            int wholeNumberA = (int)numberA;
            int wholeNumberB = (int)numberB;
            int sumOfWholeNumbers = wholeNumberA + wholeNumberB;
            Console.WriteLine(wholeNumberA + " + " + wholeNumberB + " = " + sumOfWholeNumbers);


            // Division & Modulus
            Console.WriteLine("\n--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + playedTime + " hours.");
            // Using division for played time in days, modulus for remaining played time in hours
            Console.WriteLine("They have played for " + (playedTime / 24) + " days and " + (playedTime % 24) + " hours.");


            // Sine & Cosine
            Console.WriteLine("\n--- SINE and COSINE ---");
            Console.WriteLine(sixtyDegrees + " degrees is " + sixtyRadians + " radians.");
            // Calculating the sine and cosine of radians. We need radians, NOT degrees.
            Console.WriteLine("The sine is " + (Math.Sin(sixtyRadians)));
            Console.WriteLine("The cosine is " + (Math.Cos(sixtyRadians)));


            // Distance
            Console.WriteLine("\n--- DISTANCE ---");
            Console.WriteLine("Point One: (" + xValueOfPointOne + "," + yValueOfPointOne + ")");
            Console.WriteLine("Point Two: (" + xValueOfPointTwo + "," + yValueOfPointTwo + ")");
            // Using Math.Sqrt() and Math.Pow() for pythagorean theorem
            double distanceBetweenPoints = Math.Sqrt(Math.Pow((xValueOfPointTwo - xValueOfPointOne),2)
                                           + Math.Pow((yValueOfPointTwo - yValueOfPointOne),2));
            Console.WriteLine("The distance between these points is " + distanceBetweenPoints);


            // Rounding
            Console.WriteLine("\n--- ROUNDING ---");
            // Using Math.Round() to round a distance to a whole number and to the thousandths place
            Console.WriteLine("The distance is " + distanceBetweenPoints + ", which is approximately "
                              + Math.Round(distanceBetweenPoints) + " units, or " 
                              + Math.Round(distanceBetweenPoints, 3) + " to be more precise.");
        }
    }
}
