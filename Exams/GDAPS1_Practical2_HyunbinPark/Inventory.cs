//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDAPS1_Practical2
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            // TODO: Complete the property
            get 
            {
                return items.Count; // REPLACE
            }
        }

        /// <summary>
        /// TODO: Complete the AddItem method to add a provided Item reference
        /// into the inventory list
        /// </summary>
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// TODO: Complete the PrintSummary method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
            // Loop through the inventory and print the items in there
            Console.WriteLine($"The inventory currently has {NumberItems} item(s):");
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }

            // Print total weight and damages
            Console.WriteLine("Total weight: " + CalculateTotalWeight());
            Console.WriteLine("Total damage from weapon(s): " + CalculateTotalDamage());
        }


        /// <summary>
        /// TODO: Complete the CalculateTotalWeight method to return the total
        /// weight of all items in the inventory
        /// </summary>
        private double CalculateTotalWeight()
        {
            double total = 0;

            // Loop through the inventory and add the weights
            foreach (Item item in items)
            {
                total += item.Weight;
            }
            return total;
        }

        /// <summary>
        /// TODO: Complete CalculateTotalWeight method to return the total
        /// damage of all weapons in the inventory
        /// </summary>
        private double CalculateTotalDamage()
        {
            double total = 0;

            // Loop through the inventory and add the damages of the weapons
            foreach (Item item in items)
            {
                // First determine if the item is Weapon
                // If so, add its damage to the total
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;
                    total += weapon.Damage;
                }
            }
            return Math.Round(total, 2);
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            // Declare it outside of try block for further use
            StreamReader input = null;

            // TODO: Add exception handling
            try
            {
                // Open and read the file
                input = new StreamReader(filename);

                // Read the file and get the lines until it reaches the end
                string line = null;
                while ((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                    string[] data = line.Split("~");

                    // Determine if the line is the data of Weapon or Food
                    // If it is Weapon, Initialize new weapon and add it to the inventory
                    if (data[0] == "Weapon")
                    {
                        Weapon weapon = new Weapon(data[1], int.Parse(data[2]), double.Parse(data[3]));
                        AddItem(weapon);
                    }
                    // If it is Food, initialize new Food and add it to the inventory
                    else if (data[0] == "Food")
                    {
                        Food food = new Food(data[1], int.Parse(data[2]), double.Parse(data[3]));
                        AddItem(food);
                    }
                }
            }
            catch (Exception ex)
            {
                // Print an error message
                Console.WriteLine("Uh oh: " + ex.Message);
            }

            // Close the file if it ever opened
            if (input != null)
            {
                input.Close();
            }
        }

        /// <summary>
        /// Complete the LightenLoad method to drop heavy items
        /// </summary>
        public void LightenLoad()
        {
        }
    }
}
