namespace Lab4;

public class GamesByType : ICommand
{
    public IGameService gameService { get; }

    public GamesByType(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter type of games you want to see: ");
        var gameType = Console.ReadLine();
        var gamesByGameType = gameService.GetGamesByGameType(gameType);
        if (gamesByGameType.Count != 0)
        {
            foreach (var game in gamesByGameType)
            {
                gameService.DisplayGameById(game.GameID);
            }
        } else Console.WriteLine("No games with such type");
    }

    public string GetInfo()
    {
        return "Display all games by entered game type";
    }
}