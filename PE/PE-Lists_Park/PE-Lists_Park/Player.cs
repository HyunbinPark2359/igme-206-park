using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_Park
{
    internal class Player
    {
        // Two private fields
        private string name;
        private List<string> inventory;


        // Read-only property
        public string Name
        {
            get { return name; }
        }


        // Parameterized constructor
        public Player(string name)
        {
            this.name = name;
            inventory = new List<string>();
        }


        // Methods

        // Add the specified item to the player's inventory
        public void AddToInventory(string item)
        {
            inventory.Add(item);
            Console.WriteLine("Item '{0}' added to {1}'s inventory.", item, name);
        }

        // Remove the item at the specified index and return that item
        public string GetItemInSlot(int index)
        {
            if (index >= 0 && index < inventory.Count)
            {
                string stolenItem = inventory[index];
                Console.WriteLine("{0} stolen from slot {1} in {2}'s inventory!", stolenItem, index, name);
                inventory.RemoveAt(index);
                return stolenItem;
            }
            else
            {
                Console.WriteLine("{0} was not a valid item #!", index);
                return null;
            }
        }

        // Print the user's inventory
        public void PrintInventory()
        {
            Console.WriteLine("\n{0}'s Inventory:", name);

            foreach(string item in inventory)
            {
                Console.WriteLine("\t- {0}", item);
            }    
        }
    }
}
