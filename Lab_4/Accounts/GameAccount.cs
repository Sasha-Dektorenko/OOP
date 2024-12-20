namespace Lab4;

public class GameAccount
{
    private static int userID;
    
    public GameAccount(string userName)
    {
        UserID = ++userID;
        UserName = userName;
        CurrentRating = 100;
        GameHistory = new List<Game>();
    }

    public int UserID { get; }
    public string UserName { get; set; }
    public List<Game> GameHistory { get; protected set; }
    public int CurrentRating { get; protected set; }

    public int GamesCount => GameHistory.Count;

    public virtual string AccountType => "Standart";


    protected virtual void RatingCount(Game game)
    {
        if (game.Winner == this)
        {
            CurrentRating += game.Points;
        }
        else
        {
            if (CurrentRating - game.Points >= 1)
                CurrentRating -= game.Points;
            else CurrentRating = 1;
        }
    }

    public void GameResult(Game game)
    {
        RatingCount(game);
    }
}