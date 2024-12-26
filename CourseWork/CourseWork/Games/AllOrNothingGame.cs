namespace CourseWork;

public class AllOrNothingGame : Game
{
    public override string GameType => "All-or-nothing game";

    public AllOrNothingGame(GameAccount player1, GameAccount player2) : base(player1, player2)
    {
        Points = Math.Min(player1.CurrentRating, player2.CurrentRating) - 1;
    }
    
    protected override void HandleGameEnd(GameAccount winner, GameAccount loser)
    {
        if (winner != null && loser != null)
        {
            Console.WriteLine($"{winner.UserName} won {loser.UserName} and received all his {Points} points.");
            Winner = winner;
            Looser = loser;
        }
        else
        {
            Console.WriteLine("No points awarded for a draw.");
        }
    }
}