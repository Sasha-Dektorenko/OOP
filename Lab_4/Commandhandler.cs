namespace Lab4;

public class CommandHandler
{
    public Dictionary<string, ICommand> Commands { get; }

    public CommandHandler(IUserService userService, IGameService gameService)
    {
        Commands = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            { "create player", new CreatePlayer(userService) },
            { "rename player", new UpdatePlayer(userService) },
            { "delete player", new DeletePlayer(userService) },
            { "players", new DisplayAllPlayers(userService) },
            { "player info", new DisplayUserInfo(userService) },
            { "player stats", new DisplayPlayerStats(userService) },
            { "create game", new CreateGame(gameService) },
            { "delete game", new DeleteGame(gameService) },
            { "game history", new GameHistory(gameService) },
            { "games by type", new GamesByType(gameService) },
            { "players withing rating", new DisplayUsersWithingRating(userService) },
            { "players without games", new DisplayPlayersWithNoGames(userService) },
            { "players by namepart", new SearchPlayersByNamePart(userService) },
            { "players by account type" , new ShowPlayersWithAccountType(userService)},
            { "games by game points", new ShowGamesByPoints(gameService) },
            { "exit program", new Exit() }
        };
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nEnter command \"help\" to see a list of commands:");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input)) continue;

            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var command in Commands)
                {
                    Console.WriteLine($"{command.Key} - {command.Value.GetInfo()}");
                }
            }
            else if (Commands.ContainsKey(input))
            {
                Commands[input].Execute();
            }
            else
            {
                Console.WriteLine("Unknown command. Enter \"help\" to see available commands.");
            }
        }
    }

}