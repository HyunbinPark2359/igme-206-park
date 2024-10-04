/*
 * Hyunbin Park
 * PE - Lists
 * https://docs.google.com/document/d/1yr-JcmbBOSWCzaoHlt7F1n6dnWku0ZKLwbX_2kfBm_w/edit?usp=sharing
 */

using System;
using System.Xml.Linq;

namespace PE_Lists_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            Random rng = new Random();  // Random object
            Player p1;                  // Player 1
            Player p2;                  // Player 2
            string userInput;


            // Prompt for two player names and create the corresponding Player objects
            Console.Write("Enter Player 1's name: ");
            p1 = new Player(Console.ReadLine());
            Console.Write("Enter Player 2's name: ");
            p2 = new Player(Console.ReadLine());
            Console.WriteLine();

            // Prompt for 5 items
            for (int i = 0; i < 5; i++)
            {
                // Get the item name
                Console.Write("Enter an item: ");

                // New random double
                double randomNumber = rng.NextDouble();

                // If the random number is above 0.5,
                // add the current item to player 1's inventory
                if (randomNumber > 0.5)
                {
                    p1.AddToInventory(Console.ReadLine());
                }
                // Otherwise, add it to player 2's inventory
                else
                {
                    p2.AddToInventory(Console.ReadLine());
                }
            }

            // Print each player's inventory
            p1.PrintInventory();
            p2.PrintInventory();


            // Track stolen items
            List<string> stolenItems = new List<string>();

            // Prompt for input between print, steal, or quit until the user enters "quit"
            do
            {
                Console.Write("\nEnter a command (print, steal, or quit) or an item: ");
                userInput = Console.ReadLine().ToLower().Trim();

                switch (userInput)
                {
                    // Print each player's inventory
                    case "print":
                        p1.PrintInventory();
                        p2.PrintInventory();
                        break;

                    // Steal an item from player
                    case "steal":
                        // Prompt for which player to steal from
                        Console.Write("Which player would you like to steal from (1 or 2)? ");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            // From Player 1
                            case 1:
                                // Prompt for the index of item to steal
                                // and call the GetItemInSlot() method
                                Console.Write("Which item # would you like to steal from {0}? ", 
                                              p1.Name);
                                string item = p1.GetItemInSlot(int.Parse(Console.ReadLine()));

                                // Track stolen items
                                if (item != null)
                                {
                                    stolenItems.Add(item);
                                }
                                break;

                            // From Player 2
                            case 2:
                                // Prompt for the index of item to steal
                                // and call the GetItemInSlot() method
                                Console.Write("Which item # would you like to steal from {0}? ", 
                                              p2.Name);
                                item = p2.GetItemInSlot(int.Parse(Console.ReadLine()));

                                // Track stolen items
                                if (item != null)
                                {
                                    stolenItems.Add(item);
                                }
                                break;
                        }
                        break;
                        
                    // Exit the loop and print the list of stolen items
                    case "quit":
                        Console.WriteLine("\nYou stole {0} item(s):", stolenItems.Count);

                        foreach (string item in stolenItems)
                        {
                            Console.WriteLine("\t{0}", item);
                        }
                        break;

                    // Add it to player's inventory (random)
                    default:
                        double randomNumber = rng.NextDouble();
                        if (randomNumber > 0.5)
                        {
                            p1.AddToInventory(userInput);
                        }
                        else
                        {
                            p2.AddToInventory(userInput);
                        }
                        break;
                }
            }
            while (userInput != "quit");
        }
    }
}
