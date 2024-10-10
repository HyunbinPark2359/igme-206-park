using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PE_FileIOWithClasses_Park
{
    /// <summary>
    /// Bin Park
    /// Purpose: Keep track of multiple players in a List of Player objects
    /// Restrictions: Inherited from class Player.
    /// </summary>
    internal class PlayerManager
    {
        // Private fields
        // Directory of a file
        private string filename;
        // List of Player objects
        private List<Player> players;

        /// <summary>
        /// Constructor initializes filename and players
        /// </summary>
        public PlayerManager()
        {
            filename = "../../../players.txt";
            players = new List<Player>();
        }


        /// <summary>
        /// Creates a new Player object with the specified name, strength, and health
        /// Adds it to the list of Players
        /// Prints a confirmation message
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="strength">The strength value of the player</param>
        /// <param name="health">The health value of the player</param>
        public void CreatePlayer(string name, int strength, int health)
        {
            Player p1 = new Player(name, strength, health);
            players.Add(p1);
            Console.WriteLine("\tAdded {0} to the list.", name);
        }


        /// <summary>
        /// Print all Players in the list
        /// </summary>
        public void Print()
        {
            // Print only if at least one player exists in the list
            if (players.Count > 0)
            {
                foreach (Player p in players)
                {
                    Console.WriteLine("\t" + p.ToString());
                }
            }
            // Print an error message instead if there are no players yet
            else
            {
                Console.WriteLine("\tThere are no players yet.");
            }
        }

        /// <summary>
        /// Loads the player data from the file
        /// and uses that data to create a new Player and adds it to the list
        /// Print a confirmation message
        /// </summary>
        public void Load()
        {
            // Clear the list if it already has Players
            if (players.Count > 0)
            {
                players.Clear();
            }

            // Declare the reader
            StreamReader reader = null;

            try
            {
                // Open the file and get the line of string from it
                reader = new StreamReader(filename);

                // First check if there is a player data in a file
                string line = "";
                if ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("\tLoading data from players.txt");

                    // Loop through the file
                    do
                    {
                        string[] data = line.Split(',');
                        CreatePlayer(data[0], int.Parse(data[1]), int.Parse(data[2]));
                    }
                    while ((line = reader.ReadLine()) != null) ;

                    // Print confirmation message
                    Console.WriteLine("\tLoaded all data from file.\n" +
                                      "\t{0} players created.", players.Count);
                }
                // Print if there is no player data in a file
                else
                {
                    Console.WriteLine("\tThere is no player data to load.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError reading file: " + e.Message);
            }

            // Close the file if it was opened
            if (reader != null)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Saves the player data to the file
        /// Print a confirmation message
        /// </summary>
        public void Save()
        {
            // Declare the writer
            StreamWriter writer = null;

            try
            {
                // Open the file, create one if doesn't exist
                writer = new StreamWriter(filename);

                // First check if there are Players in the list
                if (players.Count > 0)
                {
                    // Loop through the List and write the Players to the file
                    // One Player for each line
                    foreach (Player p in players)
                    {
                        writer.WriteLine("{0},{1},{2}", p.Name, p.Strength, p.Health);
                    }

                    // Print confirmation message
                    Console.WriteLine("\tSaved {0} players to file players.txt", 
                                      players.Count);
                }
                // Print if there is no player in the List
                else
                {
                    Console.WriteLine("\tThere is no player data yet.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\tError writing: " + e.Message);
            }

            // Close the file if it was opened
            if (writer != null)
            {
                writer.Close();
            }
        }
    }
}
