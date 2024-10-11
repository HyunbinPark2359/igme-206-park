using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Let's suppose the triangles here are equilateral
    /// Triangles are Shapes with 3 equal sides
    /// </summary>
    class Triangle : Shape
    {
        // Triangles all have the same length sides
        private double sideLength;

        // Create a new triangle using the base constructor to save the type
        public Triangle(double sideLength) : base("triangle")
        {
            this.sideLength = sideLength;
        }

        // Implement CalculateArea correctly for a triangle
        public override double CalculateArea()
        {
            return Math.Sqrt(3) * sideLength * sideLength / 4;
        }

        // Implement the Area property as well
        public override double Area
        {
            get
            {
                return Math.Sqrt(3) * sideLength * sideLength / 4;
            }
        }
    }
}
