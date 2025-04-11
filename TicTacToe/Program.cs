using System;

class Program
{

    static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' },
    };
    
    private static string[] players = {"X","O"};
    private static char[] signs = { 'X', 'O' };
    private static int input = 0;
    private static int turns = 0;
    
    private static bool gameOver = false;

    static void Main(string[] args)
    {
        while (!gameOver)
        {
            Field();
            AskForInput();
            XorO(signs[turns % 2], input);
            turns++;
            CheckForWin();
        }
    }

    public static void Field()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0],board[0,1],board[0,2]);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1,0],board[1,1],board[1,2]);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2,0],board[2,1],board[2,2]);
    }

    public static void AskForInput()
    {
        bool inputCorrect = false;
        
        do
        {
            Console.WriteLine("\nSpelare {0}: Välj ruta.", players[turns % 2]);
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if ((input == 1) && (board[0, 0] == '1'))
                    inputCorrect = true;
                else if ((input == 2) && (board[0, 1] == '2'))
                    inputCorrect = true;
                else if ((input == 3) && (board[0, 2] == '3'))
                    inputCorrect = true;
                else if ((input == 4) && (board[1, 0] == '4'))
                    inputCorrect = true;
                else if ((input == 5) && (board[1, 1] == '5'))
                    inputCorrect = true;
                else if ((input == 6) && (board[1, 2] == '6'))
                    inputCorrect = true;
                else if ((input == 7) && (board[2, 0] == '7'))
                    inputCorrect = true;
                else if ((input == 8) && (board[2, 1] == '8'))
                    inputCorrect = true;
                else if ((input == 9) && (board[2, 2] == '9'))
                    inputCorrect = true;
                else
                {
                    Console.WriteLine("Ej giltig ruta");
                    inputCorrect = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Skriv en siffra mellan 1 och 9.");
            }

        } while (!inputCorrect);
    }

    public static void XorO(char sign, int input)
    {
        switch (input)
        {
            case 1: board[0, 0] = sign; break;
            case 2: board[0, 1] = sign; break;
            case 3: board[0, 2] = sign; break;
            case 4: board[1, 0] = sign; break;
            case 5: board[1, 1] = sign; break;
            case 6: board[1, 2] = sign; break;
            case 7: board[2, 0] = sign; break;
            case 8: board[2, 1] = sign; break;
            case 9: board[2, 2] = sign; break;
        }
    }

    public static void CheckForWin()
    {
        foreach (var sign in signs)
        {
            //Check for win on any row
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == sign &&
                    board[row, 1] == sign &&
                    board[row, 2] == sign)
                {
                    Console.WriteLine($"Player {sign} won");
                    gameOver = true;
                    return;
                }
            }
            
            // Check for win any columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == sign && 
                    board[1, col] == sign && 
                    board[2, col] == sign)
                {
                    Console.WriteLine($"Player {sign} won");
                    gameOver = true;
                    return;
                }
            }
            
            // Check win on any columns
            if ((board[0, 0] == sign && board[1, 1] == sign && board[2, 2] == sign) ||
                (board[0, 2] == sign && board[1, 1] == sign && board[2, 0] == sign))
            {
                Console.WriteLine($"Player {sign} won");
                gameOver = true;
                return;
            }
        }
    }
}