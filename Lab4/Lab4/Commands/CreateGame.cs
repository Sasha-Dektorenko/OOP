namespace Lab4;

public class CreateGame : ICommand
{
    public IGameService gameService { get; }

    public CreateGame(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public void Execute()
    {
        bool ind = true;
        while (ind)
        {
            int rating = 0;
            Console.WriteLine("Enter first player ID: ");
            var player1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second player ID: ");
            var player2 = int.Parse(Console.ReadLine());
            if (player1 == player2)
            {
                Console.WriteLine("Player ID's should be different");
                continue;
            } 
            Console.WriteLine("Enter game type(1 - Standart, 2 - Training, 3 - All-or-nothing): ");
            var gameType = int.Parse(Console.ReadLine());
            if (gameType > 3 || gameType < 0)
            {
                Console.WriteLine("Invalid game type index, pick from 1 to 3");
                continue;
            }

            if (gameType == 1)
            {
                Console.WriteLine("Enter points playing for:");
                rating = int.Parse(Console.ReadLine());
            }
            gameService.CreateGame(player1, player2, gameType, rating);
            ind = false;
        }
    }

    public string GetInfo()
    {
        return "Create a game";
    }
}