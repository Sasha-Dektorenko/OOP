namespace CourseWork;

public class StreakGameAccount : GameAccount
{
    public override string AccountType => "Streak";
    public StreakGameAccount(string userName, string password) : base(userName,password)
    {
        streak = 0;
    }

    public int streak { get; private set; }

    public override void RatingCount(Game game)
    {
        if (game.Winner == this)
        {
            if (!(game is TrainingGame)) streak++;
            CurrentRating += game.Points;
            if (streak >= 3) CurrentRating += 10;
        }
        else
        {
            streak = 0;
            if (CurrentRating - game.Points >= 1)
                CurrentRating -= game.Points;
            else CurrentRating = 1;
        }
    }
}