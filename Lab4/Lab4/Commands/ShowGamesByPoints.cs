namespace Lab4;

public class ShowGamesByPoints : ICommand
{
    public IGameService gameService { get; }

    public ShowGamesByPoints(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public void Execute()
    {
        Console.WriteLine("Enter game points: ");
        string pointsInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(pointsInput))
        {
            Console.WriteLine("Points cannot be empty.");
            return;
        }
        var points = int.Parse(pointsInput);
        if (points <= 0)
        {
            Console.WriteLine("Points cannot be zero or below");
            return;
        }
        var gamesByPoints = gameService.GetGamesByPoints(points);
        if (gamesByPoints.Count != 0)
        {
            foreach (var game in gamesByPoints)
            {
                gameService.DisplayGameById(game.GameID);
            }
        } else Console.WriteLine("No games where players played for such points");
    }

    public string GetInfo()
    {
        return "Show games with entered points played for";
    }
}