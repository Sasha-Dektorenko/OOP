namespace Lab_2;

public class AllOrNothingGame : Game
{
    public AllOrNothingGame(GameAccount player1, GameAccount player2) : base(player1, player2)
    {
        Points = Math.Min(player1.CurrentRating, player2.CurrentRating) - 1;
    }
}