namespace Lab4;

public class TrainingGame : Game
{
    public override string GameType => "Training Game";

    public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2)
    {
        Points = 0;
    }
}