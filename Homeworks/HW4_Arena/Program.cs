/***
 * Hyunbin Park
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/1eOYYtup_hlHzLSw62bFBEFJY8Qm_7SFdtTi3FH8IIuw/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. Option #1: Random enemy placement
 *  2. Option #2: Enemy Customization
 *  
 * Optional extra upgrades:
 *  3. Option #3: Customize Console Interface
 *  4. Option #9: Experience Points
 *  
 * Known Bugs:
 * 
 * Other notes:
 * 
 */
namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;
        private const int Experience = 4;   // for Option #9
        private const int Level = 5;        // for Option #9

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 25;  // Changed from 50
        const int MaxExperience = 75;   // Required experience point for level up

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[6];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}, " +
                    $"EXP {stats[Experience]}/{MaxExperience}, " +
                    $"Level {stats[Level]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch(arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch(Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult)/2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if(numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Track the current health of the enemy
            int enemyCurrentHealth = EnemyMaxHealth;
            // Store the result of fight
            int result = -1;
            

            // Enemy Customization

            // Declare and initialize variables for enemy customization
            Random rng = new Random();                                                          // Random Object
            string[] enemyNames = new string[] {"angry goat", "sad frog", "happy cat", "doge"}; // Array of enemy names
            string enemyName = enemyNames[rng.Next(4)];                                         // Randomly select enemy name
            int[] enemyHealthMult = new int[] {1, 2, 3};                                        // Array of enemy health mult
            enemyCurrentHealth *= enemyHealthMult[rng.Next(3)];                                 // Randomly select enemy health mult

            // Experience Points

            // Defeating enemy will increase player's experience point worth of enemy's health
            int enemyExperience = enemyCurrentHealth;


            // Print a message that combat has started
            Console.WriteLine("A(n) {0} attacks you!", enemyName);

            // Loop a battle until the player wins, draws, loses, or runs
            do
            {
                // Print the current health of player and enemy
                Console.WriteLine("\nYour current health is {0}, the {1}'s health is {2}", stats[Health], enemyName, enemyCurrentHealth);

                // Prompt the player to take action and retrieve the input
                // and use switch statement to result in different output
                switch (SmartConsole.GetPromptedInput("What would you like to do? Attack/Run >"))
                {
                    // Player attacks
                    case "Attack":
                        // Player does damage to enemy
                        Console.WriteLine("You swing at the {0} doing {1} damage.", enemyName, stats[Strength] * DamageMult);
                        enemyCurrentHealth -= stats[Strength] * DamageMult;
                        // Enemy does damage to player
                        Console.WriteLine("The {0} charges at you for {1} damage!", enemyName, EnemyAttack - stats[Dexterity]);
                        stats[Health] -= EnemyAttack - stats[Dexterity];

                        // Player wins if the enemy dies and the player stays alive
                        if (enemyCurrentHealth <= 0 && stats[Health] > 0)
                        {
                            Console.WriteLine("You have defeated the beast! Congratulations!");
                            stats[Experience] += enemyExperience;
                            Console.WriteLine("You earned {0} experience points!", enemyExperience);
                            result = Win;
                        }

                        // Player draws if they both dies
                        else if (enemyCurrentHealth <= 0 && stats[Health] <= 0)
                        {
                            Console.WriteLine("You defeat the {0} with your last breath.", enemyName);
                            result = Draw;
                        }

                        // Player loses if the enemy stays alive and the player dies
                        else if (enemyCurrentHealth > 0 && stats[Health] <= 0)
                        {
                            Console.WriteLine("Your wounds are too much, the {0} wins this time.", enemyName);
                            result = Lose;
                        }

                        break;

                    // Player runs
                    case "Run":
                        result = Run;
                        break;

                    // Player enters anything else
                    default:
                        // Still the fight continues and the enemy does damage to player
                        Console.WriteLine("Command not recognized! Oh no! LOOK OUT!!");
                        Console.WriteLine("The {0} charges at you for {1} damage!", enemyName, EnemyAttack - stats[Dexterity]);
                        stats[Health] -= EnemyAttack - stats[Dexterity];

                        // Player loses if the player dies
                        if (stats[Health] <= 0)
                        {
                            Console.WriteLine("Your wounds are too much, the {0} wins this time.", enemyName);
                            result = Lose;
                        }

                        break;
                }
            }
            while (result == -1);


            string userInput = "";

            if (stats[Experience] >= MaxExperience)
            {
                stats[Level]++;
                Console.WriteLine("\n***Level Up!***");
                Console.WriteLine("\nYou gained one skill point!");

                do
                {
                    userInput = SmartConsole.GetPromptedInput("Which attribute do you want to enhance?\n" +
                                                              "\tStrength/Dexterity/Constitution >");

                    switch(userInput)
                    {
                        case "Strength":
                            Console.WriteLine("Strength has been enhanced.");
                            stats[Strength]++;
                            break;

                        case "Dexterity":
                            Console.WriteLine("Dexterity has been enhanced.");
                            stats[Dexterity]++;
                            break;

                        case "Constitution":
                            Console.WriteLine("Constitution has been enhanced.");
                            stats[Constitution]++;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Try again.\n");
                            userInput = "";
                            break;
                    }
                }
                while (userInput == "");

                stats[Experience] -= MaxExperience;
            }
            

            // Return the result of the battle
            return result;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Prompt the player for their name
            string name = SmartConsole.GetPromptedInput("Welcome, please enter your name: >");
            Console.WriteLine("\nHello {0}, I'll need a bit more information from you before we can start.\n" +
                              "You have 10 points to build your character and three attributes to allocate them to.\n", name);
            
            int min = 1;
            int max = 8;
            int statPoints = MaxPoints;

            // Prompt the player to assign skill points
            statsArray[Strength] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Strength? >", min, max);
            statPoints -= statsArray[Strength];
            Console.WriteLine("You have {0} points remaining.\n", statPoints);

            statsArray[Dexterity] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Dexterity? >", min, max);
            statPoints -= statsArray[Dexterity];
            Console.WriteLine("You have {0} points remaining.\n", statPoints);

            statsArray[Constitution] = SmartConsole.GetValidIntegerInput("How many points would you like to allocate to Constitution? >", min, max);
            statPoints -= statsArray[Constitution];
            statsArray[Health] = statsArray[Constitution] * HealthMult;
            Console.WriteLine("You left {0} points unused.\n", statPoints);


            // Initialize the experience point and the level of player
            statsArray[Experience] = 0;
            statsArray[Level] = 1;

            // Return the name of the player
            return name; // replace this. it's just so the starter code compiles.

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Prompt the player for the width and height of the arena
            int width = SmartConsole.GetValidIntegerInput("How wide should the arena be? (Enter a value from 10 to 50) >", 10, 50);
            int height = SmartConsole.GetValidIntegerInput("How tall should the arena be? (Enter a value from 10 to 50) >", 10, 50);
            Console.WriteLine();


            // ==== Random enemy placement =============================
            
            Random rng = new Random();          // Random object
            bool randomlyPlaceEnemy = false;    // Determine whether the enemies are randomly placed or not
            string userInput = "";              // Store the input from player

            // Ask the player if they want the enemies to be randomly placed
            do
            {
                userInput = SmartConsole.GetPromptedInput("Would you like the enemies to be randomly placed? Yes/No >");

                switch (userInput)
                {
                    // If yes, enemies will be placed randomly and the number of enemies is also randomly generated
                    case "Yes":
                        randomlyPlaceEnemy = true;
                        numEnemies = rng.Next(10) + 1;  // 1 - 10
                        break;

                    case "No":
                        randomlyPlaceEnemy = false;
                        break;

                    // Any else input will iterate the loop to ask again
                    default:
                        Console.WriteLine("Invalid input. Try again.\n");
                        userInput = "";
                        break;
                }
            }
            while (userInput == "");

            // =========================================================


            // Initialize the arena
            char[,] arena = new char[height, width];

            // Loop through arena
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    // Insert Wall along every border
                    if (i == 0 || i == arena.GetLength(0) - 1 || j == 0 || j == arena.GetLength(1) - 1)
                    {
                        arena[i, j] = Wall;
                    }

                    // Insert Enemies using the EnemySpacing constant and increment nunEnemies
                    // Won't execute if the player said yes for random enemy placement.
                    else if (i % EnemySpacing == 0 && j % EnemySpacing == 0 && !randomlyPlaceEnemy)
                    {
                        arena[i, j] = Enemy;
                        numEnemies++;
                    }

                    // Insert Empty space anywhere else
                    else
                    {
                        arena[i, j] = Empty;
                    }
                }
            }

            // Random enemy placement
            if (randomlyPlaceEnemy)
            {
                // Track the number of remaining enemies that has to be placed
                int numEnemiesNotPlaced = numEnemies;

                // Loop until all the enemies are placed in arena
                while (numEnemiesNotPlaced > 0)
                {
                    // Create the random coordinates of x and y
                    int i = rng.Next(arena.GetLength(0));
                    int j = rng.Next(arena.GetLength(1));

                    // Place an enemy on the coordinates if it's empty
                    if (arena[i, j] == Empty)
                    {
                        arena[i, j] = Enemy;
                        numEnemiesNotPlaced--;
                    }
                }
            }

            // Insert the PlayerStart in the top left corner and the Exit in the bottom right corner of the arena
            // Decrease the number of enemies if there's already an enemy where PlayerStart and Exit has to be placed
            if (arena[1, 1] == Enemy)
            {
                numEnemies--;
            }    
            arena[1, 1] = PlayerStart;

            if (arena[arena.GetLength(0) - 2, arena.GetLength(1) - 2] == Enemy)
            {
                numEnemies--;
            }
            arena[arena.GetLength(0) - 2, arena.GetLength(1) - 2] = Exit;


            // ==== Customize Console Interface ========================
            
            string consoleColor = ""; // Determine the color of the console

            do
            {
                // Prompt the player for the color of the console
                consoleColor = SmartConsole.GetPromptedInput("\nChoose the color of the console:\n" +
                                                             "\t- Magenta\n" +
                                                             "\t- Blue\n" +
                                                             "\t- Gray\n" +
                                                             "\t- Default\n" +
                                                             "\t>");
                
                // Change the console color corresponding to user's input
                switch (consoleColor)
                {
                    case "Magenta":
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        break;

                    case "Blue":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;

                    case "Gray":
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        break;

                    case "Black":
                    case "Default":
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    // Prompt again if anything else is entered
                    // and reset the value of consoleColor
                    default:
                        Console.WriteLine("Invalid input. Try again.\n");
                        consoleColor = "";
                        break;
                }
            }
            while (consoleColor == "");

            // =========================================================


            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Loop through the arena
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    // Change the color
                    switch(arena[i, j])
                    {
                        // Green for Wall
                        case Wall:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        // Red for Enemy
                        case Enemy:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        // Cyan for PlayerStart and Exit
                        case PlayerStart:
                        case Exit:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    // Print the player character if we arrive at the player's location
                    if (playerLoc[0] == i && playerLoc[1] == j)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Player);
                    }

                    // Otherwise, just print what's in there
                    else
                    {
                        Console.Write(arena[i, j]);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}