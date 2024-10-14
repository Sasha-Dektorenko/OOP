using System;

namespace Lab_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameAccount Roma = new GameAccount("Roma");
            GameAccount Vova = new GameAccount("Vova");
            GameAccount Sasha = new GameAccount("Sasha");
            Console.WriteLine();
            
            Console.WriteLine($"Default Roma's rating: {Roma.CurrentRating}");
            Console.WriteLine($"Default Vova's rating: {Vova.CurrentRating}");
            Console.WriteLine($"Default Sasha's rating: {Sasha.CurrentRating}");
            Console.WriteLine();
            
            Roma.WinGame(Vova, 15);
            Vova.WinGame(Sasha, 10);
            Sasha.LoseGame(Roma, 25);
            Roma.LoseGame(Vova, 40);
            
            Roma.GetStats();
            Console.WriteLine();
            Vova.GetStats();
            Console.WriteLine();
            Sasha.GetStats();
            Console.WriteLine();
            
            Console.WriteLine($"Roma's current rating: {Roma.CurrentRating}");
            Console.WriteLine($"Vova's current rating: {Vova.CurrentRating}");
            Console.WriteLine($"Sasha's current rating: {Sasha.CurrentRating}");
        }
    }
}