using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TheFarmstead
{
    /// <summary>
    /// Bin Park
    /// Purpose: Represent a crop in a farm
    /// </summary>
    internal class Crop
    {
        // Fields
        private string name;
        private double cost;
        private int growthTime;
        private int daysLeft;

        // Properties
        public bool CanHarvest
        {
            get
            {
                return daysLeft <= 0;
            }
        }
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public int DaysLeft
        {
            get
            {
                return daysLeft;
            }
            set
            {
                daysLeft = value;
            }
        }
        public int GrowthTime
        {
            get
            {
                return growthTime;
            }
            set
            {
                growthTime = value;
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
        public double SellingPrice
        {
            get
            {
                return cost * growthTime;
            }
        }

        // Parameterized constructor
        public Crop(string name, double cost, int growthTime)
        {
            this.Name = name;
            this.Cost = cost;
            this.GrowthTime = growthTime;
            this.daysLeft = growthTime;
        }

        /// <summary>
        /// Initializes a new instance of the Crop class as a copy of another crop.
        /// </summary>
        /// <param name="other">The crop to copy.</param>
        public Crop(Crop other)
            : this(other.name, other.cost, other.growthTime)
        {
            // No code here!
        }



        // Methods
        /// <summary>
        /// Decrement the days left until the crop is ready to harvest
        /// </summary>
        public void DayPassed()
        {
            if (daysLeft > 0)
            {
                daysLeft--;
            }
        }

        /// <summary>
        /// Return a string describing the crop's status
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (CanHarvest)
            {
                return String.Format("{0} ready to harvest for {1:C}", name, SellingPrice);
            }
            else
            {
                return String.Format("{0} has {1} days left to harvest", name, daysLeft);
            }
        }
    }
}
