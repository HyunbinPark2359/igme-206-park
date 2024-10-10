/*
 * Hyunbin Park
 * PE - File IO with Classes
 * https://docs.google.com/document/d/1bdEwXtXEnyY2xfeDdS7XJ7FMqHUE0IzZn2OLopcwEwU/edit?usp=sharing
 */

namespace PE_FileIOWithClasses_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a PlayerManager object
            PlayerManager playerManager = new PlayerManager();
            // Store user's data
            string userInput;

            do
            {
                // Prompt for commands
                Console.Write("Create. Print. Save. Load. Quit. >> ");
                userInput = Console.ReadLine().ToLower().Trim();

                // Handle the command
                switch(userInput)
                {
                    // Get the data from the user and make a new Player object
                    case "create":
                        Console.Write("\tWhat is the player's name? ");
                        string name = Console.ReadLine().Trim();
                        Console.Write("\tPlayer's strength? ");
                        int strength = int.Parse(Console.ReadLine().Trim());
                        Console.Write("\tPlayer's health? ");
                        int health = int.Parse(Console.ReadLine().Trim());

                        playerManager.CreatePlayer(name, strength, health);

                        break;

                    // Call Print() in the PlayerManager() class
                    case "print":
                        playerManager.Print();
                        break;

                    // Call Save() in the PlayerManager() class
                    case "save":
                        playerManager.Save();
                        break;

                    // Call Load() in the PlayerManager() class
                    case "load":
                        playerManager.Load();
                        break;

                    // Call Quit() in the PlayerManager() class
                    case "quit":
                        Console.WriteLine("\tGoodbye!");
                        break;
                }

                Console.WriteLine();
            }
            while (userInput != "quit");
        }
    }
}
