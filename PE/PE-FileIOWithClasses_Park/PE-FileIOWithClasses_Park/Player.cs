using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_FileIOWithClasses_Park
{
    /// <summary>
    /// Bin Park
    /// Purpose: Store the data of the player
    /// </summary>
    internal class Player
    {
        // Private fields
        private string name;
        private int strength;
        private int health;

        // Parameterized constructor
        public Player(string name, int strength, int health)
        {
            this.name = name;
            this.strength = strength;
            this.health = health;
        }

        // Properties
        public string Name
            { get { return name; } }

        public int Strength
            { get { return strength; } }

        public int Health
            { get { return health; } }

        /// <summary>
        /// Builds a line of string containing all of the player's info
        /// </summary>
        /// <returns>A string containing all of the player's info</returns>
        public string ToString()
        {
            return String.Format("Player: {0}. Strength {1}, Health {2}.", 
                                 name, strength, health);
        }
    }
}
