using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;

internal class Program
{
    static void Main(string[] args)
    {
        var randomizer = new Random();
        var numberToGuess = randomizer.Next(0, 101);
        var counter = 1;
        var userInput = 0;

        Console.WriteLine("Wylosowałem dla Ciebie liczbę pomiędzy 0 a 100.");
        Console.Write("Spróbuj ją odgadnąć: ");
        
        do
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    throw new Exception ("Parsing error.");

                IsAnswerCorrect(userInput, numberToGuess);
                counter++;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Podana liczba nie mieści się w zakresie losowania.");
                Console.WriteLine("Podaj liczbę z zakresu od 0 do 100.");
                Console.WriteLine("Spróbuj ponownie: ");
            }
            catch (Exception)
            {
                Console.WriteLine("Podana została nieprawidłowa wartość.");
                Console.WriteLine("Podaj liczbę z zakresu od 0 do 100.");
                Console.WriteLine("Spróbuj ponownie: ");
            }

        } 
        while (userInput != numberToGuess);
        Console.WriteLine($"Odgadłeś wylosowaną liczbę w {counter} próbach");
    }

    private static void IsAnswerCorrect(int userInput, int numberToGuess)
    {
        if (userInput > 100 || userInput < 0)
            throw new ArgumentOutOfRangeException("userInput out of range.");

        else if (userInput < numberToGuess)
        {
            Console.WriteLine("Niestety, podana przez Ciebie liczba jest za mała.");
            Console.WriteLine("Spróbuj ponownie: ");
        }
        else if (userInput > numberToGuess)
        {
            Console.WriteLine("Niestety, podana przez Ciebie liczba jest za duża.");
            Console.WriteLine("Spróbuj ponownie: ");
        }
        else if (userInput == numberToGuess)
        {
            Console.WriteLine("\nUdało Ci się!");
        }
    }
}