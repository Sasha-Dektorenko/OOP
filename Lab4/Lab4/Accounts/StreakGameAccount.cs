namespace Lab4;

public class StreakGameAccount : GameAccount
{
    public override string AccountType => "Streak";
    public StreakGameAccount(string userName) : base(userName)
    {
        streak = 0;
    }

    public int streak { get; private set; }

    protected override void RatingCount(Game game)
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