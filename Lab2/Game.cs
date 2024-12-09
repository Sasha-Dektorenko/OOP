namespace Lab_2;

public abstract class Game
{
    private static int gameID;

    public Game(GameAccount player1, GameAccount player2)
    {
        Random random = new Random();
        Winner = random.Next(0, 2) == 0 ? player1 : player2;
        Looser = Winner == player1 ? player2 : player1;
        GameID = ++gameID;
    }

    public GameAccount Winner { get; }
    public GameAccount Looser { get; }
    public int Points { get; protected set; }
    public int GameID { get; }
    
}