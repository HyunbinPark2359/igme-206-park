﻿namespace StatementsDemoHP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //statements
            Console.WriteLine("This will go away!");
            Console.Clear();

            Console.Write("Hi ");
            Console.Write("there ");
            Console.WriteLine("everybody!");

            Console.WriteLine("Hi " + "there " + "everybody!");

            Console.WriteLine("Hi there everybody!");

            //expressions
            Console.WriteLine(6 + 3 * 8 - 4);

            Console.WriteLine(
                3.14159 * 
                8.2 * 
                8.2);

            Console.WriteLine("Hours per week: " + 7 * 24);

            Console.WriteLine("5" + 5);
        }
    }
}
