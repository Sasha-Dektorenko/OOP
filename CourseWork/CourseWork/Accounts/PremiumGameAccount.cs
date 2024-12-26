namespace CourseWork;

public class PremiumGameAccount : GameAccount
{
    public override string AccountType => "Premium";
    public PremiumGameAccount(string userName, string password) : base(userName, password)
    {
    }

    protected override void RatingCount(Game game)
    {
        if (game.Winner == this)
        {
            CurrentRating += game.Points;
        }
        else
        {
            if (CurrentRating - game.Points / 2 >= 1)
                CurrentRating -= game.Points / 2;
            else CurrentRating = 1;
        }
    }
}