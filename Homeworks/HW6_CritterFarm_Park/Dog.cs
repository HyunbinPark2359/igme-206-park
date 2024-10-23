using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm
{
    /// <summary>
    /// Represent a dog who has their mood and like to run around the house
    /// Inherited from abstract class Critter
    /// </summary>
    internal class Dog : Critter
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
        /// <param name="name">All dogs must have a name</param>
        public Dog(string name)
            : base(name, CritterType.Dog)
        {
            this.name = name;
            Hunger = 5;
            Boredom = 5;
            UpdateMood();
        }

        /// <summary>
        /// Aceept the name and current hunger and boredom levels.
        /// Used when loading a save file.
        /// </summary>
        /// <param name="name">All dogs must have a name</param>
        /// <param name="hungerLevel">Set the current level of hunger</param>
        /// <param name="boredomLevel">Set the current level of boredom</param>
        public Dog(string name, int hungerLevel, int boredomLevel)
            : base(name, CritterType.Dog, hungerLevel, boredomLevel)
        {
            this.name = name;
            UpdateMood();
        }

        /// <summary>
        /// Override the method from the parent class
        /// to set dog's mood based on its irritation level
        /// </summary>
        protected override void UpdateMood()
        {
            int irritationLevel = Hunger + Boredom;

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

        /// <summary>
        /// Specialized method only for dog.
        /// The dog runs around the house which impacts their base stats
        /// by a random chance when the day passes.
        /// </summary>
        public void RunAround()
        {
            Console.WriteLine("{0} also gets tired after running around the house!", name);

            // Decrease boredom level by half of FunAmount, but never beyond 0
            // Increase hunger level by half of FunAmount
            Boredom -= FunAmount / 2;
            Hunger += FunAmount / 2;

            if (Boredom < 0)
            {
                Boredom = 0;
            }
        }
    }
}
