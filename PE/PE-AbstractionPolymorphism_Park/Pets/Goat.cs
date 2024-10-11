using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    /// <summary>
    /// Goats are Pets that say bleat
    /// </summary>
    internal class Goat : Pet
    {
        // The parameterized Goat constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Goat(string name, DateTime birthday)
            : base(name, birthday, "goat")
        {
        }

        // We also want to override Speak so that this Goat can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says BLEAT.");
        }
    }
}
