using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

// This is a number guessing game where the user has to guess a randomly generated number between 0 and whatever you want.
class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        {
            Console.WriteLine("Guess a number between 1 and 100");

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);

            int numberOfGuesses = 1;
            bool hasGuessedNumber = false;
            while (!hasGuessedNumber)
            {
                Console.Write("What is your guess?? ");
                string input = Console.ReadLine();
                int userInput = int.Parse(input);

                if (userInput > number)
                {
                    Console.WriteLine("Guess Lower");
                    numberOfGuesses++;
                }
                else if (userInput < number)
                {
                    Console.WriteLine("Guess Higher");
                    numberOfGuesses++;
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    hasGuessedNumber = true;
                }

            }

            Console.WriteLine($"You completed the game in {numberOfGuesses} guesses!");

            Console.Write("Do you want to play again? ");
            string response = Console.ReadLine();

            if (response.ToLower() != "yes")
            {
                playAgain = false;
            }

        }

    }
}