namespace Lab4;

public class DefaultGame : Game
{
    public override string GameType => "Default Game";
    public DefaultGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2)
    {
        Points = rating;
    }
}