/*
 * Hyunbin Park
 * PE - String Formatting
 * https://docs.google.com/document/d/1cSjoItBB29vQMierRirOugLgHEsvWvopl3NMiyo79Yg/edit?usp=sharing
 */

namespace PE_StringFormatting_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            // a constant template text used whenever the player's stat is updated
            const string StatsUpdateTemplate = "{0}, you now have {1} health and {2:C} remaining.";
            // varables for player
            string name;
            string title;
            string nameWithTitle;
            int health = 100;
            double wallet;
            string action;
            int actionHealthReq;
            string item;
            double itemCost;


            
            // Greeting
            // retrieve the name, title, and wallet balance from user
            Console.Write("What is your name brave adventurer? ");
            name = Console.ReadLine();
            Console.Write("What is your title? ");
            title = Console.ReadLine();
            Console.Write("How much money are you carrying? $");
            wallet = double.Parse(Console.ReadLine());

            // combine the player's name and title
            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.WriteLine("Welcome {0}!", nameWithTitle);



            // Action
            // retrieve what action they do and health required for that
            Console.Write("\nWhat do you want to do next? ");
            action = Console.ReadLine();
            Console.Write("How much health does it take to do this? ");
            actionHealthReq = int.Parse(Console.ReadLine());

            // perform an action and update the health
            // print out the resulting stats
            Console.WriteLine(String.Format("\nOkay, let's see you {0}!", action));
            health -= actionHealthReq;
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);



            // Buying
            // retrieve an item to buy and its cost
            Console.Write("\nWhat do you want to buy? ");
            item = Console.ReadLine();
            Console.Write("How much does it normally cost? $");
            itemCost = double.Parse(Console.ReadLine());

            // buy an item and update the wallet balance
            // print out the resulting stats
            Console.WriteLine(String.Format("\nYou bought catnip for {0:C3}!", (itemCost * 1.1)));
            wallet -= itemCost * 1.1;
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
