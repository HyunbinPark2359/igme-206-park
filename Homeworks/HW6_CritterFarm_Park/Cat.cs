using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    /// <summary>
    /// Represent a cat who has their mood and like to cause mischief
    /// Inherited from abstract class Critter
    /// </summary>
    internal class Cat : Critter
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
        /// <param name="name">All cats must have a name</param>
        public Cat(string name)
            : base(name, CritterType.Cat)
        {
            this.name = name;
            Hunger = 2;
            UpdateMood();
        }

        /// <summary>
        /// Aceept the name and current hunger and boredom levels.
        /// Used when loading a save file.
        /// </summary>
        /// <param name="name">All cats must have a name</param>
        /// <param name="hungerLevel">Set the current level of hunger</param>
        /// <param name="boredomLevel">Set the current level of boredom</param>
        public Cat(string name, int hungerLevel, int boredomLevel)
            : base(name, CritterType.Cat, hungerLevel, boredomLevel)
        {
            this.name = name;
            UpdateMood();
        }

        /// <summary>
        /// Override the method from the parent class
        /// to set cat's mood based on its irritation level
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = Hunger + 2 * Boredom;

            if (irritationLevel > GenAngryLvl)
            {
                mood = CritterMood.Angry;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }

        /// <summary>
        /// Specialized method only for cat.
        /// The cat causes mischief which impacts their base stats
        /// by a random chance when the day passes.
        /// </summary>
        public void CauseMischief()
        {
            Console.WriteLine("{0} also gets joy out of randomly causing trouble!", name);

            // Decrease boredom level, but never beyond 0
            Boredom -= 2 * FunAmount;

            if (Boredom < 0)
            {
                Boredom = 0;
            }
        }
    }
}
