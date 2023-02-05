using System.Diagnostics.Metrics;

internal class Program
{
    static void Main(string[] args)
    {
        //1.Aplikacja losuje 1 liczbę od 0 do 100

        var randomizer = new Random();
        var numberToGuess = randomizer.Next(1, 100);

        //2.Użytkownik próbuje odgadnąć liczbę

        Console.WriteLine("Wylosowałem dla Ciebie liczbę.");
        Console.Write("Spróbuj ją odgadnąć: ");
        var userInput = int.Parse(Console.ReadLine());

        //3. Komunikat jeśli podana liczba jest za mała
        if (userInput < numberToGuess)
        {
            Console.WriteLine("Niestety, podana przez Ciebie liczba jest za mała.");
        }
        //4. Komunikat jeśli podana liczba jest za duża
        else if (userInput > numberToGuess) 
        { 
            Console.WriteLine("Niestety, podana przez Ciebie liczba jest za duża."); 
        }
        //5. Komunikat po odgadnięciu liczby -  odgadłeś wylosowaną liczbę w x próbach
        else if (userInput== numberToGuess) 
        {
            Console.WriteLine("Udało Ci się!");
            Console.WriteLine($"Odgadłeś wylosowaną liczbę w /counter/ próbach");
        }
    }
}