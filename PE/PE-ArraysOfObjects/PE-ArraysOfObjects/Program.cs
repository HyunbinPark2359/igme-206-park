/*
 * Hyunbin Park
 * PE - Arrays of Objects
 * https://docs.google.com/document/d/1RuAfFYOzlZvX37DgXFVvGX3zMuygVVrpJn4Wg7Fvt-Q/edit?usp=sharing
 */

namespace PE_ArraysOfObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a deck object
            Deck deck = new Deck();

            // Print the entire deck
            deck.Print();

            // Prompt for the number of cards to deal
            Console.Write("Enter a number of cards to deal (1-52): ");
            // Print randomly selected cards
            deck.Deal(int.Parse(Console.ReadLine()));
        }
    }
}
