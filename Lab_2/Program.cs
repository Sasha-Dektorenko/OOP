using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accounts = new List<GameAccount>();
            var Roma = new PremiumGameAccount("Roma");
            accounts.Add(Roma);
            var Vova = new GameAccount("Vova");
            accounts.Add(Vova);
            var Sasha = new GameAccount("Sasha");
            accounts.Add(Sasha);
            var Jorik = new StreakGameAccount("Jorik");
            accounts.Add(Jorik);
            Console.WriteLine();
            
            
            var playGames = true;
            while (playGames)
            {
                Console.WriteLine("\nAvailable players:");
                for (var i = 0; i < accounts.Count; i++) 
                    Console.WriteLine($"{i + 1}. {accounts[i].UserName} ({accounts[i].AccountType})");

                Console.Write("Enter the number of the first player: ");
                int.TryParse(Console.ReadLine(), out var player1Index);
                Console.Write("Enter the number of the second player: ");
                int.TryParse(Console.ReadLine(), out var player2Index);

                if (player1Index < 1 || player1Index > accounts.Count || player2Index < 1 ||
                    player2Index > accounts.Count || player1Index == player2Index)
                {
                    Console.WriteLine("Invalid player selection. Please try again.");
                    continue;
                }

                var player1 = accounts[player1Index - 1];
                var player2 = accounts[player2Index - 1];

                Console.WriteLine("\nChoose game type:");
                Console.WriteLine("1. Default game");
                Console.WriteLine("2. Training game");
                Console.WriteLine("3. All-or-Nothing game");
                Console.Write("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out var gameType);

                try
                {
                    Play.game(player1, player2, gameType);
                    Console.WriteLine($"{player1.UserName}'s new rating: {player1.CurrentRating}");
                    Console.WriteLine($"{player2.UserName}'s new rating: {player2.CurrentRating}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.Write("Do you want to play another game? (y/n): ");
                playGames = Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase);
            }
            
            
            var viewHistory = true;
            while (viewHistory)
            {
                Console.WriteLine("\nView game history for a specific player:");
                for (var i = 0; i < accounts.Count; i++) Console.WriteLine($"{i + 1}. {accounts[i].UserName}");
                Console.WriteLine("0. Exit history view");

                Console.Write("Enter the number of the player to view history, or 0 to exit: ");
                int.TryParse(Console.ReadLine(), out var playerIndex);

                if (playerIndex == 0)
                {
                    viewHistory = false;
                }
                else if (playerIndex > 0 && playerIndex <= accounts.Count)
                {
                    var selectedPlayer = accounts[playerIndex - 1];
                    Stats.Get(selectedPlayer);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }

            
            Console.WriteLine("\nFinal Ratings:");
            foreach (var account in accounts)
                Console.WriteLine($"{account.UserName}'s final rating: {account.CurrentRating}");
        }
    }
}