/*
 * Hyunbin Park
 * HW 5 - The Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

using HW5_FarmingSim;

namespace HW_TheFarmstead
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Local variables
            Farm myFarm;
            Crop[] availableCrops;

            // Prompt for number of crops to define
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!" +
                "\n Start your farming journey by defining the crops available and naming your farm.");
            availableCrops = new Crop[SmartConsole.GetValidNumericInput("\nHow many types of crops do you want to define?", 1, 5)];

            // Prompt for name, cost, and days to grow for each crop
            for (int i = 0; i < availableCrops.Length; i++)
            {
                Crop temporaryCrop;
                Console.WriteLine("\nDefine crop type #{0}", i + 1);
                temporaryCrop = new Crop(SmartConsole.GetPromptedInput("  Name:"), 
                    SmartConsole.GetValidNumericInput("  Cost:", 1.0, 500.0),
                    SmartConsole.GetValidNumericInput("  Days until harvest:", 1, 10));
                availableCrops[i] = temporaryCrop;
            }

            // Prompt for the required info for farm including
            // its name, number of fields, starting money, and daily maintenance cost
            myFarm = new Farm(SmartConsole.GetPromptedInput("\nPlease name your farm:"), availableCrops,
                SmartConsole.GetValidNumericInput("\nHow many fields are available for planting?", 1, 5),
                SmartConsole.GetValidNumericInput("\nHow much money are you starting with?", 1, 1000),
                SmartConsole.GetValidNumericInput("\nWhat is the daily maintenance cost?", 1, 50));

            Console.WriteLine("\n*** {0}, ready for a fruitful season! ***", myFarm.Name);

            // Store user's choice
            int userChoice = -1;

            // Game loop until the user manually quits
            // or the farm is out of money
            do
            {
                // Print the farm's status and prompt for what to do today
                myFarm.PrintStatus();
                Console.WriteLine("\n  1. Plant crops" +
                    "\n  2. Harvest and sell produce" +
                    "\n  3. Do nothing today" +
                    "\n  4. Quit");

                // Act accordingly
                switch(userChoice = SmartConsole.GetValidNumericInput("> ", 1, 4))
                {
                    // Plant a crop and pass to next day
                    case 1:
                        myFarm.Plant();
                        myFarm.DayPassed();
                        break;

                    // Harvest a crop and pass to next day
                    case 2:
                        myFarm.Harvest();
                        myFarm.DayPassed();
                        break;

                    // Pass to next day
                    // Additionally quit the game if 4
                    case 3:
                    case 4:
                        myFarm.DayPassed();
                        break;
                }
            }
            while (userChoice != 4 && myFarm.Money > 0);

            // Print a message including the money if the user manually quit the game
            if (userChoice == 4)
            {
                SmartConsole.PrintSuccess(String.Format("\nYou quit with {0:C} in the bank!", myFarm.Money));
            }
            // Print a message informing the farm ran out of money if the game ended because of it
            else if (myFarm.Money <= 0)
            {
                SmartConsole.PrintError(String.Format("\n{0} ran out of money!", myFarm.Name));
            }
        }
    }
}
