/*
 * Hyunbin Park
 * PE - If's & Switches
 * https://docs.google.com/document/d/1uuSWGZ0ucs9T6YoB7kT1kYaL9xvL0Rvi3F2drohkIE0/edit?usp=sharing
 */

namespace PE_IfsSwitches_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare variables to store user's input
            int answerQuestionOne;
            int numberOne;
            int numberTwo;
            int numberThree;
            char answerQuestionThree;



            // Question #1
            // Prompt for input and parse it
            Console.Write("What is 6 * 7? ");
            answerQuestionOne = int.Parse(Console.ReadLine());

            // Answer is correct
            if (answerQuestionOne == 6 * 7)
            {
                Console.WriteLine("That's correct!");
            }

            // Otherwise, answer is incorrect
            else
            {
                Console.WriteLine("Nope :(");
            }



            // Question #2
            // Prompt for input in ascending order and parse it
            Console.Write("\n\nEnter 3 whole numbers in *ascending* order: \n1: ");
            numberOne = int.Parse(Console.ReadLine());
            Console.Write("2: ");
            numberTwo = int.Parse(Console.ReadLine());
            Console.Write("3: ");
            numberThree = int.Parse(Console.ReadLine());

            // The numbers are in ascending order
            if (numberThree > numberTwo && numberTwo > numberOne)
            {
                Console.WriteLine("That's correct!");
            }

            // The numbers are in descending order
            else if (numberThree < numberTwo && numberTwo < numberOne)
            {
                Console.WriteLine("That's backwards!");
            }

            // Anything else
            else
            {
                Console.WriteLine("What?!");
            }



            // Question #3
            // Prompt for input and parse it
            Console.WriteLine("\n\nSwitches are best for...\n" + 
                              "\ta. Checking the status of a combination of variables\n" + 
                              "\tb. Checking for different discrete values of the same variable\n" + 
                              "\tc. Checking if a variable's value is within a certain range\n" + 
                              "\td. All of the above\n");
            answerQuestionThree = char.Parse(Console.ReadLine());

            // Check if the answer is right
            switch(answerQuestionThree)
            {
                // Input is correct answer b
                case 'b':
                    Console.WriteLine("Correct!");
                    break;

                // Input is wrong answer a,c,d
                case 'a':
                case 'c':
                case 'd':
                    Console.WriteLine("Sorry. That's incorrect. Switches are best for checking\n" +
                                      "for different *discrete values* of the *same* variable.");
                    break;

                // Anything else
                default:
                    Console.WriteLine("That wasn't even an option!");
                    break;
            }
        }
    }
}
