using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenus
{
    /// <summary>
    /// Inherits core information about the data to manage and behavior
    /// from MenuItem and customizes it to represent a menu choice
    /// to make an addition problem and let the user solve it
    /// </summary>
    class AdditionItem : MenuItem
    {

        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Random rng;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public AdditionItem(string keyword, string description, string actionText, Random rng)
            : base(keyword, description, actionText)
        {
            this.rng = rng;
        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// Overrides the Run() method
        /// Generates two random integers and let the user solve its addition
        /// </summary>
        public override void Run()
        {
            // Setup
            Console.WriteLine(actionText);
            int a = rng.Next(10);
            int b = rng.Next(10);
            int answer = 0;
            Console.WriteLine("{0} + {1}", a, b);
            Console.Write("\n> ");
            
            // Make sure whole number is entered
            while (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.Write("\tPlease enter a valid whole number > ");
            }

            // Print result
            if (answer == a + b)
            {
                Console.WriteLine("You WIN!");
            }
            else
            {
                Console.WriteLine("The answer is {0}", a + b);
            }
        }
    }
}
