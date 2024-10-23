using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    /// <summary>
    /// Represent a horse who has their mood
    /// Inherited from abstract class Critter
    /// </summary>
    internal class Horse : Critter
    {
        // ----------------------------------------------------------------------
        // Constructors
        // Two public, parameterized constructors that appropriately leverage
        // the base class constructor to initialize class fields
        // ----------------------------------------------------------------------

        /// <summary>
        /// Accept only the new critter name and use default values 
        /// for the hunger and boredom levels.
        /// Used when setup critters when starting a new game
        /// </summary>
        /// <param name="name">All horses must have a name</param>
        public Horse(string name)
            : base(name, CritterType.Horse)
        {
            this.name = name;
            UpdateMood();
        }

        /// <summary>
        /// Aceept the name and current hunger and boredom levels.
        /// Used when loading a save file.
        /// </summary>
        /// <param name="name">All horses must have a name</param>
        /// <param name="hungerLevel">Set the current level of hunger</param>
        /// <param name="boredomLevel">Set the current level of boredom</param>
        public Horse(string name, int hungerLevel, int boredomLevel)
            : base(name, CritterType.Horse, hungerLevel, boredomLevel)
        {
            this.name = name;
            UpdateMood();
        }

        /// <summary>
        /// Override the method from the parent class
        /// to set horse's mood based on its irritation level
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = 2 * Hunger + Boredom;

            if (irritationLevel > GenAngryLvl)
            {
                mood = CritterMood.Angry;
            }
            else if (irritationLevel > GenFrustrationLvl)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }
    }
}
