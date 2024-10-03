/*
 * Hyunbin Park
 * PE - Properties
 * https://docs.google.com/document/d/1z9HVMUdQWjPEswC2UwoDFwaoHdpaLT1Yvo7KtKBBaYs/edit?usp=sharing
 */

namespace PE_Properties_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define variables
            string title;       // Temporarily store the value of title
            string author;      // Temporarily store the value of author
            int numberOfPages;  // Temporarily store the value of number of pages
            string owner;       // Temporarily store the value of owner
            string userInput;   // Save the user's input


            // Welcome
            Console.WriteLine("Welcome to Book Simulator 2020");

            // Prompt for values to creat a Book object
            Console.Write("\nWhat is the book's title? ");
            title = Console.ReadLine();
            Console.Write("Who is the book's author? ");
            author = Console.ReadLine();
            Console.Write("How many pages does it have? ");
            numberOfPages = int.Parse(Console.ReadLine());
            Console.Write("Who is the book's current owner? ");
            owner = Console.ReadLine();

            // Creat a book object using user's inputs
            Book b1 = new Book(title, author, numberOfPages, owner);


            // Continually ask for input until they type "done"
            do
            {
                Console.Write("\nWhat would you like to do?  ");
                userInput = Console.ReadLine().ToLower().Trim();

                // Determines what to do depending on user's input
                switch(userInput)
                {
                    // Print the title of the book
                    case "title":
                        Console.WriteLine("The title is {0}.", b1.Title);
                        break;

                    // Print the author of the book
                    case "author":
                        Console.WriteLine("The author is {0}.", b1.Author);
                        break;

                    // Print the number of pages in the book
                    case "pages":
                        Console.WriteLine("The book has {0} pages.", b1.NumberOfPages);
                        break;

                    // Ask the user if they'd like to change the owner
                    case "owner":
                        Console.Write("Would you like to change the owner (yes/no)?  ");
                        userInput = Console.ReadLine().ToLower().Trim();

                        // If "yes", prompt for new owner and change the book's owner
                        if (userInput == "yes")
                        {
                            Console.Write("Who is the new owner?  ");
                            b1.Owner = Console.ReadLine();
                            Console.WriteLine("The new owner is {0}.", b1.Owner);
                        }
                        // If "no", simply print the book's current owner
                        else if (userInput == "no")
                        {
                            Console.WriteLine("Ok. {0} is still the owner.", b1.Owner);
                        }
                        break;

                    // Add one to the total times read and print it
                    case "read":
                        b1.TotalTimesRead++;
                        Console.WriteLine("The total times read is now {0}.", b1.TotalTimesRead);
                        break;

                    // Print all of the book's information
                    case "print":
                        b1.Print();
                        break;

                    // End the loop
                    case "done":
                        Console.WriteLine("Goodbye");
                        break;
                }
            }
            while(userInput != "done");
        }
    }
}
