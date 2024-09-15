/*
 * Hyunbin Park
 * PE - If Statements
 * https://docs.google.com/document/d/1r6n9DdOHQMa6qZYm-9p6EaWF_Dfp6S4q8QvW-igVvYQ/edit?usp=sharing
 */

namespace PE_IfStatements_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declares 4 strings
            // stores user's input
            string userData;
            // three different scenarios
            string scenarioOne = "dead body";
            string scenarioTwo = "footsteps";
            string scenarioThree = "smell of food";


            // receives and saves the user's input
            Console.Write("What does the NPC in your game sense? ");
            userData = Console.ReadLine().ToLower().Trim();


            // user's input leads to different scenarios using if statements
            if(userData == scenarioOne)
            {
                Console.WriteLine("The NPC is frightened and sounds the alarm.");
            }

            else if(userData == scenarioTwo)
            {
                Console.WriteLine("The NPC follows the sound of footsteps and encounters you.");
            }

            else if(userData == scenarioThree)
            {
                // two-input scenario with nested if statement
                Console.Write("Which smell of food does the NPC sense (pizza or steak)? ");
                userData = Console.ReadLine().ToLower().Trim();

                if(userData == "pizza")
                {
                    Console.WriteLine("The NPC follows the smell of pizza and takes a plane to Italy.");
                }

                else if(userData == "steak")
                {
                    Console.WriteLine("The NPC follows the smell of steak and steps on a bear trap.");
                }

                else
                {
                    // unexpected input
                    Console.WriteLine("The NPC gets hungry and goes back to his home.");
                }
            }

            else
            {
                //unexpected input
                Console.WriteLine("The NPC does not know what to do.");
            }
        }
    }
}
