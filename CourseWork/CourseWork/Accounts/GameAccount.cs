namespace CourseWork;

public class GameAccount
{
    private static int userID;
    public string Password { get; }
    
    public GameAccount(string userName, string password)
    {
        Password = password;
        UserID = ++userID;
        UserName = userName;
        CurrentRating = 100;
    }

    public int UserID { get; }
    public string UserName { get; set; }
    
    public int CurrentRating { get; protected set; }

    public virtual string AccountType => "Standart";


    public virtual void RatingCount(Game game)
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
    
}