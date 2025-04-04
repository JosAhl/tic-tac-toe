using System;

class Program
{

    static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' },
    };
    
    private static string[] players = ["Kalle","Kajsa"];

private static int turns = 0;

    static void Main(string[] args)
    {
        
        Field();
        Game();

    }

    public static void Field()
    {
        Console.Clear();
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0,0],board[0,1],board[0,2]);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1,0],board[1,1],board[1,2]);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[2,0],board[2,1],board[2,2]);
        turns++;
    }

    public static void Game()
    {
        bool inputCorrect = false;
        int input = 0;
        do
        {
            Console.WriteLine("\n Spelare {0}: Välj ruta.", players[0]);
            try
            {
                input = Convert.ToInt32((Console.ReadLine()));
                if ((input == 1) && (board[0, 0] == '1'))
                    inputCorrect = true;
                else if((input == 2) && (board[0, 1] == '2'))
                    inputCorrect = true;
                else if((input == 3) && (board[0, 2] == '3'))
                    inputCorrect = true;
                else if((input == 4) && (board[1, 0] == '4'))
                    inputCorrect = true;
                else if((input == 5) && (board[1, 1] == '5'))
                    inputCorrect = true;
                else if((input == 6) && (board[1, 2] == '6'))
                    inputCorrect = true;
                else if((input == 7) && (board[2, 0] == '7'))
                    inputCorrect = true;
                else if((input == 8) && (board[2, 1] == '8'))
                    inputCorrect = true;
                else if((input == 9) && (board[2, 2] == '9'))
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
}