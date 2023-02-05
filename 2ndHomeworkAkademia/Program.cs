﻿using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Security.Cryptography;

internal class Program
{
    static void Main(string[] args)
    {
        var randomizer = new Random();
        var numberToGuess = randomizer.Next(1, 100);
        var counter = 1;
        var userInput = 0;

        Console.WriteLine("Wylosowałem dla Ciebie liczbę.");
        Console.Write("Spróbuj ją odgadnąć: ");
        
        do
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    throw new Exception("Parsing error.");
                }
                else
                {
                    if (userInput > 100 || userInput < 1)
                    {
                        throw new Exception("userInput out of range.");
                    }

                    else if (userInput < numberToGuess)
                    {
                        Console.WriteLine("Niestety, podana przez Ciebie liczba jest za mała.");
                    }
                    else if (userInput > numberToGuess)
                    {
                        Console.WriteLine("Niestety, podana przez Ciebie liczba jest za duża.");
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
            finally
            {
                Console.WriteLine("Spróbuj ponownie: ");
            }

            } 
        while (userInput != numberToGuess);
    }
}