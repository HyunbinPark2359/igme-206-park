using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArraysOfObjects
{
    internal class Deck
    {
        // Private fields
        private Random rng;     // Random object
        private Card[] cards;   // Array of card objects


        // Constructor
        public Deck()
        {
            cards = new Card[52];   // Array holds excatly 52 cards
            rng = new Random();     // Create the random number generator

            // Traverse through the array and store each cards in a unique position
            // First loop for every possible suits and second loop for every possible values
            string[] suits = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cards[i * 13 + j] = new Card(j + 1, suits[i]);
                }
            }
        }


        // Methods

        // Print the entire deck of cards
        public void Print()
        {
            Console.WriteLine("Your deck:");
            for (int i = 0; i < cards.Length;i++)
            {
                Console.Write(" - ");
                cards[i].Print();
            }
            Console.WriteLine();
        }

        // Print a random selection of cards
        public void Deal(int amount)
        {
            Console.WriteLine("\nYour hand:");
            for (int i = 0; i < amount; i++)
            {
                Console.Write(" - ");
                cards[rng.Next(cards.Length)].Print();
            }
        }
    }
}
