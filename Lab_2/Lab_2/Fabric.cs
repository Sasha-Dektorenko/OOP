namespace Lab_2;

public static class Fabric
{
    public static Game CreateDefaultGame(GameAccount player1, GameAccount player2, int rating)
    {
        return new DefaultGame(player1, player2, rating);
    }

    public static Game CreateTrainingGame(GameAccount player1, GameAccount player2)
    {
        return new TrainingGame(player1, player2);
    }

    public static Game CreateAllOrNothingGame(GameAccount player1, GameAccount player2)
    {
        return new AllOrNothingGame(player1, player2);
    }
}