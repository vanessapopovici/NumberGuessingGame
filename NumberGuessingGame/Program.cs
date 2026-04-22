using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }
        static void PlayGame()
        {
            Console.WriteLine("Welcome to the Number Guessing Game!\n" +
                  "I have selected a number between 1 and 100. Can you guess it?");

            Random random = new Random();

            int round = 1;
            bool playAgain = true;
            while (playAgain)
            {
                int number = random.Next(1, 101);
                int guess = 0;
                int attempts = 0;

                Console.WriteLine($"\nRound {round}");

                while (guess != number)
                {
                    attempts++;
                    Console.Write($"Attempt {attempts} - Enter your guess: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out guess))
                    {
                        Console.WriteLine("Invalid input. Please enter a whole number.");
                        attempts--;
                        continue;
                    }
                    if(guess < 1 || guess > 100)
                    {
                        Console.WriteLine("Please enter a number between 1 and 100.");
                        attempts--;
                        continue;
                    }

                    if (guess > number)
                        Console.WriteLine("Too high! Try again.");
                    else if (guess < number)
                        Console.WriteLine("Too low! Try again.");
                    else
                        Console.WriteLine($"Congratulations! You guessed the number. It took you {attempts} attempt{(attempts == 1 ? "" : "s")}.");

                }
                round++;
                Console.WriteLine("Play Again? (y/n): ");
                playAgain = Console.ReadLine()?.Trim().ToLower() == "y";
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}
