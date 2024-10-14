using System;

namespace Lab_1;

public class Game
{
    private static int gameID = 0;
    public GameAccount Winner { get; }
    public GameAccount Looser { get; }
    public int Points { get; }
    public int GameID { get; } 

    public Game(GameAccount winner, GameAccount looser, int points)
    {
        Winner = winner;
        Looser = looser;
        Points = points;
        GameID = ++gameID;
    }
}