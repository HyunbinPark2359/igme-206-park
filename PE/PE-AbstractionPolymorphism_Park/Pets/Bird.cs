using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Polymorphism_Demo.Pets
{
    /// <summary>
    /// Birds are Pets that say chirp
    /// </summary>
    internal class Bird : Pet
    {
        // The parameterized Bird constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Bird(string name, DateTime birthday)
            : base(name, birthday, "bird")
        {
        }

        // We also want to override Speak so that this Bird can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says CHIRP.");
        }
    }
}
