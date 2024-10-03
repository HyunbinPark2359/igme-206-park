using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Properties_Park
{
    internal class Book
    {
        // 5 Private fields
        private string title;       // The title of book
        private string author;      // The author of book
        private int numberOfPages;  // The number of pages in book
        private string owner;       // The owner of book
        private int totalTimesRead; // How many times the owner read the book


        // Parameterized constructor
        public Book(string title, string author, int numberOfPages, string owner)
        {
            this.title = title;
            this.author = author;
            this.numberOfPages = numberOfPages;
            this.owner = owner;
            totalTimesRead = 0;
        }


        // 3 get-only properties and 2 get & set properties

        // Get the title of book
        public string Title
        {
            get { return title; }
        }

        // Get the author of book
        public string Author
        {
            get { return author; }
        }

        // Get the number of pages
        public int NumberOfPages
        {
            get { return numberOfPages; }
        }

        // Get and set the owner of the book
        public string Owner
        {
            get { return owner; }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    owner = value;
                }
            }
        }

        // Get and set the number of times read the book
        public int TotalTimesRead
        {
            get { return totalTimesRead; }
            set
            {
                if (totalTimesRead < value)
                {
                    totalTimesRead = value;
                }
            }
        }


        // Method

        // Print all of the book's information
        public void Print()
        {
            Console.WriteLine("{0} by {1} has {2} pages. It is owned by {3} and has been read {4} times.", 
                              title, author, numberOfPages, owner, totalTimesRead);
        }
    }
}
