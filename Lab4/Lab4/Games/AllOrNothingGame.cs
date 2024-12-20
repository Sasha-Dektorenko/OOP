namespace Lab4;

public class AllOrNothingGame : Game
{
    public override string GameType => "All-or-nothing game";

    public AllOrNothingGame(GameAccount player1, GameAccount player2) : base(player1, player2)
    {
        Points = Math.Min(player1.CurrentRating, player2.CurrentRating) - 1;
    }
}