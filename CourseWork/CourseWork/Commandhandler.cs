namespace CourseWork;

public class CommandHandler
{
    public Dictionary<string, ICommand> Commands { get; }

    public CommandHandler(IUserService userService, IGameService gameService)
    {
        Commands = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            { "register", new RegisterPlayer(userService) },
            { "login", new LoginPlayer(userService)},
            { "logout", new Logout(userService) },
            { "rename", new UpdatePlayer(userService) },
            { "delete account", new DeletePlayer(userService) },
            { "all players", new DisplayAllPlayers(userService) },
            { "player info", new DisplayUserInfo(userService) },
            { "player stats", new DisplayPlayerStats(userService) },
            { "play game", new CreateGame(gameService, userService) },
            { "game history", new GameHistory(gameService) },
            { "exit", new Exit() }
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