namespace Lab_2;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount winner, GameAccount looser) : base(winner, looser)
    {
        Points = 0;
    }
}