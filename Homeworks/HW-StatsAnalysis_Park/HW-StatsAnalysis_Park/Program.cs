/*
 * Hyunbin Park
 * HW 2 - Stats Analysis
 * https://docs.google.com/document/d/13uxd-298WyJnL3v0W3L5OD_eGMS3xIth-ASy47Wy42s/edit?usp=sharing
 */

namespace HW_StatsAnalysis_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define variables for stats
            const int NumberOfPlayers = 2;
            string[] player = new string[NumberOfPlayers];
            int[] playerGamesPlayed = new int[NumberOfPlayers];
            int[] playerGamesWon = new int[NumberOfPlayers];
            int[] playerGamesLost = new int[NumberOfPlayers];
            double[] playerGamesPlayedHours = new double[NumberOfPlayers];

            // Stats with calculation
            double[] playerWinRate = new double[NumberOfPlayers];
            int[] playerAverageTime = new int[NumberOfPlayers];

            // There's an error in user's inputs if true
            bool errorOccurred = false;



            Console.ForegroundColor = ConsoleColor.White;
            // Default system font is white

            // Stats analyzer
            Console.WriteLine("========= STATS ANALYZER =========");

            // Prompt for stats for each player
            // Also check if stats for each player are flawless
            // User's inputs are shown in cyan
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                // Prompt for player's name
                Console.Write("\nEnter the name for Player {0}: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                player[i] = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;

                // Prompt for total games played
                Console.Write("Enter the number of games {0} played: ", player[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                playerGamesPlayed[i] = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                // Prompt for number of games won
                Console.Write("Enter the number of games {0} won: ", player[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                playerGamesWon[i] = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                // Prompt for number of games lost
                Console.Write("Enter the number of games {0} lost: ", player[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                playerGamesLost[i] = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                // Prompt for total number of hours played
                Console.Write("Enter the total time played by {0} in hours: ", player[i]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                playerGamesPlayedHours[i] = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;


                // Error messages
                // Player's name is empty
                // Error messages are shown in red
                if (player[i].Trim().Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Invalid name for player {0}", i + 1);
                    Console.ForegroundColor = ConsoleColor.White;

                    errorOccurred = true;
                }

                // Any numerical value is less than zero
                if (playerGamesPlayed[i] < 0 || playerGamesWon[i] < 0 || playerGamesLost[i] < 0 || playerGamesPlayedHours[i] < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Games & total play time must be non-negative numbers!");
                    Console.ForegroundColor = ConsoleColor.White;

                    errorOccurred = true;
                }

                // The games won and lost do not sum to the total games
                if (playerGamesPlayed[i] != playerGamesWon[i] + playerGamesLost[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                    Console.ForegroundColor = ConsoleColor.White;

                    errorOccurred = true;
                }

                // Either total games or play time is zero
                if (playerGamesPlayed[i] == 0 || playerGamesPlayedHours[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no play time!!");
                    Console.ForegroundColor = ConsoleColor.White;

                    errorOccurred = true;
                }

                // Any error automatically ends the program
                if (errorOccurred)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCannot continue with analysis. Goodbye.");
                    Console.ForegroundColor = ConsoleColor.White;

                    return; // Skip the rest of Main
                }

                // Automatically proceed to next player if no error occurred
            }


            // Summary Table
            // Provide player's stats, win rate, and average time per game
            Console.Write("\nSummary Table:\n\t\t\t");

            // Calculate win rate and average time per game for each player
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                playerWinRate[i] = (double)playerGamesWon[i] / playerGamesPlayed[i];
                playerAverageTime[i] = (int)(playerGamesPlayedHours[i] * 60 / playerGamesPlayed[i]);
            }
            
            // Show the list of players
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0}\t\t", player[i]);
            }

            // Show the games played for each player
            Console.Write("\n\tGames Played\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0}\t\t", playerGamesPlayed[i]);
            }

            // Show the games won for each player
            Console.Write("\n\tGames Won\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0}\t\t", playerGamesWon[i]);
            }

            // Show the games lost for each player
            Console.Write("\n\tGames Lost\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0}\t\t", playerGamesLost[i]);
            }

            // Show the total play time in hours for each player
            Console.Write("\n\tTotal Time (h)\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0:F1}\t\t", playerGamesPlayedHours[i]);
            }

            // Show the win percentage for each player
            Console.Write("\n\tWin Rate\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0:P3}\t\t", playerWinRate[i]);
            }

            // Show the average time per game for each player
            Console.Write("\n\tAvg Time (m)\t");
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write("{0}\t\t", playerAverageTime[i]);
            }
            Console.WriteLine("\n\n");


            // Show the player with better win rate
            // or if it's a draw
            if (playerWinRate[0] > playerWinRate[1])
            {
                Console.WriteLine("{0} has a better win rate!", player[0]);
            }
            else if (playerWinRate[0] == playerWinRate[1])
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine("{0} has a better win rate!", player[1]);
            }
            
        }
    }
}
