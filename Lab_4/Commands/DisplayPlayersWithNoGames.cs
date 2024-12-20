namespace Lab4;

public class DisplayPlayersWithNoGames : ICommand
{
    public IUserService userService { get; }

    public DisplayPlayersWithNoGames(IUserService userService)
    {
        this.userService = userService;
    }

    public void Execute()
    {
        var gamersWithNoGames = userService.GetUsersWithNoGames();
        if (gamersWithNoGames.Count != 0)
        {
            foreach (var gamer in gamersWithNoGames)
            {
                Console.WriteLine($"ID: {gamer.UserID} Name: {gamer.UserName}");
            }
        } else Console.WriteLine("No gamers without games\n");
    }

    public string GetInfo()
    {
        return "Show players without any games";
    }
}