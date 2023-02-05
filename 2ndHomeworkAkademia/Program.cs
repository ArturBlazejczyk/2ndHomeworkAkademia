using System.Diagnostics.Metrics;
using System.Net.WebSockets;

internal class Program
{
    static void Main(string[] args)
    {
        var randomizer = new Random();
        var numberToGuess = randomizer.Next(1, 100);
        var counter = 0;

        Console.WriteLine("Wylosowałem dla Ciebie liczbę.");
        Console.Write("Spróbuj ją odgadnąć: ");
        int userInput = 0;
        do
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    throw new Exception("Podana została nieprawidłowa liczba.");
                }
                else
                {
                    if (userInput < numberToGuess)
                    {
                        Console.WriteLine("Niestety, podana przez Ciebie liczba jest za mała.");
                        Console.Write("Spróbuj ponownie: ");
                    }
                    else if (userInput > numberToGuess)
                    {
                        Console.WriteLine("Niestety, podana przez Ciebie liczba jest za duża.");
                        Console.Write("Spróbuj ponownie: ");
                    }
                    else if (userInput == numberToGuess)
                    {
                        Console.WriteLine("\nUdało Ci się!");
                        Console.WriteLine($"Odgadłeś wylosowaną liczbę w {counter} próbach");
                    }
                    counter++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Podana została nieprawidłowa liczba.");
                continue;
            }
            
        } 
        while (userInput != numberToGuess);
    }
}