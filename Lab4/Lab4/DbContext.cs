namespace Lab4;

public class DbContext
{
    public List<GameAccount> Gamers { get; } 
    public List<Game> Games { get; } 

    public DbContext()
    {
        Games = new List<Game>();
        Gamers = new List<GameAccount>();
        Gamers.Add(new GameAccount("Vitya"));
        Gamers.Add(new GameAccount("Misha"));
        Games.Add(new DefaultGame(Gamers[0], Gamers[1], 15));
        Games.Add(new TrainingGame(Gamers[0], Gamers[1]));
    }
}