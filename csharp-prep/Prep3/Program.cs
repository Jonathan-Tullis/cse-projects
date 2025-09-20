using System;
using System.Runtime.CompilerServices;

// This is a number guessing game where the user has to guess a randomly generated number between 0 and whatever you want.
class Program
{
    static void Main(string[] args)
    {
        




        Console.Write("Guess a number between 1 and 100: ");

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);


        bool hasGuessedNumber = false;
        while (!hasGuessedNumber)
        {
            string input = Console.ReadLine();
            int userInput = int.Parse(input);


            if (userInput > number)
            {
                Console.WriteLine("Guess Lower");
            }
            else if (userInput < number)
            {
                Console.WriteLine("Guess Higher");
            }
            else
            {
                Console.WriteLine("Correct!");
                hasGuessedNumber = true;
            }

        }

        Console.WriteLine("You have completed the game!");   
    }
}