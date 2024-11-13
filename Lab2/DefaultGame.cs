namespace Lab_2;

public class DefaultGame : Game
{
    public DefaultGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2)
    {
        Points = rating;
    }
}