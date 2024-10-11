﻿namespace DynamicMenus
{
    class Program
    {
        static void Main(string[] args)
        {
            // ~~~ Variables we'll need + their initializations ~~
            // Create some menu items. Yes, ideally, these would all be in an array so we could loop
            // over them later, but they are all different types. We'll discuss how to make that
            // work later.
            MenuItem helloWorld = new MenuItem("Hello", "Say hello", "Hello GDAPS1!");
            GetTimeItem getTime = new GetTimeItem("time", "Get the current time", "The current time is: ");
            string difficulty = "hard";
            GameItem game = new GameItem(difficulty, "Play a " + difficulty.ToLower() + " game", 
                "Guess the lucky number (0-100)!", 1, difficulty, new Random());
            AdditionItem addition = new AdditionItem("add", "Solve an addition problem", 
                "What is the answer of following problem? ", new Random());

            // while true so the menu runs forever for demo purposes
            // Use Ctrl-C to quit.
            string choice = null;

            // ~~~ The main "game" loop ~~~
            while (choice != "QUIT")
            {
                // Print the menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine(helloWorld);
                Console.WriteLine(getTime);
                Console.WriteLine(game);
                Console.WriteLine(addition);
                Console.WriteLine("\tQUIT: say goodbye.");

                // Get and act on response
                Console.Write("> ");
                choice = Console.ReadLine().Trim().ToUpper();

                // A switch would be ideal here, but can't be used with non-constant
                // cases (i.e. it won't work with the Keyword property)
                if (choice == helloWorld.Keyword)
                {
                    helloWorld.Run();
                }
                else if (choice == getTime.Keyword)
                {
                    getTime.Run();
                }
                else if (choice == game.Keyword)
                {
                    game.Run();
                }
                else if (choice == addition.Keyword)
                {
                    addition.Run();
                }
                else if(choice != "QUIT")
                {
                    Console.WriteLine("I don't know how to do that!");
                }
                // Otherwise, we're quitting, so do nothing and say goodbye once we exit the loop
            }

            // ~~~ All done ~~~
            Console.WriteLine("Goodbye!");
        }
    }
}
