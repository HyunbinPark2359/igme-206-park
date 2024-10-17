using HW5_FarmingSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TheFarmstead
{
    /// <summary>
    /// Bin Park
    /// Purpose: Keep track of the elements of farm including crops and money
    /// and plant and harvest the crops
    /// </summary>
    internal class Farm
    {
        // Fields
        private string name;
        private double money;
        private double maintenanceCost;
        private Crop[] availableCrops;
        private Crop[] currentCrops;
        private Random rng;
        private int daysPassed;

        // Properties
        public double Money
        {
            get 
            { 
                return money; 
            }
            set 
            { 
                money = value; 
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // Parameterized constructor
        public Farm(string name, Crop[] availableCrops, int numFields, double money, double maintenanceCost)
        {
            this.name = name;
            this.availableCrops = availableCrops;
            currentCrops = new Crop[numFields];
            this.money = money;
            this.maintenanceCost = maintenanceCost;
            daysPassed = 0;
            rng = new Random();
        }

        // Methods
        /// <summary>
        /// Process a day on the farm and weather events
        /// </summary>
        public void DayPassed()
        {
            // Decrement the money by daily maintenance cost
            money -= maintenanceCost;
            // Chance of weather in random
            int weather = rng.Next(100);

            // 5% chance of a blight
            if (weather < 5)
            {
                // Reset all current crops
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    currentCrops[i] = null;
                }
                // Print a message
                SmartConsole.PrintError("Blight has struck the farm!" +
                    "\nAll our crops are dead! :(");
            }
            // 20% chance of rain
            else if (weather >= 5 && weather < 25)
            {
                // Skip growth and print a message
                SmartConsole.PrintWarning("It rained. Nothing grew today." +
                    "\nHopefully tomorrow will be better.");
            }
            // Good weather otherwise
            else
            {
                // Current crops grow as day passes
                foreach (Crop crop in currentCrops)
                {
                    if (crop != null)
                    {
                        crop.DayPassed();
                    }
                }
            }

            daysPassed++;
        }

        /// <summary>
        /// Plant a crop on the empty field
        /// </summary>
        public void Plant()
        {
            // Look for empty field
            for (int i = 0; i < currentCrops.Length; i++)
            {
                // If the program finds an empty field
                if (currentCrops[i] == null)
                {
                    // Prompt for a crop to plant
                    Console.WriteLine("\nSelect a crop to plant:");
                    for (int j = 0; j < availableCrops.Length; j++)
                    {
                        Console.WriteLine("  {0}. {1} (Cost: {2:C})", j + 1, availableCrops[j].Name, availableCrops[j].Cost);
                    }
                    int cropToPlant = SmartConsole.GetValidNumericInput(">", 1, availableCrops.Length);

                    // If we have enough money for that crop
                    if (money >= availableCrops[cropToPlant - 1].Cost)
                    {
                        // Assign the empty field to the new crop reference
                        currentCrops[i] = new Crop(availableCrops[cropToPlant - 1]);
                        // Decrement the money
                        money -= availableCrops[cropToPlant - 1].Cost;
                        // Print the message
                        SmartConsole.PrintSuccess(String.Format("{0} planted in field #{1}", availableCrops[cropToPlant - 1].Name, i + 1));
                    }
                    // Print an error message if we don't have enough money
                    else
                    {
                        SmartConsole.PrintError("You don't have enough money to plant that.");
                    }

                    return;
                }
            }
            // Print an error message if there are no empty fields
            SmartConsole.PrintError("Unable to print right now. Harvest something first.");
        }

        /// <summary>
        /// Harvest a fully grown crop on the field
        /// </summary>
        public void Harvest()
        {
            // See if there's at least one field planted
            for (int i = 0; i < currentCrops.Length;i++)
            {
                // If there's a field planted
                if (currentCrops[i] != null)
                {
                    // Prompt for which field to harvest
                    Console.WriteLine("\nWhich field would you like to harvest?");
                    BuildFieldList();
                    int cropToHarvest = SmartConsole.GetValidNumericInput(">", 1, currentCrops.Length);

                    // If the chosen field is empty
                    if (currentCrops[cropToHarvest - 1] == null)
                    {
                        // Print a message
                        SmartConsole.PrintError(String.Format("You have to plant something in field {0} first!", cropToHarvest));
                    }
                    // If the chosen field can be harvested
                    else if (currentCrops[cropToHarvest - 1].CanHarvest)
                    {
                        // Increment the money by selling price of the crop in that field
                        money += currentCrops[cropToHarvest - 1].SellingPrice;
                        // Print a message
                        SmartConsole.PrintSuccess(String.Format("Sold {0} for {1}", currentCrops[cropToHarvest - 1].Name, currentCrops[cropToHarvest - 1].SellingPrice));
                        // Reset that field
                        currentCrops[cropToHarvest - 1] = null;
                    }
                    // If the chosen field cannot be harvested
                    else if (!currentCrops[cropToHarvest - 1].CanHarvest)
                    {
                        // Print a message
                        SmartConsole.PrintError(String.Format("Field {0} isn't ready yet!", cropToHarvest));
                    }
                    return;
                }
            }
            // Print an error message if there's no field planted
            SmartConsole.PrintError("You have to plant something first!");
        }

        /// <summary>
        /// Print the current farm status including fields
        /// </summary>
        public void PrintStatus()
        {
            // Calculate the total potential earnings
            double potentialEarnings = 0;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] != null && currentCrops[i].CanHarvest)
                {
                    potentialEarnings += currentCrops[i].SellingPrice;
                }
            }

            // Print a status message
            Console.WriteLine("\nDay {0} at {1} with {2:C} on hand." +
                "\nWe have {3:C} potential earnings from the fields ready to harvest.", 
                1 + daysPassed, name, money, potentialEarnings);
            BuildFieldList();
        }

        /// <summary>
        /// Print the list of the fields' status
        /// </summary>
        public void BuildFieldList()
        {
            // Loop through the fields
            for (int i = 0; i < currentCrops.Length; i++)
            {
                // Print the status of the field planted
                if (currentCrops[i] != null)
                {
                    Console.WriteLine(" - Field {0}: {1}",
                        i + 1, currentCrops[i].ToString());
                }
                // Print the empty field
                else
                {
                    Console.WriteLine(" - Field {0}: Empty", i + 1);
                }
            }
        }
    }
}
