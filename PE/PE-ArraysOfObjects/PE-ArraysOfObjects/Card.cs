using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects
{
    internal class Card
    {
        // Private fields
        private int value;      // The card's value (1-13)
        private string suit;    // The card's suit (Hearts, Clubs, etc.)


        // Parameterized constructor
        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        // Method
        // Print the card in format of "value of suit"
        public void Print()
        {
            // Print the value first
            switch(value)
            {
                // Value 1 is Ace
                case 1:
                    Console.Write("Ace");
                    break;

                // Value 2-10 are just numbers themselves
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Console.Write(value);
                    break;

                // Value 11 is Jack
                case 11:
                    Console.Write("Jack");
                    break;

                // Value 12 is Queen
                case 12:
                    Console.Write("Queen");
                    break;

                // Value 13 is King
                case 13:
                    Console.Write("King");
                    break;
            }

            // Print " of suit" after the value
            Console.WriteLine(" of {0}", suit);
        }
    }
}
