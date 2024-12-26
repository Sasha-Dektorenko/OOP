namespace CourseWork;

public class DbContext
{
    public List<GameAccount> Gamers { get; } 
    public List<Game> Games { get; } 

    public DbContext()
    {
        Games = new List<Game>();
        Gamers = new List<GameAccount>();
        Gamers.Add(new GameAccount("Vitya", "12345678"));
        Gamers.Add(new GameAccount("Misha", "87654321"));
    }
}