using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Let's suppose the octagons here are equilateral
    /// Octagons are Shapes with 3 equal sides
    /// </summary>
    class Octagon : Shape
    {
        // Octagons all have the same length sides
        private double sideLength;

        // Create a new octagon using the base constructor to save the type
        public Octagon(double sideLength) : base("octagon")
        {
            this.sideLength = sideLength;
        }

        // Implement CalculateArea correctly for a octagon
        public override double CalculateArea()
        {
            return 2 * (1 + Math.Sqrt(2)) * sideLength * sideLength;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return 2 * (1 + Math.Sqrt(2)) * sideLength * sideLength;
            }
        }
    }
}
