
namespace CourseWork;

public abstract class Game
{
    private static int gameID;
    public int GameID { get; }
    public abstract string GameType { get; }
    public GameAccount Player1 { get; }
    public GameAccount Player2 { get; }
    public GameAccount CrossPlayer { get; }
    public GameAccount ZeroPlayer { get; }
    public int Points { get; protected set; }
    public char[,] Board { get; }
    public GameAccount CurrentPlayer { get; protected set; }
    public GameAccount Winner { get; protected set; }
    public GameAccount Looser { get; protected set; }
    
    public Game(GameAccount player1, GameAccount player2)
    {
        GameID = ++gameID;
        Player1 = player1;
        Player2 = player2;

        Board = new char[3, 3]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };
        
        Console.WriteLine($"Player 1 ({Player1.UserName}), do you want to play as X (Cross)? (yes/no): ");
        string choice = Console.ReadLine()?.ToLower();

        if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            CrossPlayer = Player1;
            ZeroPlayer = Player2;
        }
        else
        {
            CrossPlayer = Player2;
            ZeroPlayer = Player1;
        }
        
        CurrentPlayer = CrossPlayer;
    }

    protected void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(Board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--+---+--");
        }
    }

    protected (int, int) GetTurn()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter your move (row and column, space-separated): ");
                var inputs = Console.ReadLine()?.Split(' ');

                if (inputs == null || inputs.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter two numbers separated by a space.");
                    continue;
                }

                int row = int.Parse(inputs[0]) - 1;
                int col = int.Parse(inputs[1]) - 1;

                if (!IsTurnValid(row, col))
                {
                    Console.WriteLine("Invalid move. The cell is either out of bounds or already taken. Try again.");
                    continue;
                }

                return (row, col);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter numeric values for row and column.");
            }
        }
    }

    protected bool IsTurnValid(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && Board[row, col] == ' ';
    }

    protected char GetPlayerSymbol()
    {
        return CurrentPlayer == CrossPlayer ? 'X' : 'O';
    }

    protected void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == CrossPlayer ? ZeroPlayer : CrossPlayer;
    }

    protected bool IsWinner(char symbol)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((Board[i, 0] == symbol && Board[i, 1] == symbol && Board[i, 2] == symbol) ||
                (Board[0, i] == symbol && Board[1, i] == symbol && Board[2, i] == symbol))
                return true;
        }

        if ((Board[0, 0] == symbol && Board[1, 1] == symbol && Board[2, 2] == symbol) ||
            (Board[0, 2] == symbol && Board[1, 1] == symbol && Board[2, 0] == symbol))
            return true;

        return false;
    }

    protected bool IsBoardFull()
    {
        foreach (var cell in Board)
        {
            if (cell == ' ')
                return false;
        }
        return true;
    }

    protected GameAccount GetOpponent()
    {
        return CurrentPlayer == CrossPlayer ? ZeroPlayer : CrossPlayer;
    }

    protected virtual void HandleGameEnd(GameAccount winner, GameAccount loser)
    {
        Console.WriteLine("Game over.");
    }

    public virtual void Play()
    {
        bool isGameRunning = true;

        while (isGameRunning)
        {
            Console.Clear();
            DisplayBoard();
            Console.WriteLine($"Player {CurrentPlayer.UserName}'s turn ({GetPlayerSymbol()}):");
            var (row, col) = GetTurn();

            Board[row, col] = GetPlayerSymbol();

            if (IsWinner(GetPlayerSymbol()))
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"Player {CurrentPlayer.UserName} wins!");
                HandleGameEnd(CurrentPlayer, GetOpponent());
                isGameRunning = false;
            }
            else if (IsBoardFull())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                HandleGameEnd(null, null);
                isGameRunning = false;
            }
            else
            {
                SwitchPlayer();
            }
        }
    }
}
